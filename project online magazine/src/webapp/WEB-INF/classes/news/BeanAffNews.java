package news;
import java.sql.*;

public class BeanAffNews
{
	private String refform = "";
	private String reftheme = "";
	private String refnews = "";
	public String erreur;
	public String fin = "";
	boolean var;
	boolean encore = false;
	Connection cnx;
	Statement requete;
	ResultSet rs1;
	java.sql.Date date;
	String corps;
	String titre;
	String lien;
	public void connect()
	{
		String sql;
		try
		{
			cnx = Connexion.connect();
			requete = cnx.createStatement();
			sql = "SELECT * FROM news WHERE refnews='" + refnews + "' AND enligne=1";
			rs1 = requete.executeQuery(sql);
			// récupération des données du formulaire en cours
			refform = rs1.getString("refForm");
			reftheme = rs1.getString("refTheme");
			date = rs1.getDate("dateParu");
			titre = rs1.getString("titre");
			corps = rs1.getString("corps");
			lien = rs1.getString("lien");
		}
		catch (SQLException e)
		{
			erreur += "Probleme d'acces à la base de donnée" + e.toString();
		}
		catch (Exception e)
		{
			erreur = "ERREUR" + e.toString();
		}
	}
	public String getForm()
	{
		Formation f = new Formation();
		return f.getLibel(refform);
	}
	public String getTheme()
	{
		Theme t = new Theme();
		return t.getLibel(reftheme);
	}
	public String getTitre()
	{
		return titre;
	}
	public String getDate()
	{
		return news.Outils.redate(date);
	}
	public String getCorps()
	{
		return news.Outils.prepareAffichage(corps);
	}
	public String getErreur()
	{
		return erreur;
	}
	public String getLien()
	{
		if ((lien.lastIndexOf("http") != -1) && (!lien.equals("")))
			return lien;
		else
			if (lien.equals(""))
				return "AUCUN LIEN";
			else
				return "http://" + lien;
	}
	// setters
	/** définition de la news a rechercher */
	public void setRefnews(String pol)
	{
		refnews = pol;
	}
	public void close()
	{
		try
		{
			rs1.close();
			requete.close();
			cnx.close();
		}
		catch (Exception e)
		{
		}
	}
	public String affiche()
	{
		String s =
			"<TABLE bgcolor=\"silver\">"
				+ "<TR bgcolor=\"yellow\"><TD>Titre : </TD><TD>"
				+ getTitre()
				+ "</TD></TR>"
				+ "<TR><TD>Date : </TD><TD>"
				+ getDate()
				+ "</TD></TR>"
				+ "<TR bgcolor=\"white\"><TD>Corps : </TD><TD>"
				+ getCorps()
				+ "</TD></TR>"
				+ "<TR><TD>Formation : </TD><TD>"
				+ getForm()
				+ "</TD></TR>"
				+ "<TR><TD>Theme : </TD><TD>"
				+ getTheme()
				+ "</TD></TR>"
				+ "<TR><TD>Lien : </TD><TD>";
		if (getLien().equals("AUCUN LIEN"))
			s += getLien();
		else
			s += "<A href=\"" + getLien() + "\">" + getLien() + "</A>";
		s += "</TD></TR></TABLE>";
		return s;
	}
}
