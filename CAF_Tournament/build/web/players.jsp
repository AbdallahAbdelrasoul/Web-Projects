<%@page import="java.util.Calendar"%>
<%@page import="mvc.model.Objects.Player"%>
<%@page import="mvc.model.Objects.Country"%>
<%@page import="mvc.controller.DataLayer"%>
<%@page import="mvc.controller.selectPlayers"%>
<%@page import="java.util.ArrayList"%>
<%@page import="javax.websocket.Session"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
    <head>
        <title>PLAYERS</title>
        <link rel="stylesheet" type="text/css" href="myStyle.css"/>
        <script type="application/javascript" src="myJavaScript.js"></script>
    </head>

    <body id="Playerbody">
        <div id="divbar">
            <input type="button" id="playerhomebtn" value="Home" onclick="toHomePage();" style="font-weight: 100"/>      
        </div>

        <div class="div1"x>
            <h1 id="H1"> Players </h1>
        </div>
        <center><div id="divSelect">
                <form method="get" action="selectPlayers">
                    <label id="lb"> TEAM ID : </label>
                    <input id="playerbtn" type="text"  name="team_id"/>
                    <input id="playerSearch" type="submit" value="Search"/> 
                </form>
            </div> <br><br>
        <div class="div2">
            <table id="t1players">
                <tr>
                    <th>Player ID</th>
                    <th>NAME</th>
                    <th>POSITION</th>
                    <th>AGE</th>

                </tr>
                <%
                    if (session.getAttribute("PlayersData") != null) {
                        ArrayList<Player> players = (ArrayList<Player>) session.getAttribute("PlayersData");
                        for (int i = 0; i < players.size(); i++) {
                %> 
                <tr>
                    <td><%= players.get(i).getId() %></td>
                    <td><%= players.get(i).getName() %></td>
                    <td><%= players.get(i).getPosition() %></td>
                    <% int year = Calendar.getInstance().get(Calendar.YEAR);%>
                    <td><%= year - Integer.parseInt(players.get(i).getDOF()) %></td>
                </tr> 
                <%
                        }
                    }
                %>
            </table>
        </div></center>
    </body>
</html>