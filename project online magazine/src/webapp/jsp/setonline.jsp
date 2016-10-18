<html><body>

<!-- mise en place du fond en couleur -->
<%@ page import ="news.BeanOnline" %>  
<jsp:useBean id="beanonline" class="news.BeanOnline" scope="request"/>
<jsp:setProperty name="beanonline" property="*"/>                      

<%= beanonline.enregistrer()%>

<jsp:forward page="Administrateur.jsp" />
</body>
</html>