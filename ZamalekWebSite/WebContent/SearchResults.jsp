<%@ page language="java" contentType="text/html; charset=ISO-8859-1" pageEncoding="ISO-8859-1"%>
<%@ page import="mypackage.LoadData"%>
<%@ page import="java.util.*"%>
<%@ page import="java.sql.DriverManager"%>
<%@ page import="java.sql.ResultSet"%>
<%@ page import="java.sql.Statement"%>
<%@ page import="java.sql.Connection"%>
<%@ page import="java.util.ArrayList"%>
<% 
try {
	ArrayList<String> matches = (ArrayList<String>) session.getAttribute("matches");
	int Msize = matches.size();
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<title>Search Results</title>
</head>
<body>
<% System.out.print(" num of mathches : " + Msize); %>
<table id = "tb1">
	<% 
	for(int i = 0 ; i < Msize ; i++){
	%>
	 <tr>
		<td>
		<%matches.get(i); %>
		</td>		
	</tr>
	<%
	}		
	
} catch (Exception e1) {
		System.out.println(e1.getMessage().toString());
}
%>

</table>
</body>
</html>