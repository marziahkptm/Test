package org.apache.jsp.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;
import news.BeanAffListe;

public final class Affliste_jsp extends org.apache.jasper.runtime.HttpJspBase
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

      out.write("<html><meta http-equiv=\"Content-Type\" content=\"text/html; charset=iso-8859-1\">\n");
      out.write("\n");
      out.write("<!-- Date de création: 12/01/02 -->\n");
      out.write("<body>\n");
      out.write("\n");
      news.BeanAffListe beanaffliste = null;
      synchronized (request) {
        beanaffliste = (news.BeanAffListe) _jspx_page_context.getAttribute("beanaffliste", PageContext.REQUEST_SCOPE);
        if (beanaffliste == null){
          beanaffliste = new news.BeanAffListe();
          _jspx_page_context.setAttribute("beanaffliste", beanaffliste, PageContext.REQUEST_SCOPE);
        }
      }
      out.write('\n');
      org.apache.jasper.runtime.JspRuntimeLibrary.introspect(_jspx_page_context.findAttribute("beanaffliste"), request);
      out.write("\n");
      out.write("<br><br>\n");
      out.write("\n");
      out.write("\n");
      out.write("<form method=get>\n");
      out.write("<div align=\"right\"><a href=\"Recherche.jsp\">Cliquez ici pour une recherche ...</a></div>\n");
      out.write("<div align=\"center\"><font size=\"+3\"><b><u>Dernière(s) infos...</u></b></font></div>\n");
      out.write("\n");
      out.write("<br><br><br>\n");
      out.write("\t<center>\n");
 beanaffliste.connect(); 
      out.write('\n');
      out.write('\n');
      out.print( beanaffliste.liste() );
      out.write("\n");
      out.write("\n");
      out.write("\t</center>\n");
      out.write("\r<form>\n");
      out.write("</body>\n");
      out.write("</html>\n");
      out.write("\n");
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
