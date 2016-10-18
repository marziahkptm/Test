package news;
import java.lang.String;
import java.sql.*;
 
public class BeanAfficheNews
{
	int inter;
	String tableau;
	String erreur = new String("<b><font color=\"#66ff00\">OK</font></b>");
	Connection connexion;
	String res;
	public String faireTableau()
	{
		try
		{
			Connection cnx = Connexion.connect();
			Statement requete = cnx.createStatement();
			ResultSet resultatRequete = requete.executeQuery("SELECT * FROM news");
			String ref = "";
			tableau = "";
			while (resultatRequete.next())
			{
				ref = resultatRequete.getString("refnews");
				tableau += "<tr><td width=\"12%\">"
					+ enligne(ref, resultatRequete.getString("enligne"))
					+ "</td>"
					+ "<td width=\"25%\">"
					+ news.Outils.redate(resultatRequete.getDate("dateParu"))
					+ "</td>"
					+ "<td width=\"17%\">"
					+ resultatRequete.getString("titre")
					+ "</td>"
					+ "<td width=\"16%\">"
					+ getForm(resultatRequete.getString("refform"))
					+ "</td>"
					+ "<td width=\"14%\"><a href=\"modifier.jsp?refnews="
					+ ref
					+ "&modif=1\">Cliquez la</a></td>"
					+ "<td width=\"16%\"><a href=\"supprimer.jsp?refnews="
					+ ref
					+ "\">Cliquez ici</a></td></tr>";
			}
			requete.close();
			cnx.close();
		}
		catch (SQLException e)
		{
			erreur = "Probleme avec la base de données";
		}
		catch (IndexOutOfBoundsException e)
		{
			erreur = "Theme ou formation inexistant";
		}
		catch (Exception e)
		{
			erreur = "";
		}
		return tableau;
	}
	public String getTableau()
	{
		return faireTableau();
	}
	public String getForm(String form) throws Exception
	{
		Formation formation = new Formation();
		return formation.getLibel(form);
	}
	public String getErreur()
	{
		return erreur;
	}
	public String enligne(String ref, String num)
	{
		String html;
		int inter = num.compareTo("1");
		if (inter == 0)
			html = "<A href=\"setonline.jsp?refnews=" + ref + "&online=0\" border=0><img src=\"online.gif\" width=25 height=25></A>";
		else
			html = "<A href=\"setonline.jsp?refnews=" + ref + "&online=1\" border=0><img src=\"offline.gif\" width=25 height=25></A>";
		return html;
	}
}