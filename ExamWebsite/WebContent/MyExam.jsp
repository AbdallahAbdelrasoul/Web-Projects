<%@page import="java.util.ArrayList"%>
<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
	pageEncoding="ISO-8859-1"%>
<%@ page import="java.util.Map"%>
<%@ page import="mypackage.LoadData"%>
<%@ page import="java.util.*"%>

<%
	String ET = request.getParameter("ET").toString();
	session.setAttribute("ET", ET);
	Map<String, String> Qes = (Map<String, String>) session.getAttribute("Qes");
	Map<String, String> Ans = (Map<String, String>) session.getAttribute("Ans");
	String[] AID = new String[Ans.size()];
	AID = Ans.keySet().toArray(AID);
	LoadData ld = new LoadData();
	for(int i = 0 ; i < 11 ; i++){
		if( Integer.parseInt( AID[i] ) < Integer.parseInt( AID[i+1] )){
			String temp = AID[i];
			AID[i] = AID[i+1];
			AID[i+1] =temp;
		}
	}
		for(int i =0 ; i < 12 ; i++)
			System.out.println(AID[i]);
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<title><%=ET%> Exam</title>
<link rel="stylesheet" type="text/css" href="cssFile.css?v=3" />

</head>
<body>
	<input id="ET" value="<%=ET%>" type="text">
	<h1 align="center" style="font-style: oblique;"><%=ET%>
		Exam
	</h1>
	<h2 id="timer_ID" align="right"></h2>
	<%
		int a = 0;
		for (String Qkey : Qes.keySet()) {
						System.out.println("QES IN EXAAM PAGE" + Qes);
	%>
	<label id="Qlabel"> Q[<%=Qkey%>] : <%=Qes.get(Qkey)%>
	</label>
	<br>
	<%
		System.out.println("ANS IN EXAAM PAGE" + Ans);
			for (int i = 0; i < 4; i++) {
	%><div id="Atd<%=AID[a]%>">
		<input class="ch<%=AID[a]%>" id="<%=AID[a]%>"
			value="<%=Ans.get(AID[a])%>" type="checkbox"
			onclick="myFunction(this.id);"> <label><%=Ans.get(AID[a])%></label>
	</div>
	<br>
	<%				a++;

		}
	%>
	<br>
	<%
		}
	%>
	<input type="button" onclick="record();" value="Submit">
</body>
<script src="JSFile.js?v2" type="text/javascript"></script>
<script type="text/javascript">
	ExamTimer(1, 5);
</script>
<!-- 01:05 -->
</html>