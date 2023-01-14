package com.example.stop_its_complete;

import android.app.Service;
import android.content.Intent;
import android.os.Bundle;
import android.os.IBinder;

import androidx.annotation.Nullable;

import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;

import java.io.BufferedReader;

public class MyService extends Service {

    MainActivity2 mainActivity2; // the Activity is running
    @Nullable
    @Override
    public IBinder onBind(Intent intent) {
        return null;
    }

    @Override
    public void onTaskRemoved(Intent rootIntent) {
        System.out.println("onTaskRemoved called");
        super.onTaskRemoved(rootIntent);
        mainActivity2 = new MainActivity2();
        //DO WHAT YOU WANT BEFORE APP CLOSE:-
        // 1- remove him from the room
        // 2- set him is Offline
        mainActivity2.setOffline();

        //stop service
        this.stopSelf();
    }


}
