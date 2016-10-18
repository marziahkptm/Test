package news;
import java.lang.String;
import java.sql.*;



public class BeanOnline
{

	private String online="0";
	private String refnews="";
	
	public String enregistrer()	
	{	String erreur="";
		try{
		if(refnews.equals(""))
			throw new Exception("refnews inexistant");
		Connection cnx=Connexion.connect();
	 	Statement requete=cnx.createStatement();
		String sql;
		  sql="UPDATE news set enligne='"+online+"' "+"WHERE refnews='"+refnews+"'";
		requete.executeUpdate(sql);
		System.out.println("sql : "+sql);
		requete.close();
		cnx.close();
		}
		catch(Exception e)
		{System.out.println("erreur beanOnline : "+e.toString());}
			 
		return erreur;
	}

	public void setRefnews(String refnews)
	{
		this.refnews=refnews;	
	}
	
	public void setOnline(String online)
	{
		  this.online=online;
	}
	
}