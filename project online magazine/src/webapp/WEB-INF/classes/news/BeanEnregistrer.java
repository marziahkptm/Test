/**
 * bean qui permet d'enregistrer une news dans la table news
 * 
 */
package news;
import java.lang.String;
import java.sql.*;

public class BeanEnregistrer
{
	public String erreur = "<p>Les données sont toutes enregistrées:</p>";
	public String titre = "";
	public String jour = "31";
	public String mois = "12";
	public String annee = "99";
	public String corpTexte = "";
	public String lien = "";
	public String theme = "";
	public String form = "";
	public String refform = "";
	public String reftheme = "";
	public String online = "0";
	public String refnews = "";
	public String dateParu = "";
	private boolean modif;
	public String enregistrer()
	{
		try
		{
			Connection cnx = Connexion.connect();
			Statement requete = cnx.createStatement();
			String sql;
			if (modif) // update
				sql =
					"UPDATE news set titre='"
						+ titre
						+ "',corps='"
						+ corpTexte
						+ "',refTheme='"
						+ reftheme
						+ "',refForm='"
						+ refform
						+ "',dateFin='"
						+ getDate()
						+ "',lien='"
						+ lien
						+ "',enligne="
						+ online
						+ " "
						+ "WHERE refnews='"
						+ refnews
						+ "'";
			// nb : on n'update pas la date de parution
			else // insert
				{
				genereNumNews(requete);
				sql =
					"INSERT INTO news (refnews,titre,corps,refTheme,refForm,dateParu,dateFin,lien,enligne) "
						+ "VALUES ('"
						+ refnews
						+ "', '"
						+ titre
						+ "', '"
						+ corpTexte
						+ "', '"
						+ reftheme
						+ "', '"
						+ refform
						+ "', '"
						+ getDateParu()
						+ "', '"
						+ getDate()
						+ "', '"
						+ lien
						+ "', "
						+ online
						+ ")";
			}
			requete.executeUpdate(sql);
			System.out.println("sql : " + sql);
			requete.close();
			cnx.close();
		}
		catch (Exception e)
		{
			erreur = "<b><font color=\"#ff3300\">ERREUR + " + e.toString() + titre + refnews + reftheme + refform + corpTexte + "</font></b>";
		}
		return erreur;
	}
	public java.sql.Date getDateParu()
	{
		java.sql.Date dateParu = new java.sql.Date(System.currentTimeMillis());
		return dateParu;
	}
	public void setTitre(String pol)
	{
		titre = news.Outils.prepareEnreg(pol);
	}
	public void setCorpTexte(String pol)
	{
		corpTexte = news.Outils.prepareEnreg(pol);
	}
	public void setThem(String pol)
	{
		reftheme = pol;
	}
	public void setForm(String pol)
	{
		refform = pol;
	}
	public void setLien(String pol)
	{
		lien = news.Outils.prepareEnreg(pol);
	}
	public void setJour(String pol)
	{
		jour = pol;
	}
	public void setMois(String pol)
	{
		mois = pol;
	}
	public void setAnnee(String pol)
	{
		annee = pol;
	}
	public java.sql.Date getDate()
	{
		return java.sql.Date.valueOf("20" + annee + "-" + mois + "-" + jour);
	}
	public void setCheckbox(String pol)
	{
		online = pol;
	}
	public void setRefnews(String pol)
	{
		refnews = pol;
	}
	// flag d'update et non d'insert
	public void setModif(String pol)
	{
		if (pol.equals("1"))
			modif = true;
	}
	public void genereNumNews(Statement s)
	{
		String sql = "SELECT * from news order by refnews desc";
		try
		{
			ResultSet rs = s.executeQuery(sql);
			if (rs.next() && (!(rs.getString("refnews").equals(""))) && (rs.getString("refnews") != null)) // on a deja des news
			{
				int i = Integer.parseInt(rs.getString("refnews"));
				i++;
				String nb = "";
				int j = 1;
				while (Integer.toString(i).length() > j)
				{
					nb += "0";
					j++;
				}
				nb += Integer.toString(i);
				setRefnews(nb);
			}
			else // aucune news 
				setRefnews("001"); // on met le numero 1
		}
		catch (SQLException e)
		{
			erreur = "<b><font color=\"#ff3300\">ERREUR + " + e.toString() + "</font></b>";
		}
	}
}
