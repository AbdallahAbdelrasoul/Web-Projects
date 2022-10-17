/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mvc.model.Objects;


public class Goal {
    private String player_id;
    private String team_id;
    private String date;
    private String time;
    
    public Goal() {}
    public Goal(String player_id, String team_id, String date, String time) {
        super();
        this.player_id = player_id;
        this.team_id = team_id;
        this.date = date;
        this.time = time;
    }
    public String getPlayerId() {
        return player_id;
    }
    public void setPlayerId(String Playerid) {
        this.player_id = Playerid;
    }
    public String getTeamId() {
        return team_id;
    }
    public void setTeamId(String team_id) {
        this.team_id = team_id;
    }
    public String getDate() {
        return date;
    }
    public void setDate(String Date) {
        this.date = Date;
    }
    public String getTime() {
        return time;
    }
    public void setTime(String Time) {
        this.time = Time;
    }
}
