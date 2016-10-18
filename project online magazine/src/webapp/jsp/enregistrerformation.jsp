<html><meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">

<!-- mise en place du fond en couleur -->
<body bgcolor=#9999cc text=#000000 link=#0000ff vlink=#800080 alink=#ff0000>
<title>Administrateur</title>
<%@ page import ="news.BeanSaisieFormation" %>  
<jsp:useBean id="beantable" class="news.BeanTable" scope="request"/>
<jsp:setProperty name="beantable" property="*"/>                      
<br><br>

<%= beantable.EnregistrerFormation()%>

<br>
<a href="Formation.jsp">Retour a la liste des Formation</A>

</body>
</html>