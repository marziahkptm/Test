<html><meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">

<!-- mise en place du fond en couleur -->
<body bgcolor=#9999cc text=#000000 link=#0000ff vlink=#800080 alink=#ff0000>
<title>Administrateur</title>
<%@ page import ="news.BeanSaisieNews" %>
<jsp:useBean id="beansaisienews" class="news.BeanSaisieNews" scope="request"/>
<jsp:setProperty name="beansaisienews" property="*"/>
<br><br>

<!-- Titre en gras et souligné de taille 3 -->
<div align="center"><font size=+3><b><u>Ecran de saisie</u></b></font></div>
<br><br><br>
<!-- affichage du titre et de sa boite de saisie -->

<form action="enregistrer.jsp">


<div align="center">
	Titre : <input type="text" name=titre size=20 maxlength=20>
</div>

<br>

<!-- affichage du corps du texte et de sa boite de saisie -->
<div align="center">Corps du texte : </div>
<div align="center">
  	<textarea name=corpTexte rows="10" cols="60"></textarea>
</div>
<br>
<!-- affichage de la formation et de sa boite de selection -->
<div align="center">
	Formation concernée :
<!-- inserer le defilement de la formatoin -->
	<select name=form>
    	<%= news.Outils.getComboForm() %>
	</select>
</div>

<br>
<!-- affichage du theme et de sa boite de selection -->
<div align="center">
	Thème :
<!-- inserer le defilement des themes -->
	<select name=them>
    	<%= news.Outils.getComboTheme() %>
	</select>
</div>
<br>
<!-- affichage du lien et de sa boite de saisie -->

<div align="center">
	Lien Internet : <input type="text" name=lien size=50 maxlength=50>
</div>

<br>
<!-- affichage de la date de peremption et de sa boite de saisie -->
<div align="center">
	Date de péremption (format JJ/MM/AA) :
	<input type="text" name="jour" size=2 maxlength=2">/
	<input type="text" name="mois" size=2 maxlength=2">/
	<input type="text" name="annee" size=2 maxlength=2">
</div>
<br>
<!-- affichage du checkbox de la mise a jour -->

<div align="center">
	<input type="checkbox" name=checkbox value=1>Mise en ligne immédiate
</div>

<!-- affichage du bouton enregistrer -->

<div align="center">
	  <input type=submit value="Enregistrer">


<!-- cadre de message d'erreur -->
<div align="center">
	<table width="5" height="5" border="1" bordercolor="#000000" summary="">
		<tr>
			<td><%= beansaisienews.getErreur() %></td>
		</tr>
	</table>
</div>
</form>
</body>
</html>
