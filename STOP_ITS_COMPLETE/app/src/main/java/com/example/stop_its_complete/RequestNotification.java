package com.example.stop_its_complete;

import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.net.Uri;

import androidx.core.app.NotificationCompat;

public class RequestNotification {
    Uri soundUri ;

    public void setAlarm(Context context, String friendName){
        soundUri = Uri.parse("android.resource://" + context.getPackageName() + "/" + R.raw.notification_sound);

        Intent intent = new Intent(context, OnlinePage.class);
        PendingIntent pendingIntent = PendingIntent.getActivity(context ,
                0 , intent,Intent.FILL_IN_ACTION);

        NotificationCompat.Builder builder = new NotificationCompat.Builder(context);
        builder.setSmallIcon(R.mipmap.ic_launcher);
        builder.setContentTitle(" PLAY REQUEST...");
        builder.setContentText(friendName + " send you a request !");
        builder.setVibrate(new long[] {100,200,300});
        builder.setSound(soundUri);
        builder.setAutoCancel(true);
        builder.setContentIntent(pendingIntent);
        NotificationManager NM = (NotificationManager) context.getSystemService(Context.NOTIFICATION_SERVICE);
        NM.notify(0, builder.build());
    }

}
