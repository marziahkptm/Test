package news;
import java.sql.*;


public class Connexion
{
   private static Connexion singleton=null;
   private Connexion()
   {
		try
		{
			DriverManager.registerDriver(new com.ibm.as400.access.AS400JDBCDriver());
		  //Class.forName("com.ibm.as400.access.AS400JDBCDriver").newInstance();
        }
	    catch(Exception e)
        {System.out.println("erreur dans Connexion : "+e.toString());
        }
   	
   }
   
   public static Connection connect() 
   {	
    Connection connexion=null;
  	try{
  	if(singleton==null)
  		singleton=new Connexion();
	String url="jdbc:as400://My_IP_@/my_Librery;date format=ISO";
	String login="lolo";
	String password="my_pass";
	DriverManager.registerDriver(new com.ibm.as400.access.AS400JDBCDriver());
	connexion=(Connection) DriverManager.getConnection(url,login,password);
	//stmt=(Statement) conn.createStatement();
  	
    ///connexion = DriverManager.getConnection("jdbc:mysql://localhost/bdd?user=root");


       }
	catch(Exception e)
    {}
    return connexion;
   }    
   
}
