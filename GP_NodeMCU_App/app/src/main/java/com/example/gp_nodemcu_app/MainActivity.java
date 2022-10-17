package com.example.gp_nodemcu_app;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;


public class MainActivity extends AppCompatActivity  {

    Button shBtn;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main_activity);
        final Intent smartHomeIntent = new Intent(MainActivity.this, MySmartHome.class);

        shBtn = findViewById(R.id.smarthomeBtn);
        shBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                startActivity(smartHomeIntent);
            }
        });

    }
}
