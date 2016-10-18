<html><meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">

<!-- mise en place du fond en couleur -->
<body bgcolor=#9999cc text=#000000 link=#0000ff vlink=#800080 alink=#ff0000>
<title>Administrateur</title>
<%@ page import ="news.BeanSaisieNews" %>  
<jsp:useBean id="beansaisienews" class="news.BeanSaisieNews" scope="session"/>
<jsp:setProperty name="beansaisienews" property="*"/>                      
<br><br>

<!-- Titre en gras et souligné de taille 3 -->
<div align="center"><font size=+3><b><u>Écran de saisie</u></b></font></div>
<br><br><br>
<!-- affichage du titre et de sa boite de saisie -->

<form action="enregistrer.jsp">

<div align="center">
	Titre : <textarea name=titre><%= beansaisienews.getTitre() %></textarea>
</div>

<br>

<!-- affichage du corps du texte et de sa boite de saisie -->
<div align="center">Corps du texte : </div>
<div align="center">
  	<textarea name=corpTexte><%= beansaisienews.getCorpTexte()%></textarea>	
</div>
<br>
<!-- affichage de la formation et de sa boite de selection -->
<div align="center">
	Formation concernée :
<!-- inserer le defilement de la formatoin -->
	<select name=form>
    	<%= beansaisienews.getComboFormation() %>
	</select>
</div>

<br>
<!-- affichage du theme et de sa boite de selection -->
<div align="center">
	Thème :
<!-- inserer le defilement des themes -->
	<select name=them>
    	<%= beansaisienews.getComboTheme() %>
	</select>
</div>
<br>
<!-- affichage du lien et de sa boite de saisie -->

<div align="center">
	Lien Internet : <textarea name=lien><%= beansaisienews.getLien()%></textarea>	
</div>

<br>
<!-- affichage de la date de peremption et de sa boite de saisie -->
<div align="center">
	Date de péremption (format JJ/MM/AA) : <textarea name=corpTexte><%= beansaisienews.getDate()%></textarea>	
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
