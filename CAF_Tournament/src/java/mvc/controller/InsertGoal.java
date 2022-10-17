/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package mvc.controller;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import mvc.model.Objects.Goal;
import mvc.model.Objects.Player;


public class InsertGoal extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        doGet(request, response);

    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
//        processRequest(request, response);
        try {
            DataLayer dl = new DataLayer();
            int done = 0;
            if (request.getParameter("pass") == null) { // When Submit
                System.out.println(" !!! Pass === null !!! ");
                Goal goal = new Goal();
                goal.setPlayerId(request.getParameter("playerid_name"));
                goal.setTeamId(request.getParameter("teamid_name"));
                goal.setDate(request.getParameter("Date"));
                goal.setTime(request.getParameter("Time"));

                done = dl.insertGoal(goal);

                if (done == 1) {
                    System.out.println("Goal is Inserted Into Data base <> ");
                }
                response.sendRedirect("palyerInfo.jsp?done=" + done );

            } else { // When using AJAX :  
                System.out.println(" !!! Pass !=== 0 !!! ");
                try (PrintWriter out = response.getWriter()) {
                    ArrayList<Player> Players = new ArrayList<>();
                    Players = dl.selectPlayer(request.getParameter("pass"));
                    String text = "";

                    for (int i = 0; i < Players.size(); i++) {
                        text += "<option value="+Players.get(i).getId()+">" + Players.get(i).getId() + "</option>";
                    }
                    out.print(text);
                }
            }
        } catch (Exception ex) {
            Logger.getLogger(InsertPlayer.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
//        processRequest(request, response);

    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
