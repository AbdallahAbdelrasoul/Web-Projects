/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mypackage;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

public class DBconnect {
    
    // JDBC driver name and database URL
    private Connection conn;
    static final String JDBC_DRIVER = "com.mysql.jdbc.Driver";  
    static final String DB_URL = "jdbc:mysql://localhost:3306/new_schema";
    // JDBC driver name and database URL
    static final String USER = "abdallah";
    static final String PASS = "m3anayarab-mysql";
   
    public Connection createConnection()
    {
        try {
            Class.forName(JDBC_DRIVER); //loading mysql driver
            System.out.println("Connecting to a selected database...");
            conn = DriverManager.getConnection(DB_URL, USER, PASS); //attempting to connect to MySQL database
            System.out.println("Connected database successfully...");
        } catch (ClassNotFoundException ex) {
            Logger.getLogger(DBconnect.class.getName()).log(Level.SEVERE, null, ex);
        } catch (SQLException ex) {
            Logger.getLogger(DBconnect.class.getName()).log(Level.SEVERE, null, ex);
        }
        
        return conn;
    }
}
