package mvc.controller;

import java.sql.*;
import java.util.ArrayList;
import mvc.model.Objects.Country;
import mvc.model.Objects.Goal;
import mvc.model.Objects.Player;
import mvc.model.Objects.Team;
import mvc.model.Utilities.DBconnect;
     

public class DataLayer {

	Connection con = null;
	Statement Stmt = null;
	ResultSet RS = null;
        DBconnect dbCon = new DBconnect();        
        
	public DataLayer () {
		try {
                    con = dbCon.createConnection();           
                    Stmt = con.createStatement();
                    System.out.println("LoadData constructor!! ");
		} catch (SQLException e1) {
			System.out.println(e1.getMessage());
		}
	}

       
	public ArrayList<Country> selectAllCountries() {
            
            ArrayList<Country> CountryData = new ArrayList<>();
            
            try {
                        boolean found = false ;
			RS = Stmt.executeQuery("SELECT * FROM caf.country");
			while (RS.next()) {
                            Country country = new Country();
                            found = true ;
                            System.out.println("there is countries :D ");
                            System.out.println(RS.getString("name"));
                            country.setName(RS.getString("name"));
                            country.setCapital(RS.getString("Capital"));
                            country.setTeamId(RS.getString("team_id"));
                            CountryData.add(country);
                        }
			RS.close();
                        if(!found){
                            System.out.println("there is Nooooo countries ! :( ");
                        }
		} catch (SQLException e1) {
			System.out.println("SQl Exception on selectCountries " + e1.getMessage());
		} 
		return CountryData;

	}
	public ArrayList<Country> selectCountry(String team_id) {
            
            ArrayList<Country> CountryData = new ArrayList<>();
            
            try {
                        boolean found = false ;
			RS = Stmt.executeQuery("SELECT * FROM caf.country where team_id = '"+ team_id +"';" );
			while (RS.next()) {
                            Country country = new Country();
                            found = true ;
                            System.out.println("there is countries :D ");
                            System.out.println(RS.getString("name"));
                            country.setName(RS.getString("name"));
                            country.setCapital(RS.getString("Capital"));
                            country.setTeamId(RS.getString("team_id"));
                            CountryData.add(country);
                        }
			RS.close();
                        if(!found){
                            System.out.println("there is Nooooo countries ! :( ");
                        }
		} catch (SQLException e1) {
			System.out.println("SQl Exception on selectCountries " + e1.getMessage());
		} 
		return CountryData;

	}
        
        public ArrayList<Team> selectTeams(String team_id) {
             ArrayList<Team> TeamData = new ArrayList<>();
                try {
                    Team team = new Team();
                        boolean found = false ;                            
			RS = Stmt.executeQuery("SELECT * FROM caf.team where team_id = '"+ team_id +"'" );
			while (RS.next()) {
                            found = true ;
                            System.out.println("there is team :D ");
                            team.setId(team_id);
                            team.setName(RS.getString("name"));
                            team.setCoach(RS.getString("coach"));
                            team.setNOGP(RS.getString("number_of_games_played"));
                            team.setPoints(RS.getString("points"));
                            team.setGD(RS.getString("goal_difference"));
                            
                            TeamData.add(team);
			}
			RS.close();
                        if(!found){
                            System.out.println("there is Nooooo team :( !");
                        }
		} catch (SQLException e1) {
			System.out.println("SQl Exception on selectTeam  " + e1.getMessage());
		} 
		return TeamData;
	}
        
        public ArrayList<Team> TeamStandings() {
             ArrayList<Team> TeamData = new ArrayList<>();
                try {
                        boolean found = false ;                            
			RS = Stmt.executeQuery("SELECT * FROM caf.team ORDER BY  CAST(points AS SIGNED) desc, CAST(goal_difference AS SIGNED) desc" );
			while (RS.next()) {
                            Team team = new Team();
                            found = true ;
                            System.out.println("there is team :D ");
                            team.setId(RS.getString("team_id"));
                            team.setName(RS.getString("name"));
                            team.setCoach(RS.getString("coach"));
                            team.setNOGP(RS.getString("number_of_games_played"));
                            team.setPoints(RS.getString("points"));
                            team.setGD(RS.getString("goal_difference"));
                            
                            TeamData.add(team);
			}
			RS.close();
                        if(!found){
                            System.out.println("there is Nooooo team :( !");
                        }
		} catch (SQLException e1) {
			System.out.println("SQl Exception on selectTeam  " + e1.getMessage());
		} 
		return TeamData;
	}

       
        public ArrayList<Player> selectPlayer(String team_id) {
             ArrayList<Player> PlayerData = new ArrayList<>();
                try {
                        boolean found = false ;                            
			RS = Stmt.executeQuery("SELECT * FROM caf.player where team_id = '"+ team_id +"';" );
			while (RS.next()) {
                            Player player = new Player();
                            found = true ;
                            System.out.println("there is player :D ");
                            System.out.println(RS.getString("name"));
                            player.setName(RS.getString("name"));
                            player.setId(RS.getString("player_id"));
                            player.setPosition(RS.getString("position"));
                            player.setDOF(RS.getString("date_of_birth"));

                            PlayerData.add(player);
                        }
			RS.close();
                        if(!found){
                            System.out.println("there is Nooooo players ! :( ");
                        }
		} catch (SQLException e1) {
			System.out.println("SQl Exception on SelectPlayer " + e1.getMessage());
		} 
		return PlayerData;

	}
        
       public int insertPlayer(Player player){
            int done = 0 ;
            try {
			done = Stmt.executeUpdate("Insert into caf.player values('"+player.getId()+"','"+player.getTeamId()+"','"
                                + player.getName() + "','"+player.getPosition() +"','" + player.getDOF() +"');" ) ;
                        
                        if(done == 0){
                            System.out.println("there is problem in Insert new Player ! :( ");
                        }
		} catch (SQLException e1) {
			System.out.println("SQl Exception on insertPlayer " + e1.getMessage());
		}
           return done;
       }
            
       public int insertGoal(Goal goal){
           int done = 0 ;
            try {
                    done = Stmt.executeUpdate("Insert into caf.goals values('"+goal.getPlayerId()+"','"+goal.getTeamId()+"','"
                            + goal.getDate()+ "','"+goal.getTime()+"');" ) ;

                    if(done == 0){
                        System.out.println("there is problem in Insert new Goal ! :( ");
                    }
		} catch (SQLException e1) {
			System.out.println("SQl Exception on InsertGoal " + e1.getMessage());
		}
           return done;
       }
}