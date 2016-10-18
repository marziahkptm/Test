package org.apache.jsp.jsp;

import javax.servlet.*;
import javax.servlet.http.*;
import javax.servlet.jsp.*;
import news.BeanSaisieNews;

public final class saisie_jsp extends org.apache.jasper.runtime.HttpJspBase
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
      out.write("<!-- mise en place du fond en couleur -->\n");
      out.write("<body bgcolor=#9999cc text=#000000 link=#0000ff vlink=#800080 alink=#ff0000>\n");
      out.write("<title>Administrateur</title>\n");
      out.write("\n");
      news.BeanSaisieNews beansaisienews = null;
      synchronized (request) {
        beansaisienews = (news.BeanSaisieNews) _jspx_page_context.getAttribute("beansaisienews", PageContext.REQUEST_SCOPE);
        if (beansaisienews == null){
          beansaisienews = new news.BeanSaisieNews();
          _jspx_page_context.setAttribute("beansaisienews", beansaisienews, PageContext.REQUEST_SCOPE);
        }
      }
      out.write('\n');
      org.apache.jasper.runtime.JspRuntimeLibrary.introspect(_jspx_page_context.findAttribute("beansaisienews"), request);
      out.write("\n");
      out.write("<br><br>\n");
      out.write("\n");
      out.write("<!-- Titre en gras et souligné de taille 3 -->\n");
      out.write("<div align=\"center\"><font size=+3><b><u>Ecran de saisie</u></b></font></div>\n");
      out.write("<br><br><br>\n");
      out.write("<!-- affichage du titre et de sa boite de saisie -->\n");
      out.write("\n");
      out.write("<form action=\"enregistrer.jsp\">\n");
      out.write("\n");
      out.write("\n");
      out.write("<div align=\"center\">\n");
      out.write("\tTitre : <input type=\"text\" name=titre size=20 maxlength=20>\n");
      out.write("</div>\n");
      out.write("\n");
      out.write("<br>\n");
      out.write("\n");
      out.write("<!-- affichage du corps du texte et de sa boite de saisie -->\n");
      out.write("<div align=\"center\">Corps du texte : </div>\n");
      out.write("<div align=\"center\">\n");
      out.write("  \t<textarea name=corpTexte rows=\"10\" cols=\"60\"></textarea>\n");
      out.write("</div>\n");
      out.write("<br>\n");
      out.write("<!-- affichage de la formation et de sa boite de selection -->\n");
      out.write("<div align=\"center\">\n");
      out.write("\tFormation concernée :\n");
      out.write("<!-- inserer le defilement de la formatoin -->\n");
      out.write("\t<select name=form>\n");
      out.write("    \t");
      out.print( news.Outils.getComboForm() );
      out.write("\n");
      out.write("\t</select>\n");
      out.write("</div>\n");
      out.write("\n");
      out.write("<br>\n");
      out.write("<!-- affichage du theme et de sa boite de selection -->\n");
      out.write("<div align=\"center\">\n");
      out.write("\tThème :\n");
      out.write("<!-- inserer le defilement des themes -->\n");
      out.write("\t<select name=them>\n");
      out.write("    \t");
      out.print( news.Outils.getComboTheme() );
      out.write("\n");
      out.write("\t</select>\n");
      out.write("</div>\n");
      out.write("<br>\n");
      out.write("<!-- affichage du lien et de sa boite de saisie -->\n");
      out.write("\n");
      out.write("<div align=\"center\">\n");
      out.write("\tLien Internet : <input type=\"text\" name=lien size=50 maxlength=50>\n");
      out.write("</div>\n");
      out.write("\n");
      out.write("<br>\n");
      out.write("<!-- affichage de la date de peremption et de sa boite de saisie -->\n");
      out.write("<div align=\"center\">\n");
      out.write("\tDate de péremption (format JJ/MM/AA) :\n");
      out.write("\t<input type=\"text\" name=\"jour\" size=2 maxlength=2\">/\n");
      out.write("\t<input type=\"text\" name=\"mois\" size=2 maxlength=2\">/\n");
      out.write("\t<input type=\"text\" name=\"annee\" size=2 maxlength=2\">\n");
      out.write("</div>\n");
      out.write("<br>\n");
      out.write("<!-- affichage du checkbox de la mise a jour -->\n");
      out.write("\n");
      out.write("<div align=\"center\">\n");
      out.write("\t<input type=\"checkbox\" name=checkbox value=1>Mise en ligne immédiate\n");
      out.write("</div>\n");
      out.write("\n");
      out.write("<!-- affichage du bouton enregistrer -->\n");
      out.write("\n");
      out.write("<div align=\"center\">\n");
      out.write("\t  <input type=submit value=\"Enregistrer\">\n");
      out.write("\n");
      out.write("\n");
      out.write("<!-- cadre de message d'erreur -->\n");
      out.write("<div align=\"center\">\n");
      out.write("\t<table width=\"5\" height=\"5\" border=\"1\" bordercolor=\"#000000\" summary=\"\">\n");
      out.write("\t\t<tr>\n");
      out.write("\t\t\t<td>");
      out.print( beansaisienews.getErreur() );
      out.write("</td>\n");
      out.write("\t\t</tr>\n");
      out.write("\t</table>\n");
      out.write("</div>\n");
      out.write("</form>\n");
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
