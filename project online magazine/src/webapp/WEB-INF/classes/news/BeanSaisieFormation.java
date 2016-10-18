package news;
import java.sql.*;
public class BeanSaisieFormation
{
	String refform = "";
	String libelform = "";
	String modif = "0";
	String erreur = new String("<b><font color=\"#66ff00\">OK</font></b>");
	public String getRefForm(String form, Statement requete) throws Exception
	{
		ResultSet rs1 = requete.executeQuery("SELECT libelform FROM formation WHERE refform=\"" + form + "\"");
		return rs1.getString("libelform");
	}
	
	public String getlibelform()
	{
		return libelform;
	}
	public String getrefform()
	{
		return refform;
	}
	
	public void setRefform(String pol)
	{
		refform = pol;
		try
		{
			Connection cnx = Connexion.connect();
			Statement requete = cnx.createStatement();
			ResultSet rs = requete.executeQuery("SELECT * FROM formation where refform='"+pol+"'");
			rs.next();
		//	refform = rs.getString("refform");
			libelform = rs.getString("libelform");
			requete.close();
			cnx.close();
		}
		catch (Exception e)
		{
		}
	}
	public String getModif()
	{
		return modif + "&refform=" + refform;
	}
	
	public void setModif(String pol)
	{
		modif = pol;
	}
	
	public String getErreur()
	{
		return erreur;
	}
}