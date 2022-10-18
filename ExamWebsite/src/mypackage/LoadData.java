package mypackage;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.HashMap;

public class LoadData {

	Connection con = null;
	Statement Stmt = null;
	ResultSet RS = null;
	
	public LoadData () {
		try {
		con = DriverManager.getConnection("jdbc:mysql://localhost:3333/termproject", "Abdallah",
				"el7mdullah$1921999");
		Stmt = con.createStatement();
		} catch (Exception e1) {
			System.out.println(e1.getMessage().toString());
		}
	}

	ArrayList<String> ET = new ArrayList<String>();
//	ArrayList<String> Q = new ArrayList<String>();
//	ArrayList<String> allA = new ArrayList<String>();
	HashMap<String, String> Qes = new HashMap<>();
	HashMap<String, String> Ans = new HashMap<>();

	public ArrayList<String> Exam_of_cand(String cid) {

		try {
			con = DriverManager.getConnection("jdbc:mysql://localhost:3333/termproject", "Abdallah",
					"el7mdullah$1921999");
			Stmt = con.createStatement();
			RS = Stmt.executeQuery(" select (ExamType) from hr_exam where (CID)=" + "\"" + cid + "\"" + " and (done) ="
					+ 0 + " ORDER BY (ExamOrder) ASC;");
			while (RS.next()) {
				ET.add(RS.getString("ExamType").toString());
			}

			RS.close();

		} catch (Exception e1) {
			System.out.println(e1.getMessage().toString());
		}
		return ET;

	}

	public HashMap<String, String> Random_Ques_of_exam(String Exam) {

		try {
			Qes = new HashMap<>();
			con = DriverManager.getConnection("jdbc:mysql://localhost:3333/termproject", "Abdallah",
					"el7mdullah$1921999");
			Stmt = con.createStatement();
			RS = Stmt.executeQuery(" select * from question where (ExamType)=" + "\"" + Exam + "\"" + ""
					+ " ORDER BY RAND()" + " LIMIT 3 ;");
			while (RS.next()) {
				Qes.put(RS.getString("QID").toString(), RS.getString("Qtext").toString());
				System.out.println(Qes);
			}
			for ( String key : Qes.keySet() ) {
			    System.out.println( key );
			}
			RS.close();
		} catch (Exception e1) {
			System.out.println(e1.getMessage().toString());
		}
		return Qes;

	}

	public HashMap<String, String> Ans_of_Qes(String QID) {
		try {
			Ans = new HashMap<>();
			con = DriverManager.getConnection("jdbc:mysql://localhost:3333/termproject", "Abdallah",
					"el7mdullah$1921999");
			Stmt = con.createStatement();
			RS = Stmt.executeQuery(" select * from answer where (QID) = " + QID + " and (CorrectOrNot) IS true "
					+ " ORDER BY RAND() ;");
			if (RS.next()) { // "if" ; because that's one correct answer
				Ans.put(RS.getString("AID").toString(), RS.getString("Atext").toString());
			}
			RS.close();
			RS = Stmt.executeQuery(" select * from answer where (QID) = " + QID + " and (CorrectOrNot) IS false "
					+ " ORDER BY RAND()" + " LIMIT 3 ;");
			while (RS.next()) {// "while" ; because that's three incorrect answers
				Ans.put(RS.getString("AID").toString(), RS.getString("Atext").toString());
				System.out.println(Ans);

			}
			for ( String key : Ans.keySet() ) {
			    System.out.println( key );
			}

		} catch (Exception e1) {
			System.out.println(e1.getMessage().toString());
		}
		return Ans;
	}

}
