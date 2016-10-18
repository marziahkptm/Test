package news;
import java.lang.String;
import java.sql.*;



public class BeanSupprimer
{
	public String refnews="";
	public String resultat="La news est bien supprimee";	
       
	public String getResultat()
	{
		try{
		Connection cnx=Connexion.connect();
		Statement requete=cnx.createStatement();
	
			requete.executeUpdate("DELETE from news Where refnews='"+refnews+"'");
			requete.close();
			cnx.close();
		   }
		catch(Exception e)
		{
			resultat="Probleme lors de la suppression : "+e.toString();
		}
		
		return resultat;
	}

	public void setRefnews(String pol)
	{
		refnews=pol;
	
	}
}