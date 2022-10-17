/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mvc.model.Objects;


public class Country {
    private String name;
    private String capital;
    private String team_id;
    
    public Country() {
        this.name = null;
        this.capital = null;
        this.team_id = null;
    }

    public Country(String name, String capital, String team_id) {
        super();
        this.name = name;
        this.capital = capital;
        this.team_id = team_id;
    }
    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }
    public String getCapital() {
        return capital;
    }
    public void setCapital(String capital) {
        this.capital = capital;
    }
    public String getTeamId() {
        return team_id;
    }
    public void setTeamId(String team_id) {
        this.team_id = team_id;
    }
}
