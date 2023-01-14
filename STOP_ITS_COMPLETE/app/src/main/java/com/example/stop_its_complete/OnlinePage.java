package com.example.stop_its_complete;

import androidx.activity.OnBackPressedDispatcher;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.media.MediaPlayer;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.provider.MediaStore;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.Query;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class OnlinePage extends AppCompatActivity {

    static boolean active = false;

    char flag ;
    Handler handler;
    ListView listView ;
    TextView online_players ;
    List<String> onlineList ;

    FirebaseDatabase database ;
    DatabaseReference playerRef , reqRef , pointsRef;
    SharedPreferences preferences ;

    String playerName , friendName , roomName;

    MediaPlayer mp ;

    private boolean isNetworkAvailable() {
        ConnectivityManager connectivityManager
                = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();
        return activeNetworkInfo != null && activeNetworkInfo.isConnected();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_online_page);
        mp = MediaPlayer.create(getApplicationContext(), R.raw.notification_sound);

        flag = '\0';
        database = FirebaseDatabase.getInstance();
        preferences = getSharedPreferences("PREFS" , 0);
        playerName = preferences.getString("playerName",""); // that is written using editor

        onlineList = new ArrayList<>();
        listView = findViewById(R.id.onlineList);

        handler = new Handler();
        handler.postDelayed(new Runnable() {
            @Override
            public void run() {
                if(isNetworkAvailable()){
                    listView.setBackgroundResource(R.drawable.connected_bg);
                }else{
                    listView.setBackgroundResource(R.drawable.notconnected_bg);
                    Toast.makeText(getApplicationContext(), "NO CONNECTION !" , Toast.LENGTH_SHORT).show();
                }

                handler.postDelayed(this, 4000);
            }
        }, 5000);  //the time is in miliseconds

        // Send PlayRequest
        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                if(isNetworkAvailable()){
                    friendName = onlineList.get(position);
                    sendPlayRequest(friendName);
                }else{
                    Toast.makeText(getApplicationContext(), "SORRY, CONNECT AND TRY AGAIN !",Toast.LENGTH_SHORT).show();
                }

            }
        });


        fillOnlineList();
        online_players = findViewById(R.id.online_players);
        receivePlayRequest();
    }

    private void fillOnlineList(){
        Query query = FirebaseDatabase.getInstance().getReference("players")
                .orderByValue();// Default Ascending
        query.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                onlineList.clear();
                Iterable<DataSnapshot> players = snapshot.getChildren();
                for(DataSnapshot snapshot1 : players){
                    System.out.println("THE SNAPSHOT1 : " + snapshot1);
                    if(snapshot1.child("online").getValue() != null && !snapshot1.getKey().equals(playerName)) {
                        if((long)snapshot1.child("online").getValue() == 1)
                            onlineList.add(snapshot1.getKey());
                    }
                }
                Collections.reverse(onlineList); // to be Descending
                System.out.println("onlineList : \n " + onlineList);
                ArrayAdapter<String> adapter = new ArrayAdapter<>(OnlinePage.this ,
                        android.R.layout.simple_list_item_1 , onlineList);

                listView.setAdapter(adapter);
                String nof_players = onlineList.size() + " Online Players";
                online_players.setText(nof_players);
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                Toast.makeText(getApplicationContext(),error.getMessage(),Toast.LENGTH_SHORT).show();
            }
        });
    }

    private void sendPlayRequest(final String friendName) {
        reqRef = database.getReference("players/" + friendName + "/requests/" + playerName);
        reqRef.setValue("").addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                Toast.makeText(getApplicationContext(), "بعت طلب ل " + friendName,Toast.LENGTH_SHORT).show();
            }
        });
        ReceiverListener();
    }

    private void ReceiverListener() {
        reqRef = database.getReference("players/" + friendName + "/requests/" + playerName);
        reqRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                System.out.println("ReceiverListener Snapshot: " + snapshot);
                if(snapshot.getValue() != null){
                   if(snapshot.getValue().equals("1")){
                       joinRoom(playerName);
                   }else if(snapshot.getValue().equals("0")){
                       Toast.makeText(getApplicationContext(),"تم رفض طلبك !",Toast.LENGTH_SHORT).show();
                   }
                }

            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                Toast.makeText(getApplicationContext(),error.getMessage(),Toast.LENGTH_SHORT).show();
            }
        });
    }

    private void receivePlayRequest() {
        reqRef = database.getReference("players/" + playerName + "/requests");
        reqRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                if(snapshot.getKey() != null && snapshot.getValue() != null ){
                    Iterable<DataSnapshot> players = snapshot.getChildren();
                    for(DataSnapshot snapshot1 : players){
                        friendName = snapshot1.getKey();
                        if(snapshot1.getValue().equals("")){
                            showDialog(friendName);
                        }
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    void showDialog(final String friendName) {
        android.app.AlertDialog.Builder dialog = new AlertDialog.Builder(OnlinePage.this);
        dialog.setTitle("Play Request...");
        dialog.setMessage(friendName + " invent you to play!");
        dialog.setPositiveButton("Accept", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                acceptPlayReq(friendName);
            }
        });
        dialog.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                refusePlayReq(friendName);
            }
        });
        if(active){
            dialog.show();
            mp.start();
        }
    }

    public void acceptPlayReq(final String friendName){
        reqRef = database.getReference("players/" + playerName + "/requests/" + friendName);
        reqRef.setValue("1").addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                Toast.makeText(getApplicationContext(),"تم إرسال الموافقة",Toast.LENGTH_SHORT).show();
                joinRoom(friendName);
            }
        });
    }

    public void refusePlayReq(String friendName){
        reqRef = database.getReference("players/" + playerName + "/requests/" + friendName);
        reqRef.setValue("0").addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                Toast.makeText(getApplicationContext(),"تم إرسال الرفض",Toast.LENGTH_SHORT).show();
            }
        });
    }

    public void joinRoom(String friendName){
        roomName = friendName + "Room";
        pointsRef = database.getReference("rooms/" + roomName + "/points/" + playerName);
        pointsRef.setValue(0);
        Intent intent = new Intent(OnlinePage.this,MainActivity3.class);
        intent.putExtra("roomName" , roomName);
        flag = '1';
        startActivity(intent);
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
    public void onBackPressed() {
        super.onBackPressed();
        flag = '1';
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
    protected void onStart() {
        super.onStart();
        active = true;
        setOnLine();
    }

    @Override
    public void onStop() {
        super.onStop();
        active = false;
    }

    private void addOnlineEventListener(){
        playerRef = database.getReference("players/"+ playerName + "/online");
        playerRef.addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                System.out.println("snapshot.toString() : " + snapshot.toString());
                if (snapshot.getValue() != null) {
                    if ((long) snapshot.getValue() == 1) {
                        Toast.makeText(getApplicationContext(), "ONLINE", Toast.LENGTH_SHORT).show();
                    } else {
                        Toast.makeText(getApplicationContext(), "OFFLINE", Toast.LENGTH_SHORT).show();
                    }
                }
            }
            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                Toast.makeText(getApplicationContext(), error.getMessage() , Toast.LENGTH_SHORT).show();

            }
        });
    }

}