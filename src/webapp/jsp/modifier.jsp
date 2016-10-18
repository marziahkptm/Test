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
<input type="hidden" name="modif" value="1">
<input type="hidden" name="refnews" value="<%=beansaisienews.getRefNews()%>">


<div align="center">
	Titre : <textarea name=titre size=20 maxlength=20><%=beansaisienews.getTitre()%></textarea>
</div>

<br>

<!-- affichage du corps du texte et de sa boite de saisie -->
<div align="center">Corps du texte : </div>
<div align="center">
  	<textarea name=corpTexte rows="10" cols="60"><%=beansaisienews.getCorps()%></textarea>	
</div>
<br>
<!-- affichage de la formation et de sa boite de selection -->
<div align="center">
	Formation concernée :
<!-- inserer le defilement de la formatoin -->
	<select name=form>
    	<%= news.Outils.getComboForm(beansaisienews.getRefform()) %>
	</select>
</div>

<br>
<!-- affichage du theme et de sa boite de selection -->
<div align="center">
	Thème :
<!-- inserer le defilement des themes -->
	<select name=them>
    	<%= news.Outils.getComboTheme(beansaisienews.getReftheme()) %>
	</select>
</div>
<br>
<!-- affichage du lien et de sa boite de saisie -->

<div align="center">
	Lien Internet : <input type="text" name=lien size=50 maxlength=50 value="<%=beansaisienews.getLien()%>">
</div>

<br>
<!-- affichage de la date de peremption et de sa boite de saisie -->
<div align="center">
	Date de péremption (format JJ/MM/AA) : 
	<input type="text" name="jour" size=2 maxlength=2 value="<%=beansaisienews.getJour()%>">/
	<input type="text" name="mois" size=2 maxlength=2 value="<%=beansaisienews.getMois()%>">/
	<input type="text" name="annee" size=2 maxlength=2 value="<%=beansaisienews.getAnnee()%>">
</div>
<br>

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
