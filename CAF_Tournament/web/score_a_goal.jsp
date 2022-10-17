<%@page import="mvc.model.Objects.Player"%>
<%@page import="mvc.model.Objects.Country"%>
<%@page import="java.util.ArrayList"%>
<%@page import="mvc.controller.DataLayer"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Insert A GOAL!</title>
        <link rel="stylesheet" type="text/css" href="myStyle.css"/>
        <script type="application/javascript" src="myJavaScript.js"></script>
    </head>
    <body id="inputBody" >
        <div id="divbar">
            <input type="button" id="playerhomebtn" value="Home" onclick="toHomePage();" style="font-weight: 100"/>      
        </div>
    <center>
        <%
            String state = "", color = "white";
            if (request.getParameter("done") == null) {
            } else if (request.getParameter("done").toString().equals("1")) {
                state = "Done! Inserted into DB. ";
                color = "green";
            } else if (request.getParameter("done").toString().equals("0")) {
                state = "Error! Not inserted into DB !";
                color = "red";
            }
        %> 
        <label id="lb" style="color: <%=color%>"><%=state%> </label>
        <h1 id="H1">Insert a GOAL !</h1>
        <div id="divINputForm" >   
            <form id ="INputForm" method="get" action="InsertGoal" onSubmit="return checkGOALform()" >

                <label id="inputlb">Team ID  </label> <br>
                <select id="team_id" name="teamid_name" class="inputs" onfocus="fun(this.value)" onchange="fun(this.value)" autofocus>

                    <%
                        DataLayer ld = new DataLayer();
                        ArrayList<Country> CountryData = new ArrayList<>();
                        CountryData = ld.selectAllCountries();
                        String team_id;
                        for (int i = 0; i < CountryData.size(); i++) {
                            team_id = CountryData.get(i).getTeamId();
                    %>
                    <option value="<%=team_id%>"><%=team_id%></option>
                    <%}%>
                </select> <br>
                <label id="inputlb">Player ID In The Selected Team Using Ajax </label><br>
                <select id="player_id" name="playerid_name" class="inputs" ></select> <br>
                <label id="inputlb">Date  </label> <br>
                <input id="Date" name="Date" type="text" class="inputs"/>    <br>
                <label id="inputlb">Time </label> <br>
                <input id="Time" name="Time" type="text" class="inputs"/>    <br>
                <br><input id="subbtn" name="subbtn" type="submit" />
            </form>
        </div>
    </center>
</body>
</html>
