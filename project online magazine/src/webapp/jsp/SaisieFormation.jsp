<html><meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">

<!-- mise en place du fond en couleur -->
<body bgcolor=#9999cc text=#000000 link=#0000ff vlink=#800080 alink=#ff0000>
<title>Administrateur</title>
<%@ page import ="news.BeanSaisieFormation" %>
<jsp:useBean id="beansaisieformation" class="news.BeanSaisieFormation" scope="request"/>
<jsp:setProperty name="beansaisieformation" property="*"/>
<br><br>

<!-- Titre en gras et souligné de taille 3 -->
<div align="center"><font size=+3><b><u>Ecran d'ajout de Formation</u></b></font></div>
<br><br><br>
<!-- affichage du titre et de sa boite de saisie -->

<form action="enregistrerformation.jsp">


<div align="center">
	Numéro de formation : <input type="text" name=refform size=5 maxlength=20>
</div>

<br>
<div align="center">
	Libelle de formation : <input type="text" name=libelform size=20 maxlength=20>
</div>

<!-- affichage du bouton enregistrer -->

<div align="center">
	  <input type=submit value="Enregistrer">


<!-- cadre de message d'erreur -->
<div align="center">
	<table width="5" height="5" border="1" bordercolor="#000000" summary="">
		<tr>
			<td><%= beansaisieformation.getErreur() %></td>
		</tr>
	</table>
</div>
</form>
</body>
</html>
