package news;
import java.sql.*;
import java.util.*;


public class Theme

{
    ArrayList libel=new ArrayList();
	ArrayList reftheme=new ArrayList();

	String pol="";
	Theme()
	{
	
	    try{
		//ouverture de connexion et requete
		Connection cnx=Connexion.connect();
		Statement requete=cnx.createStatement();
		String query=("SELECT * FROM theme ");
		ResultSet rs1 = requete.executeQuery(query);
		while (rs1.next())
		{
			libel.add(rs1.getString("libeltheme"));
			reftheme.add(rs1.getString("reftheme"));
			
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
		int index=reftheme.indexOf(pol);
		return (String) libel.get(index);
	}

	public String getRef(String lop)
	{
		int index=libel.indexOf(lop);
		return (String) reftheme.get(index);
	}
}
