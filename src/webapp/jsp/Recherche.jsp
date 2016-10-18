<html>
<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
</head>
<body>

<br><br>
<font size="4"><div align="center"><b>Recherche de news</b></div></font>
<div align="center">
<form action="Affliste.jsp">
<input type="hidden" name=rang value="1">

<p>FORMATION</p>
<select name=refform>
<option value="999" selected>Toutes les formations</option>
	<%= news.Outils.getComboForm()%>

</select>
<br>



<p>THEME</p>
<select name=reftheme>
<option value="999" selected>Tous les thèmes</option>
	<%= news.Outils.getComboTheme()%>
</select>

 
<input type=submit value="Rechercher">
<br><br>

</div>

</form>

</body>
</html>
