<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE html
        PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
        "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
    <title>Zamalek</title>
    <link rel="stylesheet" type="text/css" href="myStyle.css"/>
    <script type="application/javascript" src="myJavaScript.js"></script>
</head>
<body id="mybody">

    <div class="div1">
        <h1 id="H1"> Zamalek Web Site </h1>
        <h2 id="H2"> Welcome to Zamalek WebSite </h2><br/>
        <label id="lb" for="stxt"> you can search and know latest news about the team now... </label>
        <form method="get" action="SearchResults">
        	<input id="stxt" name="stxtn" type="text"/>
			<input id="sbtn"type="submit" value="Search" />        
		</form>
    </div>
	<br></br>
    <div class="div2">
        <label>Matches Of Zamalek FC</label>
        <table id="t1">
            <tr>
                <td>Day</td>
                <td>Matches</td>
                <td>Time</td>
            </tr>
            <tr>
                <td>  Sunday  </td>
                <td> El-Zamalek Vs El-Ahly</td>
                <td>  20:00 pm</td>
            </tr>
            <tr>
                <td>  Monday  </td>
                <td> El-Zamalek Vs Enbi </td>
                <td>  21:00 pm</td>
            </tr>
            <tr>
                <td>  Tuesday  </td>
                <td> El-Zamalek Vs El-Masry </td>
                <td>  18:00 pm</td>
            </tr>
        </table>
    </div>
</body>
</html> 