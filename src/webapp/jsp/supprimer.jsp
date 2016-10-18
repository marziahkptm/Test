<html>

<body bgcolor="#9999cc" text="#000000" link="#0000ff" vlink="#800080" alink="#ff0000">
<title>Administrateur</title>
<%@ page import ="news.BeanSupprimer" %>  
<jsp:useBean id="beandelete" class="news.BeanSupprimer" scope="page"/>
<jsp:setProperty name="beandelete" property="*"/>  
<br><br>                   

<form method=get>

<%= beandelete.getResultat() %>
<br>
<a href="Administrateur.jsp">Retour a la liste des news</A>
</form>
</body>
</html>