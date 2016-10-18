<html><meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">

<!-- mise en place du fond en couleur -->
<body bgcolor=#9999cc text=#000000 link=#0000ff vlink=#800080 alink=#ff0000>
<title>Administrateur</title>
<%@ page import ="news.BeanSaisieNews" %>  
<jsp:useBean id="beanenregistrer" class="news.BeanEnregistrer" scope="request"/>
<jsp:setProperty name="beanenregistrer" property="*"/>                      
<br><br>

<%= beanenregistrer.enregistrer()%>

<br>
<a href="Administrateur.jsp">Retour a la liste des news</A>

</body>
</html>