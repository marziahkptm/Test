package org.apache.jsp.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;
import news.BeanAffListe;

public final class _5dernieres_jsp extends org.apache.jasper.runtime.HttpJspBase
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

      out.write("<html>\n");
      out.write("<head>\n");
      out.write("</head>\n");
      out.write("<body>\n");
      out.write("<b><font color=\"#0033ff\"><H2><u><div align=\"center\">LES DERNIERES NEWS DU MOMENT</div></u></H2></font></b>\n");
      out.write("\n");
      news.BeanAffListe beanAffListe = null;
      synchronized (_jspx_page_context) {
        beanAffListe = (news.BeanAffListe) _jspx_page_context.getAttribute("beanAffListe", PageContext.PAGE_SCOPE);
        if (beanAffListe == null){
          beanAffListe = new news.BeanAffListe();
          _jspx_page_context.setAttribute("beanAffListe", beanAffListe, PageContext.PAGE_SCOPE);
        }
      }
      out.write('\n');
      org.apache.jasper.runtime.JspRuntimeLibrary.introspecthelper(_jspx_page_context.findAttribute("beanAffListe"), "refform", "999", null, null, false);
      out.write('\n');
      org.apache.jasper.runtime.JspRuntimeLibrary.introspecthelper(_jspx_page_context.findAttribute("beanAffListe"), "reftheme", "999", null, null, false);
      out.write('\n');
      out.write('\n');
 int max = beanAffListe.maxRefNews();

if (max!=0)
  {
   beanAffListe.connect();

    for(int i=max; i>(max-5); i--)
    {

      out.write("\n");
      out.write("\n");
      out.write("    ");
      out.print( beanAffListe.newsSuivante() );
      out.write('\n');
      out.write('\n');

    }
  }
  else
  {
   out.println("Aucune news !");
  }

      out.write("\n");
      out.write("\n");
      out.write("\n");
      out.write("</body>\n");
      out.write("</html>\n");
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
