<html>
<head>
</head>
<body>
<b><font color="#0033ff"><H2><u><div align="center">AFFICHAGE D'INFORMATIONS</div></u></H2></font></b>
<%@ page import ="news.BeanDetail" %>
<jsp:useBean id="beanDetail" class="news.BeanDetail" scope="page"/>
<jsp:setProperty name="beanDetail" property="*"/>

<%= beanDetail.getDetail() %>

</body>
</html>
