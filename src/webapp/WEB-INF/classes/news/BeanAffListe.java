package news;
import java.sql.*;
 
public class BeanAffListe
{
	private String refform = "";
	private String reftheme = "";
	public String refformcourant = "";
	public String refthemecourant = "";
	private int rang;
	public String erreur;
	public String fin = "";
	public Formation form;
	public Theme theme;
	boolean var;
	boolean encore = false;
	Connection cnx;
	Statement requete;
	ResultSet rs1;
	java.sql.Date date;
	String corps;
	String refnews;
	String titre;
	String lien;
	public void connect()
	{
		form = new Formation();
		theme = new Theme();
		String sql;
		try
		{
			cnx = Connexion.connect();
			requete = cnx.createStatement();
			sql = "SELECT * FROM news WHERE enligne=1";
			// si recherche par formation
			if (!refform.equals("999"))
				sql += " AND refform='" + refform + "'";
			// si recherche par theme
			if (!reftheme.equals("999"))
				sql += " AND reftheme='" + reftheme + "'";
			sql += " Order by refnews DESC";
			rs1 = requete.executeQuery(sql);
		}
		catch (NullPointerException e)
		{
			erreur += "Theme ou formation inexistante";
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
	// parcours du resultset
	public boolean hasMoreElements()
	{
		try
		{
			return (rs1.next());
		}
		catch (Exception e)
		{
			System.out.println("erreur next : " + e.toString());
		}
		return false;
	}
	public void nextElement()
	{
		try
		{
			// récupération des données du formulaire en cours
			refformcourant = rs1.getString("refForm");
			refthemecourant = rs1.getString("refTheme");
			refnews = rs1.getString("refnews");
			date = rs1.getDate("dateParu");
			titre = rs1.getString("titre");
			corps = rs1.getString("corps");
			lien = rs1.getString("lien");
			// génération du html
			/*ligne+="<p>"
			     +"<a href=\"Affliste.jsp?refform="+refformcourant+"&reftheme=999\">"+form.toUpperCase()+"</a>"
			     +" - "
			     +"<a href=\"Affliste.jsp?reftheme="+refthemecourant+"&refform=999\">"+theme+"</a> - "
			     + date+"<br>"+"<a href=\"detail.jsp?numInfo="
			     +rs1.getString("refnews")+"\">"+titre+"</a> <br>"
			     +corps+"</p>"+"<br><br><br><br>";
			ligne+="<br>valeur finale de encore : "+encore+"<br>";
			*/
			//limite aux 4 dernieres plus recentes
		}
		catch (Exception e)
		{
			System.out.println("erreur : " + e.toString());
		}
	}
	public String getForm()
	{
		return form.getLibel(refformcourant);
	}
	public String getTheme()
	{
		return theme.getLibel(refthemecourant);
	}
	public String getTitre()
	{
		return titre;
	}
	public String getRefnews()
	{
		return refnews;
	}
	public String getDate()
	{
		return news.Outils.redate(date);
	}
	public String getCorptronc()
	{
		String result;
		try
		{
			result = corps.substring(0, 15);
		}
		catch (Exception e)
		{
			result = corps;
		}
		return result + "...";
	}
	public String getErreur()
	{
		return erreur;
	}
	// setters
	/** définition du theme a rechercher */
	public void setReftheme(String pol)
	{
		reftheme = pol;
	}
	/** définition de la formation a rechercher */
	public void setRefform(String pol)
	{
		refform = pol;
		System.out.println("le refform est : " + refform);
	}
	/** définition du rang */
	public void setRang(int rang)
	{
		this.rang = rang;
	}
	// getters
	/** récupération du theme a rechercher */
	public String getReftheme()
	{
		return reftheme;
	}
	/** récupération de la formation a rechercher */
	public String getRefform()
	{
		return refform;
	}
	/** récupération du rang */
	public int getRang()
	{
		return rang;
	}
	public String getLien()
	{
		if (lien.lastIndexOf("http") != -1)
			return "<a href=\"" + lien + "\">" + lien + "</a>";
		else
			return "<a href=\"http://" + lien + "\">" + lien + "</a>";
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
	public void avance(int nbParPage)
	{
		int i = 0;
		int produit = (rang - 1) * nbParPage;
		while (i < produit)
		{
			try
			{
				rs1.next();
			}
			catch (SQLException e)
			{
				erreur = "Erreur SQL lors de avance() : " + e;
			}
			i++;
		}
	}
	public String liste()
	{
		String liste = "";
		boolean newsExiste = false; // il existe au moins une news ? on initialise à faux
		int nbParPage = 5; // on veut 5 news par page
		avance(nbParPage); // on avance dans le ResultSet 
		boolean encore = hasMoreElements();
		if (encore) // il y a des news
		{
			newsExiste = true; // il y a au moins une news		
		}
		while (encore && (nbParPage > 0)) // on a encore des news et la page n'est pas remplie 
		{
			nextElement(); // on passe au suivant
			liste += "Titre : <A HREF=\"affNews.jsp?refnews=" + getRefnews() + "\">" + getTitre() + "</A><BR>";
			liste += "Date : " + getDate() + "<BR>";
			liste += "Corps : " + getCorptronc() + "<BR>";
			liste += "Formation : " + getForm() + "<BR>";
			liste += "Theme" + getTheme() + "<BR><BR>";
			encore = hasMoreElements();
			nbParPage--; // il nous en faut un de moins pour cette page
		}
		close(); // on ferme la connexion ...
		liste += "<BR>";
		if (!newsExiste) // on n'a pas de news pour cette page
			liste = "Aucune news !";
		if (erreur != null) // on a une erreur
			liste += erreur;
		liste += "<BR>";
		if (rang != 1) // on n'est pas sur la premiere page
			liste += "<A HREF=\"Affliste.jsp?rang=" + (rang - 1) + "&refform=" + refform + "&reftheme=" + reftheme + "\">page precedente</A>     ";
		if ((nbParPage == 0) && encore) // on a une page suivante
			liste += "<A HREF=\"Affliste.jsp?rang=" + (rang + 1) + "&refform=" + refform + "&reftheme=" + reftheme + "\">page suivante</A>";
		return liste;
	}
	public String newsSuivante()
	{
		String liste = "";
		boolean newsExiste = false; // il existe au moins une news ? on initialise à faux
		if (hasMoreElements()) // il y a des news
		{
			newsExiste = true; // il y a au moins une news
			nextElement(); // on passe au suivant
			liste += "<table width=\"100%\" border=\"0\" bgcolor=\"silver\"><tr><td>"
				+ getForm()
				+ "-"
				+ getTheme()
				+ "-"
				+ "Publie le "
				+ getDate()
				+ "</td></tr><tr bgcolor=\"yellow\"><td>"
				+ titre
				+ "</td></tr><tr><td>"
				+ corps
				+ "</td></tr><tr bgcolor=\"white\"><td>";
			if (!(lien.equals("")))
				liste += getLien() + "</td></tr></table><p>";
			else
				liste += "Pas de lien</td></tr></table><p>";
		}
		if (!newsExiste) // on n'a pas de news pour cette page
		{
			System.out.println("ERREUR pas de news");
			liste = " ";
		}
		if (erreur != null) // on a une erreur
			liste += "ERREUR : " + erreur;
		liste += "<BR>";
		return liste;
	}
	public int maxRefNews()
	{
		String s = "";
		try
		{
			Connection cnx = Connexion.connect();
			Statement requete = cnx.createStatement();
			ResultSet rs = requete.executeQuery("SELECT MAX(refnews) FROM news WHERE enligne=1");
			rs.next();
			s = rs.getString(1); // on recupere la premiere colonne
			requete.close();
			cnx.close(); // on ferme ...
		}
		catch (Exception e)
		{
			erreur = e.toString();
		}
		if (s!=null)
			return Integer.parseInt(s);
		else
			return 0;
	}
}
