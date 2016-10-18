package news;
	import java.lang.String;
	import java.sql.*;
 
	public class BeanAfficheFormation
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
				ResultSet resultatRequete = requete.executeQuery("SELECT * FROM formation");
				String ref = "";
				tableau = "";
				while (resultatRequete.next())
				{
					ref = resultatRequete.getString("refform");
					tableau += "<tr><td width=\"12%\">"
						+ resultatRequete.getString("refform")
						+ "</td>"
						+ "<td width=\"16%\">"
						+ resultatRequete.getString("libelform")
						+ "</td>"
						+ "<td width=\"14%\"><a href=\"modifierformation.jsp?refform="
						+ ref
						+ "&modif=1\">Cliquez la</a></td>"
						+ "<td width=\"16%\"><a href=\"SupprimerFormation.jsp?refform="
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
				erreur = "Formation inexistante";
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
			public String getErreur()
		{
			return erreur;
		}
		
	}