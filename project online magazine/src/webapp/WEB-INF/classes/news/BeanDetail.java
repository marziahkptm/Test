package news;
import java.sql.*;


public class BeanDetail

{
  

   String erreur="OK";
   String titre="";
   String corps="";
   String lien="";
   java.sql.Date date;
   String libelForm="1";
   String libelTheme="2";
   public Formation form=new Formation();
   public Theme theme=new Theme();
   public void setNumInfo(String numInfo)
   {
   	 try
   	 {
		Connection cnx=Connexion.connect();
		Statement requete=cnx.createStatement();
        ResultSet rs = requete.executeQuery("SELECT * FROM news where refnews="+numInfo);
        rs.next();
        titre=rs.getString("titre");
		corps=rs.getString("corps");        
		lien=rs.getString("lien");
		date=rs.getDate("dateParu");        
        libelForm=getForm(rs.getString("refform"));
		libelTheme=getTheme(rs.getString("reftheme"));        
        requete.close();
        cnx.close();
	 }
	 catch(Exception e)
     {
     	erreur=e.toString();	
     }
   	
   }
   public String getTitre()
   {
     return titre;
   }

   public String getCorps()
   {
   	 return news.Outils.prepareAffichage(corps);
   }

public String getLien()
{
	if (lien.lastIndexOf("http") != -1)
		return "<a href=\"" + lien + "\">" + lien + "</a>";
	else
		return "<a href=\"http://" + lien + "\">" + lien + "</a>";
}
   public String getDate()
   {
     return news.Outils.redate(date);	
   }
 
   public String getForm(String refForm) 
   {
	 return form.getLibel(refForm);
   }
	
   public String getTheme(String refTheme) 
   {
	 return theme.getLibel(refTheme);	
   }
   
   public String getForm() 
   {
	 return libelForm;
   }
	
   public String getTheme() 
   {
	 return libelTheme;	
   }
 
	public String getErreur()
	{
		return erreur;
	}

	public String getDetail()
	{
		// on sort le détail en HTML dans un tableau
		return
		("<table border=\"0\" bgcolor=\"silver\"><tr><td>" + getForm()
		+ "-" + getTheme() + "-"
		+ "Publie le " + getDate()
		+ "</td></tr><tr bgcolor=\"yellow\"><td>"
		+ getTitre()+"</td></tr><tr><td>"
		+ getCorps()+"</td></tr><tr bgcolor=\"white\"><td>"
		+ getLien()+"</td></tr></table><br><br><br><p>"
		+ getErreur()+"</p>");
	}
	

}
