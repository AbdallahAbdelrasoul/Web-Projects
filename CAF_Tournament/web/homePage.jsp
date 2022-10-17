<%@page import="mvc.model.Objects.Team"%>
<%@page import="mvc.model.Objects.Country"%>
<%@page import="mvc.controller.DataLayer"%>
<%@page import="java.util.ArrayList"%>
<%@page import="javax.websocket.Session"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
    <head>
        <title>CAF Tournament</title>
        <link rel="stylesheet" type="text/css" href="myStyle.css?$$REVISION$$"/>
        <script type="application/javascript" src="myJavaScript.js?$$REVISION$$"></script>
    </head>

    <body id="mybody">

        <div class="div1">
            <h1 id="H1"> CAF TOURNAMENT </h1>
            <h2 id="H2">  Weolcome To CAF Web Application </h2><br/>
            <center><br><br<label id="lb" for="stxt"> All the countries and the team represent that country ...</label></center>            
        </div>

        <div id="divbar">
            <input type="button" id="standbtn" value="STANDINGS" onclick="toStandingPage();"/>
            <input type="button" id="standbtn" value="PLAYERS REPORT" onclick="toPlayersPage();"/>
            <input type="button" id="standbtn" value="PLAYER INFORMATION" onclick="toPlayeriNFO();"/>
            <input type="button" id="standbtn" value="INSERT GOAL !" onclick="toScoreAGoal();"/>
        </div>
        <br>
        <div class="div2">
            <table id="t1">
                <tr>
                    <th>Countries</th>
                    <th>Teams</th>
                </tr>
                <%
                    DataLayer ld = new DataLayer();
                    ArrayList<Country> CountryData = new ArrayList<>();
                    ArrayList<Team> TeamData = new ArrayList<>();
                    CountryData = ld.selectAllCountries();
                    String country_name,country_team ;  
                        for (int i = 0; i < CountryData.size(); i++) {
                        country_name = CountryData.get(i).getName();
                        TeamData = ld.selectTeams(CountryData.get(i).getTeamId());
                %>
                <tr>
                    <td><%= country_name %></td>
                    <%
                        for (int t = 0; t < TeamData.size(); t++){
                            country_team = TeamData.get(t).getName();
                            %><td><%= country_team %></td>
                    <%    }
                    %>                    
                </tr>
                <%}%>
            </table>
        </div>
            
    </body>
</html>