package com.example.stop_its_complete;

import androidx.annotation.NonNull;
import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.NotificationCompat;

import android.app.AlertDialog;
import android.app.Notification;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Build;
import android.os.Bundle;
import android.view.Menu;
import android.view.View;
import android.widget.Toast;

import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

public class HomePage extends AppCompatActivity {

    char flag;
    FirebaseDatabase database ;
    DatabaseReference playerRef, reqRef, pointsRef ;
    SharedPreferences preferences ;

    String playerName, roomName, friendName;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home_page);

        flag = '\0';
        database = FirebaseDatabase.getInstance();
        preferences = getSharedPreferences("PREFS" , 0);
        playerName = preferences.getString("playerName",""); // that is written using editor

        setOnLine();
        receivePlayRequest();
    }

    public void toRoomPage(View v){
        Intent intent = new Intent(this, MainActivity2.class);
        flag = '1';
        startActivity(intent);
    }

    public void toOnlinePage(View v){
        Intent intent = new Intent(this, OnlinePage.class);
        flag = '1';
        startActivity(intent);
    }

    public void exit(View v){
        flag = '\0';
        finishAffinity();
    }


    public void setOffline(){
        playerRef = database.getReference("players/"+ playerName + "/online");
        playerRef.setValue(0);
        addOnlineEventListener();
    }

    public void setOnLine(){
        playerRef = database.getReference("players/"+ playerName + "/online");
        playerRef.setValue(1);
        addOnlineEventListener();
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
                Toast.makeText(getApplicationContext(), error.getMessage() , Toast.LENGTH_SHORT).show();

            }
        });
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
                        requestNotification.setAlarm(HomePage.this,friendName);
                    }
                }
            }
        }

        @Override
        public void onCancelled(@NonNull DatabaseError error) {

        }
    };

    @Override
    public void onBackPressed() {
        super.onBackPressed();
        flag = '\0';
        finishAffinity();
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
        flag = '\0';
    }
}