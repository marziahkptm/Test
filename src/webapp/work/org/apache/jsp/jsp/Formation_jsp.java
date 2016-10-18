package org.apache.jsp.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;
import news.BeanSaisieFormation;

public final class Formation_jsp extends org.apache.jasper.runtime.HttpJspBase
    implements org.apache.jasper.runtime.JspSourceDependent {

  private static java.util.Vector _jspx_dependants;

  public java.util.List getDependants() {
    return _jspx_dependants;
  }

  public void _jspService(HttpServletRequest request, HttpServletResponse response)
        throws java.io.IOException, ServletException {

    JspFactory _jspxFactory = null;
    PageContext pageContext = null;
    HttpSession session = null;
    ServletContext application = null;
    ServletConfig config = null;
    JspWriter out = null;
    Object page = this;
    JspWriter _jspx_out = null;
    PageContext _jspx_page_context = null;


    try {
      _jspxFactory = JspFactory.getDefaultFactory();
      response.setContentType("text/html");
      pageContext = _jspxFactory.getPageContext(this, request, response,
      			null, true, 8192, true);
      _jspx_page_context = pageContext;
      application = pageContext.getServletContext();
      config = pageContext.getServletConfig();
      session = pageContext.getSession();
      out = pageContext.getOut();
      _jspx_out = out;

      out.write("<html>\r\n");
      out.write("<!-- Date de création: 19/02/07 -->\r\n");
      out.write("<body bgcolor=\"#9999cc\" text=\"#000000\" link=\"#0000ff\" vlink=\"#800080\" alink=\"#ff0000\">\r\n");
      out.write("<title>Administrateur</title>\r\n");
      out.write("  \r\n");
      news.BeanAfficheFormation beanafficheformation = null;
      synchronized (session) {
        beanafficheformation = (news.BeanAfficheFormation) _jspx_page_context.getAttribute("beanafficheformation", PageContext.SESSION_SCOPE);
        if (beanafficheformation == null){
          beanafficheformation = new news.BeanAfficheFormation();
          _jspx_page_context.setAttribute("beanafficheformation", beanafficheformation, PageContext.SESSION_SCOPE);
        }
      }
      out.write('\r');
      out.write('\n');
      org.apache.jasper.runtime.JspRuntimeLibrary.introspect(_jspx_page_context.findAttribute("beanafficheformation"), request);
      out.write("                      \r\n");
      out.write("<br><br>\r\n");
      out.write("\r\n");
      out.write("<!-- Titre en gras et souligné de taille 3 -->\r\n");
      out.write("<div align=\"center\"><font size=+3><b><u>Liste des infos</u></b></font></div>\r\n");
      out.write("<br><br><br>\r\n");
      out.write("\r\n");
      out.write("<!-- Generation du tableau en fonction de la base de données -->\r\n");
      out.write("<table width=\"75%\" border=\"1\">\r\n");
      out.write("\t<tr>\r\n");
      out.write("    <td width=\"12%\"><b>N°Formation<b></td>\r\n");
      out.write("    <td width=\"25%\"><b>Libelle formation</b></td>\r\n");
      out.write("    <td width=\"14%\"><b>Modifier</b></td>\r\n");
      out.write("    <td width=\"16%\"><b>Supprimer</b></td>\r\n");
      out.write("    </tr>\r\n");
      out.write("\t");
      out.print( beanafficheformation.getTableau());
      out.write("\r\n");
      out.write("</table>\r\n");
      out.write("<br><br>\r\n");
      out.write("<A HREF=\"SaisieFormation.jsp\">Saisie d'une formation</A>\r\n");
      out.write("<br><br>\r\n");
      out.write("<!-- cadre de message d'erreur -->\r\n");
      out.write("<div align=\"center\">\r\n");
      out.write("\t<table width=\"5\" height=\"5\" border=\"1\" bordercolor=\"#000000\" summary=\"\">\r\n");
      out.write("\t\t<tr>\r\n");
      out.write("\t\t\t<td>");
      out.print( beanafficheformation.getErreur() );
      out.write("</td>\r\n");
      out.write("\t\t</tr>\r\n");
      out.write("\t</table>\r\n");
      out.write("</div>\r\n");
      out.write("</body>\r\n");
      out.write("</html>\r\n");
    } catch (Throwable t) {
      if (!(t instanceof SkipPageException)){
        out = _jspx_out;
        if (out != null && out.getBufferSize() != 0)
          out.clearBuffer();
        if (_jspx_page_context != null) _jspx_page_context.handlePageException(t);
      }
    } finally {
      if (_jspxFactory != null) _jspxFactory.releasePageContext(_jspx_page_context);
    }
  }
}
