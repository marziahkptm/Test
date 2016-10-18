package org.apache.jsp.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;

public final class Recherche_jsp extends org.apache.jasper.runtime.HttpJspBase
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
      out.write("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\">\r\n");
      out.write("</head>\r\n");
      out.write("<body>\r\n");
      out.write("\r\n");
      out.write("<br><br>\r\n");
      out.write("<font size=\"4\"><div align=\"center\"><b>Recherche de news</b></div></font>\r\n");
      out.write("<div align=\"center\">\r\n");
      out.write("<form action=\"Affliste.jsp\">\r\n");
      out.write("<input type=\"hidden\" name=rang value=\"1\">\r\n");
      out.write("\r\n");
      out.write("<p>FORMATION</p>\r\n");
      out.write("<select name=refform>\r\n");
      out.write("<option value=\"999\" selected>Toutes les formations</option>\r\n");
      out.write("\t");
      out.print( news.Outils.getComboForm());
      out.write("\r\n");
      out.write("\r\n");
      out.write("</select>\r\n");
      out.write("<br>\r\n");
      out.write("\r\n");
      out.write("\r\n");
      out.write("\r\n");
      out.write("<p>THEME</p>\r\n");
      out.write("<select name=reftheme>\r\n");
      out.write("<option value=\"999\" selected>Tous les thèmes</option>\r\n");
      out.write("\t");
      out.print( news.Outils.getComboTheme());
      out.write("\r\n");
      out.write("</select>\r\n");
      out.write("\r\n");
      out.write(" \r\n");
      out.write("<input type=submit value=\"Rechercher\">\r\n");
      out.write("<br><br>\r\n");
      out.write("\r\n");
      out.write("</div>\r\n");
      out.write("\r\n");
      out.write("</form>\r\n");
      out.write("\r\n");
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
