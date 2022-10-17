<%@page import="mvc.model.Objects.Team"%>
<%@page import="mvc.model.Objects.Country"%>
<%@page import="java.util.ArrayList"%>
<%@page import="mvc.controller.DataLayer"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Standings</title>
        <link rel="stylesheet" type="text/css" href="myStyle.css"/>
        <script type="application/javascript" src="myJavaScript.js"></script>
    </head>
    <body id="mybodyStand">
        <div id="divbar">
            <input type="button" id="homebtn" value="Home" onclick="toHomePage();" style="font-weight: 100"/>      
        </div>

        <h1 id="H1stand">Standings</h1>
    <center><div class="div2stand">
            <table id="t1stand">
                <tr>
                    <th>Countries</th>
                    <th>MP</th>
                    <th>Coach</th>
                    <th>GD</th>
                    <th>PTS</th>

                </tr>
                <%
                    DataLayer ld = new DataLayer();
                    ArrayList<Country> countries = new ArrayList<>();
                    ArrayList<Team> Teamsdata = new ArrayList<>();
                    Teamsdata = ld.TeamStandings();
                    for (int i = 0; i < Teamsdata.size(); i++) {
                        countries = ld.selectCountry(Teamsdata.get(i).getId());
                %>
                <tr>
                    <% for (int c = 0; c < countries.size(); c++) {%>
                        <td><%= countries.get(c).getName() %></td>
                        <%}%>
                        <td><%= Teamsdata.get(i).getNOGP() %></td>
                        <td><%= Teamsdata.get(i).getCoach()%></td>
                        <td><%= Teamsdata.get(i).getGD()%></td>
                        <td><%= Teamsdata.get(i).getPoints()%></td>
                </tr>
                <%}%>
            </table>
        </div></center>
</body>
</html>
