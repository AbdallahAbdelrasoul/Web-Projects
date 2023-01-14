package com.example.stop_its_complete;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
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

public class MainActivity extends AppCompatActivity {

    EditText editText ;
    Button button ;

    List<String> playerList ;
    String playerName =  "" ;
    FirebaseDatabase database ;
    DatabaseReference playerRef ;

    private boolean isNetworkAvailable() {
        ConnectivityManager connectivityManager
                = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();
        return activeNetworkInfo != null && activeNetworkInfo.isConnected();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);


        playerList = new ArrayList<>();
        getPlayersNames();

        button = findViewById(R.id.login);
        button.setEnabled(true);

        editText = findViewById(R.id.username);
        database = FirebaseDatabase.getInstance();

        SharedPreferences preferences = getSharedPreferences("PREFS" , 0);
        playerName = preferences.getString("playerName","");
        // had log before
        if(isNetworkAvailable()){
            if(!playerName.equals("")){
                editText.setText(playerName);
                playerRef = database.getReference("players/" + playerName + "/hasAccount");
                playerRef.setValue(1).addOnSuccessListener(new OnSuccessListener<Void>() {
                    @Override
                    public void onSuccess(Void aVoid) {
                        Toast.makeText(getApplicationContext(),"Welcome " + playerName + '!',Toast.LENGTH_SHORT).show();
                        Intent intent = new Intent(getApplicationContext(),HomePage.class);
                        startActivity(intent);
                        finish();
                    }
                });
            }
        }else{
            Toast.makeText(getApplicationContext(),"There is no connection!",Toast.LENGTH_SHORT).show();
        }


        //log First time
        button.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(isNetworkAvailable()){
                    playerName = editText.getText().toString();
                    if (!playerList.equals("") && !playerList.contains(playerName)) {
                        button.setEnabled(false);
                        button.setText("PLEASE WAIT...");
                        SharedPreferences preferences = getSharedPreferences("PREFS", 0);
                        SharedPreferences.Editor editor = preferences.edit();
                        editor.putString("playerName", playerName);
                        editor.apply();
                        playerRef = database.getReference("players/" + playerName + "/hasAccount");
                        playerRef.setValue(1).addOnSuccessListener(new OnSuccessListener<Void>() {
                            @Override
                            public void onSuccess(Void aVoid) {
                                Toast.makeText(getApplicationContext(), "Welcome " + playerName + '!', Toast.LENGTH_SHORT).show();
                                Intent intent = new Intent(getApplicationContext(), HomePage.class);
                                startActivity(intent);
                                finish();
                            }
                        });
                    }else{
                        Toast.makeText(MainActivity.this, "Error!\n!من فضلك ادخل اسم اخر", Toast.LENGTH_SHORT).show();
                        button.setEnabled(true);
                        button.setText("LOGIN");
                    }
                }else{
                    Toast.makeText(getApplicationContext(),"There is no connection!",Toast.LENGTH_SHORT).show();
                }
            }
        });

    }

    private void getPlayersNames (){
        Query query = FirebaseDatabase.getInstance().getReference("players")
                .orderByValue();
        query.addListenerForSingleValueEvent(valueEventListener);
    }
    ValueEventListener valueEventListener = new ValueEventListener() {
        @Override
        public void onDataChange(@NonNull DataSnapshot snapshot) {
            playerList.clear();
            if(snapshot.exists()){
                for(DataSnapshot snapshot1 : snapshot.getChildren()){
                    playerList.add(snapshot1.getKey());
                }
            }
        }

        @Override
        public void onCancelled(@NonNull DatabaseError error) {

        }
    };

}