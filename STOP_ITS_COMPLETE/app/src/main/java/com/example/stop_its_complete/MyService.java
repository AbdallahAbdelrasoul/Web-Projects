package com.example.stop_its_complete;

import android.app.Service;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.IBinder;

import androidx.annotation.Nullable;

import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;

public class MyService extends Service {

    FirebaseDatabase database;
    DatabaseReference playerRef;

    String playerName;

    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onTaskRemoved(Intent rootIntent) {
        System.out.println("onTaskRemoved called");
        super.onTaskRemoved(rootIntent);

        //DO WHAT YOU WANT BEFORE APP CLOSE:-
        database = FirebaseDatabase.getInstance();
        SharedPreferences preferences = getSharedPreferences("PREFS" , 0);
        playerName = preferences.getString("playerName","");
        playerRef = database.getReference("players/"+ playerName + "/online");
        // 1- set offline
        playerRef.setValue(0);

        //stop service
        this.stopSelf();
    }


}
