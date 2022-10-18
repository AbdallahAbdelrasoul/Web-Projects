package mypackage;
import java.sql.*;
import java.util.ArrayList;

public class LoadData {

	Connection con = null;
	Statement Stmt = null;
	ResultSet RS = null;
	DBconnect dbCon = new DBconnect();
	
	//DBconnect db = new DBconnect();

	public LoadData () {
		try {
			System.out.println("LoadData constructor!! ");
		} catch (Exception e1) {
			System.out.println(e1.getMessage().toString());
		}
	}

	ArrayList<String> matches = new ArrayList<String>();
	ArrayList<String> players = new ArrayList<String>();

	ArrayList<String> selectMatches(String name) {
		try {
			con = dbCon.createConnection();
			Stmt = con.createStatement();
			RS = Stmt.executeQuery("SELECT * FROM new_schema.newstable");
			while (RS.next()) {
				System.out.println("there si matchesssss");
				matches.add(RS.getString("matches").toString());
			}
			RS.close();
			 
		} catch (SQLException e1) {
			System.out.println("SQl Exception" + e1.getMessage().toString());
		} 
		return matches;

	}


}
