package news;
import java.sql.*;
import java.util.*;


public class Formation
{
	ArrayList libel=new ArrayList();
	ArrayList refform=new ArrayList();

	String pol="";
	public Formation()
	{
	
	    try{
		//ouverture de connexion et requete
		Connection cnx=Connexion.connect();
		Statement requete=cnx.createStatement();
		String query=("SELECT * FROM formation ");
		ResultSet rs1 = requete.executeQuery(query);
		while (rs1.next())
		{
			libel.add(rs1.getString("libelform"));
			refform.add(rs1.getString("refform"));
			
	    }
		
		//fermeture de requete et connexion
		requete.close();
		cnx.close();
		}
	    catch(Exception e)
	    {} 
	}
	
	public String getLibel(String pol)
	{
		int index=refform.indexOf(pol);
		return (String) libel.get(index);
	}	
	public String getRef(String lop)
	{
		int index=libel.indexOf(lop);
		return (String) refform.get(index);
	}
}
	