<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Player Info</title>
        <link rel="stylesheet" type="text/css" href="myStyle.css"/>
        <script type="application/javascript" src="myJavaScript.js"></script>
    </head>
    <body id="inputBody">
        <div id="divbar">
            <input type="button" id="playerhomebtn" value="Home" onclick="toHomePage();" style="font-weight: 100"/>      
        </div>
    <center>
        <%
            String state = "" , color= "white";
            if ( request.getParameter("done") == null ){}
            else if(request.getParameter("done").toString().equals("1")){state = "Done! Inserted into DB. ";color = "green";}
            else if(request.getParameter("done").toString().equals("0")){state = "Error! Not inserted into DB !";color = "red";}
        %> 
        <label id="lb" style="color: <%=color%>"><%=state%> </label>
        <h1 id="H1">New Player</h1>
        <div id="divINputForm" >   
            <form id ="INputForm" method="get" action="InsertPlayer" onSubmit="return checkform()">
                <label id="inputlb">Player ID  </label> <br><input id="player_id" name="player_id" type="text" class="inputs">    <br>
                <label id="inputlb">Team ID    </label> <br><input id="player_id" name="team_id" type="text"   class="inputs">      <br>
                <label id="inputlb">Name       </label> <br><input id="player_id" name="player_name" type="text"class="inputs" >   <br>
                <label id="inputlb">Position   </label> <br><input id="player_id" name="player_pos" type="text" class="inputs">    <br>
                <label id="inputlb">Date of birth</label><br><input id="player_id" name="player_dof" type="text" class="inputs">   <br>
                <br><input id="subbtn" name="subbtn" type="submit" />
            </form>
        </div>
    </center>
</body>
</html>
