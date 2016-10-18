package news;
import java.sql.*;
import java.util.*;
import java.text.DateFormat;

public class Outils
{
	public static String getComboForm()
	{
		return Outils.getComboForm("XXX"); // recherche sans valeur particuliere	
	}
	public static String getComboForm(String valeur)
	{
		String formation="";	
		try{
		Connection cnx=Connexion.connect();
		Statement requete=cnx.createStatement();
		
		ResultSet rs = requete.executeQuery("SELECT refform,libelform FROM formation");
		
		while (rs.next())
		{
			if(valeur.equals(rs.getString("refform")))
				formation+="<option value=\""+rs.getString("refform")+"\" selected>"+rs.getString("libelform") +"</option>";
			else
				formation+="<option value=\""+rs.getString("refform")+"\">"+rs.getString("libelform") +"</option>";
		}
		requete.close();
		cnx.close();
		}
		catch(Exception e)
		{formation="<option>ERREUR</option>"; }
		
		return formation;
		
	}
	
	public static String getComboTheme()
	{
		return Outils.getComboTheme("XXX"); // recherche sans valeur particuliere	
	}
	public static String getComboTheme(String valeur)
	{
		String themes="";
		try {
		Connection cnx=Connexion.connect();
		Statement requete=cnx.createStatement();
		ResultSet rs = requete.executeQuery("SELECT reftheme,libeltheme FROM theme");
		
		while (rs.next())
		{
			if(valeur.equals(rs.getString("reftheme")))
				themes+="<option value=\""+rs.getString("reftheme")+"\" selected>"+rs.getString("libeltheme")+"</option>";
			else
				themes+="<option value=\""+rs.getString("reftheme")+"\">"+rs.getString("libeltheme")+"</option>";

        	}
        	
        	requete.close();
        	cnx.close();
		}
		catch(Exception e)
		{themes="<option>ERREUR</option>";}

		return themes;
	}

	// remplace les retours chariots par des tags <BR>
	public static String prepareAffichage(String chaine)
	{
		String retour = "";
	
		if (chaine!=null)
		{
			int cpt = 0;
			int indexDeChar = chaine.indexOf('\n',cpt);
			
			while (indexDeChar!=-1)
			{
				retour = retour + chaine.substring(cpt,indexDeChar)+"<BR>";
				cpt = indexDeChar + 1;
				indexDeChar = chaine.indexOf('\n',cpt); 	
			}
			retour = retour + chaine.substring(cpt);
		}
		return retour;
	}
	
	// remplace les simples quotes par des \' pour l'enregistrement vers une base sql
	public static String prepareEnreg(String chaine)
	{
		String retour = "";
		
		if (chaine!=null)
		{
			int cpt = 0;
			int indexDeChar = chaine.indexOf('\'',cpt);
			while (indexDeChar!=-1)
			{
				retour = retour + chaine.substring(cpt,indexDeChar)+"\\'";
				cpt = indexDeChar + 1;
				indexDeChar = chaine.indexOf('\'',cpt);
			}
			retour = retour + chaine.substring(cpt);
		}
		return retour;
	}
    	public static String redate(java.sql.Date date)
    	{
    		DateFormat df = DateFormat.getDateInstance(DateFormat.MEDIUM,Locale.FRANCE);
		return df.format(date);	
    	}
  
}