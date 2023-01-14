package com.example.stop_its_complete;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.media.MediaPlayer;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.os.Handler;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.Query;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.List;

public class MainActivity2 extends AppCompatActivity {

    MediaPlayer mp ;

    char flag;
    ListView listView ;
    Button button ,roomsBtn;
    TextView myPoints ;
    List<String> roomsList ;

    String playerName  , roomName ;
    int playerPoints;

    Handler handler;

    FirebaseDatabase database;
    DatabaseReference roomS_Ref, pointsRef, playerRef, reqRef;

    private boolean isNetworkAvailable() {
        ConnectivityManager connectivityManager
                = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();
        return activeNetworkInfo != null && activeNetworkInfo.isConnected();
    }

    @Override
    protected void onCreate(final Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);

        mp = MediaPlayer.create(this, R.raw.notification_sound);
        flag = '\0';
        roomsBtn = findViewById(R.id.roomsBtn);
        handler = new Handler();
        handler.postDelayed(new Runnable() {
            @Override
            public void run() {
                if(isNetworkAvailable()){
                    roomsBtn.setBackgroundResource(R.drawable.connected_bg);
                    roomsBtn.setText("SHOW ROOMS");
                    showRooms();
                }else{
                    roomsBtn.setBackgroundResource(R.drawable.notconnected_bg);
                    roomsBtn.setText("THERE NO CONNECTION !");
                    Toast.makeText(getApplicationContext(), "NO CONNECTION !" , Toast.LENGTH_SHORT).show();
                }

                handler.postDelayed(this, 4000);
            }
        }, 5000);  //the time is in miliseconds

        database = FirebaseDatabase.getInstance();

        SharedPreferences preferences = getSharedPreferences("PREFS" , 0);
        playerName = preferences.getString("playerName","");
        playerPoints = preferences.getInt("playerPoints",0);
        myPoints = findViewById(R.id.myPoints);
        myPoints.setText(" TOTAL SCORE : " + playerPoints);

        setOnLine();

        listView = findViewById(R.id.roomsListView);
        button = findViewById(R.id.createRoom);
        button.setText("CREATE ROOM");
        button.setEnabled(true);

        // All Available Rooms
        roomsList = new ArrayList<>();

        // Create new room  and add yourself as player1
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(isNetworkAvailable()){
                    button.setText("CREATING A ROOM ...");
                    button.setEnabled(false);
                    roomName = playerName +  "Room";
                    pointsRef = database.getReference("rooms/" + roomName + "/points/" + playerName );
                    pointsRef.setValue("");
                    joinRoom(roomName);
                }else{
                    Toast.makeText(getApplicationContext(), "SORRY, CONNECT AND TRY AGAIN !",Toast.LENGTH_SHORT).show();
                }

            }
        });


        // Join an existing room and add yourself as player2
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if(isNetworkAvailable()){
                    roomName = roomsList.get(position);
                    String friendName = roomName.substring(0,roomName.length()-4);
                    if(!friendName.equals(playerName)){
                        sendPlayRequest();
                    }
                    else{
                        joinRoom(roomName);
                    }
                }else{
                    Toast.makeText(getApplicationContext(), "SORRY, CONNECT AND TRY AGAIN !",Toast.LENGTH_SHORT).show();
                }

            }
        });

        // Reload Online Rooms
        roomS_Ref = database.getReference("rooms");
        addRoomsEventListetner();
        roomsBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                showRooms();
            }
        });
        //*************************************************************************
        MyService myService = new MyService();                                //**
        Intent intent = new Intent(this, MyService.class);
        startService(intent);                                            //**
        //*****************************************************************

        receivePlayRequest();
    }

    public void receivePlayRequest() {
        reqRef = database.getReference("players/" + playerName + "/requests");
        reqRef.addValueEventListener(myListener);
    }
    ValueEventListener myListener = new ValueEventListener() {
        @Override
        public void onDataChange(@NonNull DataSnapshot snapshot) {
            if(snapshot.getKey() != null && snapshot.getValue() != null ){
                Iterable<DataSnapshot> players = snapshot.getChildren();
                for(DataSnapshot snapshot1 : players){
                    String friendName = snapshot1.getKey();
                    if(snapshot1.getValue().equals("")){
                        RequestNotification requestNotification = new RequestNotification();
                        requestNotification.setAlarm(MainActivity2.this,friendName);
                    }
                }
            }
        }

        @Override
        public void onCancelled(@NonNull DatabaseError error) {

        }
    };

    private void sendPlayRequest() {
        reqRef = database.getReference("rooms/" + roomName + "/requests/" + playerName);
        reqRef.removeValue();

        reqRef.setValue("").addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                Toast.makeText(getApplicationContext(), "بعت طلب أنضمام للغرفة " ,Toast.LENGTH_SHORT).show();
            }
        });
        ReceiverListener();
    }

    private void ReceiverListener() {
        reqRef = database.getReference("rooms/" + roomName + "/requests/" + playerName);
        reqRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                System.out.println("ReceiverListener Snapshot: " + snapshot);
                if(snapshot.getValue() != null){
                    if(snapshot.getValue().equals("1")){
                        joinRoom(roomName);
                    }else if(snapshot.getValue().equals("0")){
                        Toast.makeText(getApplicationContext(),"تم رفض طلبك !",Toast.LENGTH_SHORT).show();
                    }
                }

            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                if(!error.getMessage().equals(""))
                    Toast.makeText(getApplicationContext(),error.getMessage(),Toast.LENGTH_SHORT).show();
            }
        });
    }

    public void showRooms(){
        Query query = FirebaseDatabase.getInstance().getReference("rooms").orderByPriority();
        query.addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                roomsList.clear();
                Iterable<DataSnapshot> rooms = snapshot.getChildren();
                for(DataSnapshot snapshot1 : rooms){
                    roomsList.add(snapshot1.getKey());

                    ArrayAdapter<String> adapter = new ArrayAdapter<>(MainActivity2.this ,
                            android.R.layout.simple_list_item_1 , roomsList);

                    listView.setAdapter(adapter);
                }
//                Toast.makeText(getApplicationContext(), "Refresh", Toast.LENGTH_SHORT).show();
            }
            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                if(!error.getMessage().equals("")){
                    Toast.makeText(MainActivity2.this, error.getMessage(), Toast.LENGTH_SHORT).show();
                }
            }
        });
    }

    public void joinRoom(String roomName){
        button.setText("JOINING TO ROOM...");
        button.setEnabled(false);
        flag = '1';
        Intent intent = new Intent(getApplicationContext(),MainActivity3.class);
        intent.putExtra("roomName" , roomName);
        startActivity(intent);
        finish();
        button.setText("CREATE ROOM");
        button.setEnabled(true);
    }

    private void addRoomsEventListetner(){
        roomS_Ref.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                // Show list of Rooms :
                roomsList.clear();
                Iterable<DataSnapshot> rooms = snapshot.getChildren();
                for(DataSnapshot snapshot1 : rooms){
                    roomsList.add(snapshot1.getKey());

                    ArrayAdapter<String> adapter = new ArrayAdapter<>(MainActivity2.this ,
                            android.R.layout.simple_list_item_1 , roomsList);

                    listView.setAdapter(adapter);
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                // Error !
                if(!error.getMessage().equals(""))
                    Toast.makeText(MainActivity2.this, error.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }

    public void resretScore(View v){
        SharedPreferences preferences = getSharedPreferences("PREFS", 0);
        SharedPreferences.Editor editor = preferences.edit();
        editor.putInt("playerPoints", 0);
        editor.apply();
        myPoints.setText("TOTAL SCORE : " + 0 );
        pointsRef = database.getReference("players/" + playerName + "/points");
        pointsRef.setValue(0);

    }

    private void addOnlineEventListener(){
        playerRef = database.getReference("players/"+ playerName + "/online");
        playerRef.addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                System.out.println("snapshot.toString() : " + snapshot.toString());
                if((long)snapshot.getValue() == 1){
                    Toast.makeText(getApplicationContext(), "ONLINE" , Toast.LENGTH_SHORT).show();
                }else{
                    Toast.makeText(getApplicationContext(), "OFFLINE" , Toast.LENGTH_SHORT).show();
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                if(!error.getMessage().equals(""))
                    Toast.makeText(getApplicationContext(), error.getMessage() , Toast.LENGTH_SHORT).show();
            }
        });
    }

    @Override
    public void onBackPressed() {
        flag ='1';
        finish();
        Intent intent = new Intent(MainActivity2.this, HomePage.class);
        startActivity(intent);
        finish();
    }

    public void setOnLine(){
        playerRef = database.getReference("players/"+ playerName + "/online");
        playerRef.setValue(1).addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                addOnlineEventListener();
            }
        });

    }

    public void setOffline(){
        playerRef = database.getReference("players/"+ playerName + "/online");
        playerRef.setValue(0);
        addOnlineEventListener();
    }

    @Override
    protected void onPause() {
        super.onPause();
        System.out.println("flag : " + flag);
        if(flag != '1'){
            setOffline();
        }

    }

    @Override
    protected void onRestart() {
        super.onRestart();
        setOnLine();
    }

}