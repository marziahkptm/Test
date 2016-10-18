<html><meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">

<!-- Date de création: 12/01/02 -->
<body>
<%@ page import ="news.BeanAffListe" %>
<jsp:useBean id="beanaffliste" class="news.BeanAffListe" scope="request"/>
<jsp:setProperty name="beanaffliste" property="*"/>
<br><br>


<form method=get>
<div align="right"><a href="Recherche.jsp">Cliquez ici pour une recherche ...</a></div>
<div align="center"><font size="+3"><b><u>Dernière(s) infos...</u></b></font></div>

<br><br><br>
	<center>
<% beanaffliste.connect(); %>

<%= beanaffliste.liste() %>

	</center>
<form>
</body>
</html>

