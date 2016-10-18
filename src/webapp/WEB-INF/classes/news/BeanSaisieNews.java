package news;
import java.sql.*;

public class BeanSaisieNews
{
	String req;
	String titre = "";
	String corpTexte = "";
	String lien = "";
	String dateParu = "";
	String dateFin = "";
	String form = "";
	String them = "";
	String onLine = "";
	String refform = "";
	String reftheme = "";
	String modif = "0";
	String refnews = "";
	String jour = "";
	String mois = "";
	String annee = "";
	//message d'erreur initialisation à OK en vert
	String erreur = new String("<b><font color=\"#66ff00\">OK</font></b>");
	String valcheckbox;
	//private String formation = "";
	//private String theme = "";
	public String getRefForm(String form, Statement requete) throws Exception
	{
		ResultSet rs1 = requete.executeQuery("SELECT libelform FROM formation WHERE refform=\"" + form + "\"");
		return rs1.getString("libelform");
	}
	public String getRefTheme(String them, Statement requete) throws Exception
	{
		ResultSet rs1 = requete.executeQuery("SELECT libeltheme FROM theme WHERE reftheme=\"" + them + "\"");
		return rs1.getString("libeltheme");
	}
	public String getTitre()
	{
		return titre;
	}
	public String getCorps()
	{
		return corpTexte;
	}
	public String getLien()
	{
		return lien;
	}
	public String getOnLine()
	{
		return onLine;
	}
	public String getJour()
	{
		return jour;
	}
	public String getMois()
	{
		return mois;
	}
	public String getAnnee()
	{
		return annee;
	}
	public void setRefnews(String pol)
	{
		refnews = pol;
		try
		{
			System.out.println(pol);
			Connection cnx = Connexion.connect();
			Statement requete = cnx.createStatement();
			ResultSet rs = requete.executeQuery("SELECT * FROM News where refNews='"+pol+"'");
			rs.next();
			titre = rs.getString("titre");
			corpTexte = rs.getString("corps");
			lien = rs.getString("lien");
			setDateFin(rs.getDate("dateFin"));
			reftheme = rs.getString("reftheme");
			refform = rs.getString("refform");
			requete.close();
			cnx.close();
		}
		catch (Exception e)
		{
		}
	}
	public String getModif()
	{
		return modif + "&refnews=" + refnews;
	}
	public String getRefNews()
	{
		return refnews;
	}
	public String getRefform()
	{
		return refform;
	}
	public String getReftheme()
	{
		return reftheme;
	}
	public String getTheme()
	{;
		try
		{
			Connection cnx = Connexion.connect();
			Statement requete = cnx.createStatement();
			ResultSet rs = requete.executeQuery("SELECT * FROM Theme where reftheme=" + reftheme);
			rs.next();
			them = rs.getString("libelTheme");
			requete.close();
			cnx.close();
		}
		catch (Exception e)
		{
		}
		return them;
	}
	public void setModif(String pol)
	{
		modif = pol;
	}
	public void setDateFin(java.sql.Date datefin)
	{
		String date = datefin.toString();
		annee = date.substring(2, 4);
		mois = date.substring(5, 7);
		jour = date.substring(8, 10);
		System.out.println("date : " + jour + mois + annee);
	}
	public String getErreur()
	{
		return erreur;
	}
}