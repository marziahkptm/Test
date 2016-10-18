package org.apache.jsp.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;
import news.BeanSaisieFormation;

public final class modifierformation_jsp extends org.apache.jasper.runtime.HttpJspBase
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

      out.write("<html><meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\">\r\n");
      out.write("\r\n");
      out.write("<!-- mise en place du fond en couleur -->\r\n");
      out.write("<body bgcolor=#9999cc text=#000000 link=#0000ff vlink=#800080 alink=#ff0000>\r\n");
      out.write("<title>Administrateur</title>\r\n");
      out.write("  \r\n");
      news.BeanSaisieFormation beansaisieformation = null;
      synchronized (session) {
        beansaisieformation = (news.BeanSaisieFormation) _jspx_page_context.getAttribute("beansaisieformation", PageContext.SESSION_SCOPE);
        if (beansaisieformation == null){
          beansaisieformation = new news.BeanSaisieFormation();
          _jspx_page_context.setAttribute("beansaisieformation", beansaisieformation, PageContext.SESSION_SCOPE);
        }
      }
      out.write('\r');
      out.write('\n');
      org.apache.jasper.runtime.JspRuntimeLibrary.introspect(_jspx_page_context.findAttribute("beansaisieformation"), request);
      out.write("                      \r\n");
      out.write("<br><br>\r\n");
      out.write("\r\n");
      out.write("<!-- Titre en gras et souligné de taille 3 -->\r\n");
      out.write("<div align=\"center\"><font size=+3><b><u>Écran de modification des formation</u></b></font></div>\r\n");
      out.write("<br><br><br>\r\n");
      out.write("<!-- affichage du titre et de sa boite de saisie -->\r\n");
      out.write("\r\n");
      out.write("<form action=\"enregistrerformation.jsp\">\r\n");
      out.write("<input type=\"hidden\" name=\"modif\" value=\"1\">\r\n");
      out.write("<input type=\"hidden\" name=\"refform\" value=\"");
      out.print(beansaisieformation.getrefform());
      out.write("\">\r\n");
      out.write("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t  \r\n");
      out.write("\r\n");
      out.write("\r\n");
      out.write("<div align=\"center\">\r\n");
      out.write("\tLibelle Formation : <textarea name=libelform size=20 maxlength=20>");
      out.print(beansaisieformation.getlibelform());
      out.write("</textarea>\r\n");
      out.write("</div>\r\n");
      out.write("\r\n");
      out.write("<br>\r\n");
      out.write("<!-- affichage du bouton enregistrer -->\r\n");
      out.write("\r\n");
      out.write("<div align=\"center\">\r\n");
      out.write("\t  <input type=submit value=\"Enregistrer\">\r\n");
      out.write("\r\n");
      out.write("\r\n");
      out.write("<!-- cadre de message d'erreur -->\r\n");
      out.write("<div align=\"center\">\r\n");
      out.write("\t<table width=\"5\" height=\"5\" border=\"1\" bordercolor=\"#000000\" summary=\"\">\r\n");
      out.write("\t\t<tr>\r\n");
      out.write("\t\t\t<td>");
      out.print( beansaisieformation.getErreur() );
      out.write("</td>\r\n");
      out.write("\t\t</tr>\r\n");
      out.write("\t</table>\r\n");
      out.write("</div>\r\n");
      out.write("</form>\r\n");
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
