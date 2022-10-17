/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mvc.model.Objects;


public class Team {
    private String id;
    private String name;
    private String coach;
    private String nogp;
    private String points;
    private String gd;
    public Team() {
        this.id = null;
        this.coach = null;
        this.nogp = null;
        this.points = null;
        this.gd = null;
    }
    public Team(String id, String coach, String nogp , String points , String gd) {
        super();
        this.id = id;
        this.coach = coach;
        this.nogp = nogp;
        this.points = points;
        this.gd = gd;
    }
    public String getId() {
        return id;
    }
    public void setId(String id) {
        this.id = id;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getCoach() {
        return coach;
    }
    public void setCoach(String coach) {
        this.coach = coach;
    }
    public String getNOGP() {
        return nogp;
    }
    public void setNOGP(String NOGP) {
        this.nogp = NOGP;
    }
    public String getPoints() {
        return points;
    }
    public void setPoints(String points) {
        this.points = points;
    }
    public String getGD() {
        return gd;
    }
    public void setGD(String GD) {
        this.gd = GD;
    }
}
