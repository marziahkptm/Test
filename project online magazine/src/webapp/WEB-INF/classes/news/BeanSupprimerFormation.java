	package news;
	import java.lang.String;
	import java.sql.*;

	public class BeanSupprimerFormation
	{
		public String refform="";
		public String resultat="La formation est bien supprimee";	
	       
		public String getResultat()
		{
			try{
			Connection cnx=Connexion.connect();
			Statement requete=cnx.createStatement();
		
				requete.executeUpdate("DELETE from formation Where refform='"+refform+"'");
				requete.close();
				cnx.close();
			   }
			catch(Exception e)
			{	
				resultat="Probleme lors de la suppression : "+e.toString();
			}
			
			return resultat;
		}

		public void setRefform(String pol)
		{
			refform=pol;
		
		}
	}