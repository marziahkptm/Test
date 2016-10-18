/**
 * bean qui permet d'enregistrer une formation ou un théme
 * 
 */
package news;
import java.lang.String;
import java.sql.*;

public class BeanTable 
{
	public String erreur = "<p>Les données sont toutes enregistrées:</p>";
	public String refform = "";
	public String libelform = "";
	public String reftheme = "";
	public String libeltheme = "";
	private boolean modif;
	
	public String EnregistrerFormation()
	{
		try
		{
		Connection cnx = Connexion.connect();
		Statement requete = cnx.createStatement();
		String sql;
		if (modif) // update
			sql =
				"UPDATE formation set libelform='"
					+ libelform
					+ "'"
					+ " WHERE refform='"
					+ refform
					+ "'";
		// nb : on n'update pas la date de parution
		else // insert
			{
			sql =
				"INSERT INTO formation (refform,libelform) "
					+ "VALUES ('"
					+ refform
					+ "', '"
					+ libelform
					+ "')";
			
				}
		System.out.println("sql : " + sql);
		requete.executeUpdate(sql);
		
		requete.close();
		cnx.close();
	}
	catch (Exception e)
	{
		erreur = "<b><font color=\"#ff3300\">ERREUR + " + e.toString() + refform + libelform + "</font></b>";
	}
	return erreur;
}
	public String EnregistrerTheme()
	{
		try
		{
		Connection cnx = Connexion.connect();
		Statement requete = cnx.createStatement();
		String sql;
		if (modif) // update
			sql =
				"UPDATE theme set libeltheme='"
					+ libeltheme
					+"'"
					+ "WHERE reftheme='"
					+ reftheme
					+ "' ";
		// nb : on n'update pas la date de parution
		else // insert
			{
			sql =
				"INSERT INTO theme (reftheme,libeltheme) "
					+ "VALUES ('"
					+ reftheme
					+ "', '"
					+ libeltheme
					+ ")";
			
				}
	
		requete.executeUpdate(sql);
		System.out.println("sql : " + sql);
		requete.close();
		cnx.close();
	}
				
	catch (Exception e)
	{
		erreur = "<b><font color=\"#ff3300\">ERREUR + " + e.toString() + reftheme + libeltheme + "</font></b>";
	}
	return erreur;
}
	public void setrefform(String pol)
	{
		refform = pol;
	}
	public void setlibelform(String pol)
	{
		libelform = pol;
	}
	public void setreftheme(String pol)
	{
		reftheme = pol;
	}
	public void setlibeltheme(String pol)
	{
		libeltheme = pol;
	}
	public void setModif(String pol)
	{
		if (pol.equals("1"))
			modif = true;
	}
}
