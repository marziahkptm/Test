<html>
<!-- Date de création: 05/01/07 -->
<body bgcolor="#9999cc" text="#000000" link="#0000ff" vlink="#800080" alink="#ff0000">
<title>Administrateur</title>
<%@ page import ="news.BeanSaisieNews" %>  
<jsp:useBean id="beanaffichenews" class="news.BeanAfficheNews" scope="session"/>
<jsp:setProperty name="beanaffichenews" property="*"/>                      
<br><br>

<!-- Titre en gras et souligné de taille 3 -->
<div align="center"><font size=+3><b><u>Liste des infos</u></b></font></div>
<br><br><br>

<!-- Generation du tableau en fonction de la base de données -->
<table width="75%" border="1">
	<tr>
    <td width="12%"><b>En ligne<b></td>
    <td width="25%"><b>Date de parution</b></td>
	<td width="17%"><b>Titre</b></td>
    <td width="16%"><b>Formation</b></td>
    <td width="14%"><b>Modifier</b></td>
    <td width="16%"><b>Supprimer</b></td>
    </tr>
	<%= beanaffichenews.getTableau()%>
</table>
<br><br>
<A HREF="saisie.jsp">Saisie d'une news</A>
<br><br>
<!-- cadre de message d'erreur -->
<div align="center">
	<table width="5" height="5" border="1" bordercolor="#000000" summary="">
		<tr>
			<td><%= beanaffichenews.getErreur() %></td>
		</tr>
	</table>
</div>
</body>
</html>
