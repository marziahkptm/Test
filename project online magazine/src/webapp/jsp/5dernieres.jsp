<html>
<head>
</head>
<body>
<b><font color="#0033ff"><H2><u><div align="center">LES DERNIERES NEWS DU MOMENT</div></u></H2></font></b>
<%@ page import ="news.BeanAffListe" %>
<jsp:useBean id="beanAffListe" class="news.BeanAffListe" scope="page"/>
<jsp:setProperty name="beanAffListe" property="refform" value="999"/>
<jsp:setProperty name="beanAffListe" property="reftheme" value="999"/>

<% int max = beanAffListe.maxRefNews();

if (max!=0)
  {
   beanAffListe.connect();

    for(int i=max; i>(max-5); i--)
    {
%>

    <%= beanAffListe.newsSuivante() %>

<%
    }
  }
  else
  {
   out.println("Aucune news !");
  }
%>


</body>
</html>
