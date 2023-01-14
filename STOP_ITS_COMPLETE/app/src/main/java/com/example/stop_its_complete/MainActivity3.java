package com.example.stop_its_complete;

import android.Manifest;
import android.annotation.SuppressLint;
import android.app.ActionBar;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.media.MediaPlayer;
import android.media.MediaRecorder;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.util.Log;
import android.view.MotionEvent;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.HorizontalScrollView;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.annotation.RequiresApi;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.core.content.PermissionChecker;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;

import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.MutableData;
import com.google.firebase.database.Query;
import com.google.firebase.database.Transaction;
import com.google.firebase.database.ValueEventListener;
import com.google.firebase.storage.FirebaseStorage;
import com.google.firebase.storage.StorageReference;
import com.google.firebase.storage.UploadTask;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Random;

import static android.content.pm.PackageManager.PERMISSION_GRANTED;

public class MainActivity3 extends AppCompatActivity {

    static boolean active = false;

    Switch aSwitch;
    char flag;
    Random rnd;
    int randomNumber, playerPoints;
    long PlayerRoomPoints;

    ListView totalsView;
    RadioGroup r, r1, r2, r3, r4, r5, r6, r7;
    RadioButton rA, rE;
    Button chooseBtn, compBtn, sumBtn ,rec_btn;
    String playerName, roomName, role, msg = "", myPoints;
    EditText et1, et2, et3, et4, et5, et6, et7;
    TextView mySum, myName;
    LinearLayout myVerLinear, myHorLinear, myScreen ;
    HorizontalScrollView hsv ;

    List<String> totalList;
    List<String> playersList;
    List<String> players_inRoomList;
    List<String> readyList;

    SharedPreferences preferences;

    FirebaseDatabase database;
    DatabaseReference playerRef, roomRef, stopRef, msgRef, pointsRef, reqRef, roomPlayerRef, voiceRef;

    FirebaseStorage storage;
    StorageReference storageRef;

    MediaPlayer mpNotif, mpStart,mpStop,start_req_sound,stop_req_sound ,exist_sound;

    private MediaRecorder recorder;
    private String fileName = null ;
    private static final String LOG_TAG = "Record_log";
    ProgressDialog uploadProg;
    private static final int REQUEST_RECORD_AUDIO_PERMISSION = 200;

    // for Marchemillo Or Higher ; Because Lollipop and lower is Already GRANTED in Intstallation
    @Override
        public void onRequestPermissionsResult(int requestCode, @NonNull String[] permissions, @NonNull int[] grantResults) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults);
        if (requestCode == REQUEST_RECORD_AUDIO_PERMISSION) {
            if (grantResults[0] == PERMISSION_GRANTED) {
                //rec_btn.setEnabled(true);
            }else{
                //rec_btn.setEnabled(false);
            }
        }
    }
    @Override
    protected void onStart() {
        super.onStart();
        receivePlayRequest();
        active = true;
    }
    @Override
    protected void onResume() {
        super.onResume();
        active = true;
    }

    @SuppressLint("ClickableViewAccessibility")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main3);
        mpNotif = MediaPlayer.create(this, R.raw.notification_sound);
        mpStart = MediaPlayer.create(this, R.raw.win_level_up);
        mpStop = MediaPlayer.create(this, R.raw.stop_sound);
        start_req_sound = MediaPlayer.create(this, R.raw.start_record_sound);
        stop_req_sound = MediaPlayer.create(this, R.raw.stop_record_sound);
        exist_sound = MediaPlayer.create(this, R.raw.exist_sound);

        fileName = Environment.getExternalStorageDirectory().getAbsolutePath();
        fileName += "/recorded_audio.mp3";
        rec_btn = findViewById(R.id.rec_button);

        rec_btn.setOnLongClickListener(new View.OnLongClickListener() {
            @Override
            public boolean onLongClick(View v) {
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                    if (ContextCompat.checkSelfPermission(getApplicationContext(),
                            Manifest.permission.RECORD_AUDIO) == PERMISSION_GRANTED &&
                        ContextCompat.checkSelfPermission(getApplicationContext(),
                                Manifest.permission.WRITE_EXTERNAL_STORAGE) == PERMISSION_GRANTED) {
                        // put your code for Version>=Marshmallow
                        startRecording();
                        rec_btn.setCompoundDrawablesWithIntrinsicBounds(0, R.drawable.record_on,0,0);

                    } else {
                        if (shouldShowRequestPermissionRationale(Manifest.permission.RECORD_AUDIO)) {
                            Toast.makeText(getApplicationContext(),
                                    "App required access to audio \n" +
                                            "Settings -> App Management -> App Permissions", Toast.LENGTH_SHORT).show();
                        }
                        requestPermissions(new String[]{Manifest.permission.RECORD_AUDIO,Manifest.permission.WRITE_EXTERNAL_STORAGE
                        }, REQUEST_RECORD_AUDIO_PERMISSION);
                    }

                }
                else {
                    // put your code for Version < Marshmallow
                    // LOLLIPOP
                     startRecording();
                     rec_btn.setCompoundDrawablesWithIntrinsicBounds(0, R.drawable.record_on,0,0);
                }
                return false;
            }
        });

        rec_btn.setOnTouchListener(new View.OnTouchListener() {
            @Override
            public boolean onTouch(View v, MotionEvent event) {
                if(event.getAction() == MotionEvent.ACTION_BUTTON_PRESS){
                    Toast.makeText(getApplicationContext(), "أستمر في الضغط للتحدث !",Toast.LENGTH_SHORT).show();
                }
                if (event.getAction() == MotionEvent.ACTION_UP ){
                    stopRecording();
                  rec_btn.setCompoundDrawablesWithIntrinsicBounds(0, R.drawable.record_off,0,0);
                }
                return false;
            }
        });
        uploadProg = new ProgressDialog(this);
        database = FirebaseDatabase.getInstance();
        storage = FirebaseStorage.getInstance();

        hsv = findViewById(R.id.horscrollview);
        myVerLinear = findViewById(R.id.myLinear);
        myHorLinear = findViewById(R.id.myHorLinear);
        myScreen = findViewById(R.id.myScreen);
        //Ready! switch
        aSwitch = findViewById(R.id.switch1);

        flag = '\0';

        rnd = new Random();
        r = findViewById(R.id.languages);

        totalsView = findViewById(R.id.totals);
        totalList = new ArrayList<>();
        playersList = new ArrayList<>();
        players_inRoomList = new ArrayList<>();
        readyList = new ArrayList<>();


        et1 = findViewById(R.id.editText1);
        et2 = findViewById(R.id.editText2);
        et3 = findViewById(R.id.editText3);
        et4 = findViewById(R.id.editText4);
        et5 = findViewById(R.id.editText5);
        et6 = findViewById(R.id.editText6);
        et7 = findViewById(R.id.editText7);

        r1 = findViewById(R.id.rdgroup_zero);
        r2 = findViewById(R.id.rdgroup_one);
        r3 = findViewById(R.id.rdgroup_two);
        r4 = findViewById(R.id.rdgroup_three);
        r5 = findViewById(R.id.rdgroup_four);
        r6 = findViewById(R.id.rdgroup_five);
        r7 = findViewById(R.id.rdgroup_six);

        rA = findViewById(R.id.radioButtonA);
        rA.setChecked(true);
        rE = findViewById(R.id.radioButtonE);

        chooseBtn = findViewById(R.id.button2);
        compBtn = findViewById(R.id.button3);
        sumBtn = findViewById(R.id.button4);
        sumBtn.setVisibility(View.INVISIBLE);

        mySum = findViewById(R.id.textView20);
        getRoomPoints(); // set PlayerRoomPoints
        System.out.println("PlayerRoomPoints ======= " + PlayerRoomPoints);
        mySum.setText(String.valueOf(PlayerRoomPoints));

        preferences = getSharedPreferences("PREFS", 0);
        playerName = preferences.getString("playerName", ""); // that is written using editor
        myName = findViewById(R.id.textView);
        myName.setText(playerName);

        playerPoints = preferences.getInt("playerPoints", 0);
        System.out.println("playerPoints :::: " + playerPoints);

        // get roomName () :-
        Bundle extras = getIntent().getExtras();
        if (extras != null) {
            roomName = extras.getString("roomName");
            if (roomName.equals(playerName + "Room")) {
                role = "host";
            } else {
                role = "guest";
            }
        }
        storageRef = FirebaseStorage.getInstance().getReference(roomName + "Images");

        //Set that i'am in the room
        playerRef = database.getReference("rooms/" + roomName + "/roomPlayers/" + playerName);
        playerRef.setValue("here");

        chooseBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (aSwitch.isChecked()) {
                    chooseCharProcess();
                } else {
                    Toast.makeText(getApplicationContext(), "You are Not Ready!", Toast.LENGTH_SHORT).show();
                }
            }
        });

        // Listen for Incoming messages (~~~)
        msgRef = database.getReference("rooms/" + roomName + "/message");
        addMsgEventListener();

        // Listen for Stop!
        stopRef = database.getReference("rooms/" + roomName + "/stop");
        sayStopEventListener();

        // Listen for Incoming scores (###));
        addPointsEventListener();

        aSwitch.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if (isChecked) {
                    database.getReference("rooms/" + roomName + "/readyPlayers/" + playerName).setValue("");
                } else {
                    database.getReference("rooms/" + roomName + "/readyPlayers/" + playerName).removeValue();
                }

            }
        });

        getPlayerList();
        getReadyList();

        voiceEventListener();
    }

    private void startRecording() {
        try {
            recorder = new MediaRecorder();
            recorder.setAudioSource(MediaRecorder.AudioSource.MIC);
            recorder.setOutputFormat(MediaRecorder.OutputFormat.THREE_GPP);
            recorder.setOutputFile(fileName);
            recorder.setAudioEncoder(MediaRecorder.AudioEncoder.AMR_NB);

            recorder.prepare();
            recorder.start();
            start_req_sound.start();
            Toast.makeText(getApplicationContext(), "Recording Started",Toast.LENGTH_SHORT).show();

        } catch (IOException e) {
            Log.e(LOG_TAG, e.getMessage() +"\nprepare() failed");
        }

    }

    private void stopRecording() {
        try {
            stop_req_sound.start();
            recorder.stop();
            recorder.release();
            recorder = null;
            Toast.makeText(getApplicationContext(), "Recording Stopped",Toast.LENGTH_SHORT).show();

            uploadAudio();
        } catch (Exception e) {
            Log.e(LOG_TAG, e.getMessage() +"\nstopRecording() failed");
            Toast.makeText(getApplicationContext(),"Hold to record, release to send",Toast.LENGTH_SHORT).show();
        }
    }

    private void uploadAudio() {
        uploadProg.setMessage("Uploading Voice ...");
        uploadProg.show();
        storageRef = FirebaseStorage.getInstance().getReference(roomName + "Audios");
        StorageReference audioRef = storageRef.child(playerName + "new_audio.mp3");

        Uri uri = Uri.fromFile(new File(fileName));

        audioRef.putFile(uri).addOnSuccessListener(new OnSuccessListener<UploadTask.TaskSnapshot>() {
            @Override
            public void onSuccess(UploadTask.TaskSnapshot taskSnapshot) {
                uploadProg.setMessage("Uploading Voice Finished");
                uploadProg.dismiss();

                taskSnapshot.getStorage().getDownloadUrl().addOnSuccessListener(new OnSuccessListener<Uri>() {
                    @Override
                    public void onSuccess(Uri uri) {
                        voiceRef = database.getReference("rooms/" + roomName + "/Audios");
                        voiceRef.setValue(uri.toString());
                    }
                });
            }
        });

    }

    private void voiceEventListener() {
        voiceRef = database.getReference("rooms/" + roomName + "/Audios");
        voiceRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                if (snapshot.getValue() != null && !snapshot.getValue().equals("")) {
                    MediaPlayer mediaPlayer = new MediaPlayer();
                    try {
                        mediaPlayer.setDataSource(snapshot.getValue().toString());
                        mediaPlayer.setOnPreparedListener(new MediaPlayer.OnPreparedListener() {
                            @Override
                            public void onPrepared(MediaPlayer mp) {
                                mp.start();
                            }
                        });
                        mediaPlayer.prepare();
                    } catch (IOException e) {
                        e.printStackTrace();
                    }
                }

            }
            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    // when back to room
    private void getRoomPoints() {
        Query query = FirebaseDatabase.getInstance().getReference("rooms");
        query.addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                System.out.println("THE SNAPSHOT_ : " + snapshot);
                Iterable<DataSnapshot> rooms = snapshot.getChildren();
                for (DataSnapshot snapshot1 : rooms) {
                    if (snapshot1.child("points").child(playerName).getValue() != null) {
                        if (!snapshot1.child("points").child(playerName).getValue().equals("")) {
                            PlayerRoomPoints = (long) snapshot1.child("points").child(playerName).getValue();
                            pointsRef = database.getReference("rooms/" + roomName + "/points/" + playerName);
                            pointsRef.setValue(PlayerRoomPoints);
                        } else {
                            PlayerRoomPoints = 0;
                            pointsRef = database.getReference("rooms/" + roomName + "/points/" + playerName);
                            pointsRef.setValue(PlayerRoomPoints);
                        }
                    } else {
                        PlayerRoomPoints = 0;
                        pointsRef = database.getReference("rooms/" + roomName + "/points/" + playerName);
                        pointsRef.setValue(PlayerRoomPoints);
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                if(!error.getMessage().equals(""))
                    Toast.makeText(getApplicationContext(), error.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }

    public void receivePlayRequest() {
        reqRef = database.getReference("rooms/" + roomName + "/requests");
        reqRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                System.out.println("receivePlayRequest snapshot: " + snapshot);
                if (snapshot.getKey() != null && snapshot.getValue() != null) {
                    Iterable<DataSnapshot> players = snapshot.getChildren();
                    for (DataSnapshot snapshot1 : players) {
                        String friendName = snapshot1.getKey();
                        System.out.println("FRINDDDD NAMEEE : " +friendName);
                        System.out.println("snapshot1.getValue()  : " + snapshot1.getValue());
                        if (!friendName.equals(playerName))
                            if(snapshot1.getValue() == null || snapshot1.getValue().equals("") && active ) {
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

    public void acceptPlayReq(final String friendName){
        reqRef = database.getReference("rooms/" + roomName + "/requests/" + friendName);
        reqRef.setValue("1").addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                Toast.makeText(getApplicationContext(),"تم إرسال الموافقة",Toast.LENGTH_SHORT).show();
            }
        });
    }

    public void refusePlayReq(String friendName){
        reqRef = database.getReference("rooms/" + roomName + "/requests/" + friendName);
        reqRef.setValue("0").addOnSuccessListener(new OnSuccessListener<Void>() {
            @Override
            public void onSuccess(Void aVoid) {
                Toast.makeText(getApplicationContext(),"تم إرسال الرفض",Toast.LENGTH_SHORT).show();
            }
        });
    }

    void showDialog(final String friendName) {
        android.app.AlertDialog.Builder dialog = new AlertDialog.Builder(MainActivity3.this);
        dialog.setTitle("Join Request...");
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
            mpNotif.start();
        }
    }

    // on Message
    private void addMsgEventListener() {
        msgRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                // Message Received
                if (snapshot.getValue(String.class) != null) {
                    chooseBtn.setText(snapshot.getValue(String.class));
                    mpStart.start();
                    startAction();
                    stopRef.setValue("");
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
            }
        });
    }

    // on Say Stop !
    private void sayStopEventListener() {
        stopRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                if (snapshot.getValue() != null && !snapshot.getValue().equals("")) {
                    mpStop.start();
                    Toast.makeText(getApplicationContext(), snapshot.getValue().toString() + " Say : STOP IT'S COMPLETE !!!", Toast.LENGTH_SHORT).show();
                    shareMyScreen();
                    stopAction();
                    getPlayerList();
                    downloadScreens();
                    aSwitch.setChecked(false);
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                if(!error.getMessage().equals(""))
                 Toast.makeText(MainActivity3.this, error.getMessage(), Toast.LENGTH_SHORT).show();

            }
        });
    }

    private void stopAction() {
        et1.setEnabled(false);
        et2.setEnabled(false);
        et3.setEnabled(false);
        et4.setEnabled(false);
        et5.setEnabled(false);
        et6.setEnabled(false);
        et7.setEnabled(false);

        compBtn.setVisibility(View.INVISIBLE);
        sumBtn.setVisibility(View.VISIBLE);

    }

    // get playersPoints
    private void addPointsEventListener() {
        roomPlayerRef = database.getReference("rooms/" + roomName + "/roomPlayers");
        roomPlayerRef.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
//                System.out.println("roomPlayers : " + snapshot.getValue().toString());
                playersList.clear();
                final Iterable<DataSnapshot> roomplayers = snapshot.getChildren();
                for (DataSnapshot snapshot1 : roomplayers) {
                    if (snapshot1.getValue().equals("here")) {
                        playersList.add(snapshot1.getKey());
                    }
                    else if(snapshot1.getValue().equals("left")) {
                        exist_sound.start();
                        if (snapshot1.getKey().equals(playerName)){
                            flag = '1';
                            finish();
                        }else{
                            Toast.makeText(getApplicationContext(), snapshot1.getKey() +  " ُExist Room!" ,Toast.LENGTH_SHORT).show();
                        }
                    }
                }
                if (playersList.size() == 0) {
                    roomRef = database.getReference("rooms/" + roomName);
                    roomRef.runTransaction(new Transaction.Handler() {
                        @NonNull
                        @Override
                        public Transaction.Result doTransaction(@NonNull MutableData currentData) {
                            roomRef.removeValue();
                            return Transaction.success(currentData);
                        }

                        @Override
                        public void onComplete(@Nullable DatabaseError error, boolean committed, @Nullable DataSnapshot currentData) {
                            if (!committed) {
                                Toast.makeText(getApplicationContext(), error.getDetails(), Toast.LENGTH_SHORT).show();
                            }
                        }
                    });
                }
                Query query = FirebaseDatabase.getInstance().getReference("rooms/" + roomName + "/points")
                        .orderByValue();// Default Ascending
                query.addValueEventListener(new ValueEventListener() {
                    @Override
                    public void onDataChange(@NonNull DataSnapshot snapshot) {
                        totalList.clear();
//                        System.out.println("After Sorting : " + snapshot.getValue().toString());
                        Iterable<DataSnapshot> players = snapshot.getChildren();
                        for (DataSnapshot snapshot1 : players) {
                            if (!snapshot1.getValue().equals("") && playersList.contains(snapshot1.getKey())) {
                                totalList.add(snapshot1.getKey() + " : " + snapshot1.getValue());
                            }
                            if (snapshot1.getKey().equals(playerName)) {
                                myPoints = snapshot1.getValue().toString();
                                mySum.setText(myPoints);
                            }
                        }
                        Collections.reverse(totalList); // to be Descending
                        System.out.println("totalList : \n " + totalList);
                        ArrayAdapter<String> adapter = new ArrayAdapter<>(MainActivity3.this,
                                android.R.layout.simple_list_item_1, totalList);

                        totalsView.setAdapter(adapter);
                    }

                    @Override
                    public void onCancelled(@NonNull DatabaseError error) {
                        if(!error.getMessage().equals(""))
                             Toast.makeText(MainActivity3.this, error.getMessage(), Toast.LENGTH_SHORT).show();
                    }
                });
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                if(!error.getMessage().equals(""))
                    Toast.makeText(MainActivity3.this, error.getMessage(), Toast.LENGTH_SHORT).show();
            }
        });
    }

    private void chooseCharProcess() {
        getPlayerList();
        getReadyList();
        System.out.println("players_inRoomList : " + players_inRoomList);
        System.out.println("readyList : " + readyList);

        Boolean allIsReady = true;
        List<String> notReady = new ArrayList<>();

        for (int i = 0; i < players_inRoomList.size(); i++) {
            if (!readyList.contains(players_inRoomList.get(i))) {
                allIsReady = false;
                notReady.add(players_inRoomList.get(i));
            }
        }

        System.out.println("NotReadyList : " + notReady);

        if (allIsReady) {
            msg = String.valueOf(getChar());
            msgRef.setValue(msg);
        } else {
            Toast.makeText(getApplicationContext(), notReady.toString() + "\nNot Ready!!", Toast.LENGTH_SHORT).show();
        }

    }

    private void getReadyList() {
        Query query = FirebaseDatabase.getInstance().getReference("rooms/" + roomName + "/readyPlayers");
        query.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                readyList.clear();
                for (DataSnapshot snapshot1 : snapshot.getChildren()) {
                    readyList.add(snapshot1.getKey());
                    System.out.println(snapshot1.getKey() + " is ready @@@");
                }

            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                if(!error.getMessage().equals(""))
                   Toast.makeText(getApplicationContext(), error.getDetails(), Toast.LENGTH_SHORT).show();
            }
        });

    }

    private void getPlayerList() {
        Query query = FirebaseDatabase.getInstance().getReference("rooms/" + roomName + "/roomPlayers");
        query.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                players_inRoomList.clear();
                for (DataSnapshot snapshot1 : snapshot.getChildren()) {
                    players_inRoomList.add(snapshot1.getKey());
                    System.out.println(snapshot1.getKey() + " is inRoom @@@");
                }

            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                if(!error.getMessage().equals(""))
                    Toast.makeText(getApplicationContext(), error.getDetails(), Toast.LENGTH_SHORT).show();
            }
        });
    }

    private char getChar() {
        int rbId = r.getCheckedRadioButtonId();
        RadioButton radioButton = (RadioButton) findViewById(rbId);
        char[] language = radioButton.getText().toString().toCharArray();

        if (language[0] == 'A') {
            randomNumber = 1568 + rnd.nextInt(42); // ARABIC
        } else if (language[0] == 'E') {
            randomNumber = 97 + rnd.nextInt(26); //ENGLISH
        } else {
            Toast.makeText(MainActivity3.this, "Error in getChar()!", Toast.LENGTH_SHORT).show();
        }
        return (char) randomNumber;
    }

    public void startAction() {
        try {
            et1.setEnabled(true);
            et1.setText("");
            et2.setEnabled(true);
            et2.setText("");
            et3.setEnabled(true);
            et3.setText("");
            et4.setEnabled(true);
            et4.setText("");
            et5.setEnabled(true);
            et5.setText("");
            et6.setEnabled(true);
            et6.setText("");
            et7.setEnabled(true);
            et7.setText("");

            r1.clearCheck();
            r2.clearCheck();
            r3.clearCheck();
            r4.clearCheck();
            r5.clearCheck();
            r6.clearCheck();
            r7.clearCheck();

            compBtn.setVisibility((View.VISIBLE));
            sumBtn.setVisibility(View.INVISIBLE);
        } catch (Exception e) {
            Toast.makeText(getApplicationContext(), e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }

    public void calcSum(View v) {
        try {
            int theSum = 0;

            int rbId = r1.getCheckedRadioButtonId();
            RadioButton radioButton = (RadioButton) findViewById(rbId);
            int val = Integer.parseInt(radioButton.getText().toString());
            theSum += val;

            rbId = r2.getCheckedRadioButtonId();
            radioButton = (RadioButton) findViewById(rbId);
            val = Integer.parseInt(radioButton.getText().toString());
            theSum += val;

            rbId = r3.getCheckedRadioButtonId();
            radioButton = (RadioButton) findViewById(rbId);
            val = Integer.parseInt(radioButton.getText().toString());
            theSum += val;

            rbId = r4.getCheckedRadioButtonId();
            radioButton = (RadioButton) findViewById(rbId);
            val = Integer.parseInt(radioButton.getText().toString());
            theSum += val;

            rbId = r5.getCheckedRadioButtonId();
            radioButton = (RadioButton) findViewById(rbId);
            val = Integer.parseInt(radioButton.getText().toString());
            theSum += val;

            rbId = r6.getCheckedRadioButtonId();
            radioButton = (RadioButton) findViewById(rbId);
            val = Integer.parseInt(radioButton.getText().toString());
            theSum += val;

            rbId = r7.getCheckedRadioButtonId();
            radioButton = (RadioButton) findViewById(rbId);
            val = Integer.parseInt(radioButton.getText().toString());
            theSum += val;

            String total = String.valueOf((Integer.parseInt(mySum.getText().toString()) + theSum));

            mySum.setText(total);
            addPointsEventListener();
            updateTotal(total); // of round points
            updateScore(theSum);// of the player Score
            sumBtn.setVisibility(View.INVISIBLE);

            shareMyScreen(); // upload to firebase


        } catch (Exception e) {
            Toast.makeText(getApplicationContext(), e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }

    public void downloadResults(View v) {
        downloadScreens();
    }

    private void downloadScreens() {
        myHorLinear.removeAllViewsInLayout();
        for (String player : players_inRoomList) {
            final ImageView imageView = new ImageView(MainActivity3.this);
            System.out.println("player is : " + player);
            if (!player.equals(playerName)) {
                storageRef = storage.getReference(roomName + "Images/" + player + "Screen.jpg");
                storageRef.getBytes(1024 * 1024).addOnSuccessListener(new OnSuccessListener<byte[]>() {
                    @Override
                    public void onSuccess(byte[] bytes) {
                        Bitmap bitmap = BitmapFactory.decodeByteArray(bytes, 0, bytes.length);
                        imageView.setImageBitmap(Bitmap.createScaledBitmap(
                                bitmap,getWindow().getDecorView().getWidth(),
                                getWindow().getDecorView().getHeight(),false));
                        myHorLinear.addView(imageView);
                        Toast.makeText(getApplicationContext(), "Screens are downloaded!", Toast.LENGTH_SHORT).show();
                    }
                });
            }

        }
    }

    private void updateTotal(String total) {
        try {
            //myRef.child("players").child(playerName).child("points").setValue(total);
            pointsRef = database.getReference("rooms/" + roomName + "/points/" + playerName);
            pointsRef.setValue(Integer.parseInt(total));
        } catch (Exception e) {
            Toast.makeText(getApplicationContext(), e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }

    private void updateScore(int theSum) {
        try {
            int newScore = playerPoints += theSum;
            pointsRef = database.getReference("players/" + playerName + "/points");
            pointsRef.setValue(newScore);
            SharedPreferences preferences = getSharedPreferences("PREFS", 0);
            SharedPreferences.Editor editor = preferences.edit();
            editor.putInt("playerPoints", newScore);
            editor.apply();

        } catch (Exception e) {
            Toast.makeText(getApplicationContext(), e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }

    public void setZero(View v) {
        Toast.makeText(getApplicationContext(), "POINTS : 0", Toast.LENGTH_SHORT).show();
        pointsRef = database.getReference("rooms/" + roomName + "/points/" + playerName);
        pointsRef.setValue(0);
        mySum.setText("0");
    }

    public void compBtn_Click(View v) {
        try {
            stopRef.setValue(playerName);
        } catch (Exception e) {
            Toast.makeText(getApplicationContext(), e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }

    private void shareMyScreen() {

        myScreen.setDrawingCacheEnabled(true);
        Bitmap bitmap = Bitmap.createBitmap(myScreen.getDrawingCache());
        ByteArrayOutputStream baos = new ByteArrayOutputStream();
        bitmap.compress(Bitmap.CompressFormat.JPEG, 100, baos);
        myScreen.setDrawingCacheEnabled(false);
        byte[] data = baos.toByteArray();

        storageRef = FirebaseStorage.getInstance().getReference(roomName + "Images");
        StorageReference imageRef = storageRef.child(playerName + "Screen.jpg");

        UploadTask uploadTask = imageRef.putBytes(data);
        uploadTask.addOnFailureListener(new OnFailureListener() {
            @Override
            public void onFailure(@NonNull Exception exception) {
                Toast.makeText(getApplicationContext(), exception.getMessage(), Toast.LENGTH_SHORT).show();
            }
        }).addOnSuccessListener(new OnSuccessListener<UploadTask.TaskSnapshot>() {
            @Override
            public void onSuccess(UploadTask.TaskSnapshot taskSnapshot) {
                Toast.makeText(getApplicationContext(), taskSnapshot.getMetadata().getName(), Toast.LENGTH_SHORT).show();
            }
        });

    }

    public void exitAction(){
        try {
            stopRef.setValue("");
            roomPlayerRef = database.getReference("rooms/" + roomName + "/roomPlayers/" + playerName);
            roomPlayerRef.setValue("left");
            Toast.makeText(getApplicationContext(),"لقد خرجت من الغرفة !",Toast.LENGTH_SHORT).show();
            Intent intent = new Intent(getApplicationContext(),MainActivity2.class);
            flag = '1';
            startActivity(intent);
            finish();

        }catch (Exception e){
            Toast.makeText(getApplicationContext(), e.getMessage(), Toast.LENGTH_SHORT).show();
        }
    }

    public void inVisImages(View v){
        myHorLinear.removeAllViewsInLayout(); // HorizontalView of ImagesScreens
    }

    @Override
    public void onBackPressed() {
        super.onBackPressed();
        finish();
    }


    public void setOffline(){
        playerRef = database.getReference("players/"+ playerName + "/online");
        playerRef.setValue(0);
        addOnlineEventListener();
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
                if(!error.getMessage().equals(""))
                   Toast.makeText(getApplicationContext(), error.getMessage() , Toast.LENGTH_SHORT).show();
            }
        });
    }

    @Override
    protected void onPause() {
        super.onPause();
        active = false;
    }

    @Override
    protected void onStop() {
        super.onStop();
        if(flag != '1'){
            setOffline();
        }
        active = false;
        // Set Not Ready!
        aSwitch.setChecked(false);
        // leave room
        exitAction();
    }
}