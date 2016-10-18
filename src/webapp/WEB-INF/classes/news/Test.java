package news;
/**
 * @author gregory
 *
 * To change this generated comment edit the template variable "typecomment":
 * Window>Preferences>Java>Templates.
 * To enable and disable the creation of type comments go to
 * Window>Preferences>Java>Code Generation.
 */
public class Test
{
	public static void main(String[] args)
	{
/*		BeanEnregistrer be = new BeanEnregistrer();
	//	be.setRefnews("003");
		be.annee="01";
		be.mois="06";
		be.jour="11";
		be.corpTexte="Blabla3";
		be.titre="Titre 3";
		be.reftheme="002";
		be.refform="001";
		be.setModif("0");
		be.lien="www.google.fr";
		be.online="1";
		be.dateParu="01-05-02";
		
		System.out.println(be.enregistrer());
*/
/*		BeanAffNews ban = new BeanAffNews();
		ban.setRefnews("008");
		ban.connect();
		/*
		System.out.println("News\n Titre : "+ban.getTitre()
					+"\nTheme : "+ban.getTheme()
					+"\nCorps : "+ban.getCorps()
					+"\nDate : "+ban.getDate()
					+"\nFormation : "+ban.getForm()
					+"\nLien : "+ban.getLien());
		*/
/*		System.out.println(ban.affiche());
		ban.close();
	
		BeanDetail bd = new BeanDetail();
		bd.setNumInfo("1");
		System.out.println(bd.getDetail());
*/
		BeanAffListe bal = new BeanAffListe();

		bal.setRang(1);
		bal.setRefform("999");
		bal.setReftheme("999");
		int max = bal.maxRefNews();
		
		bal.connect();
		for(int i=max; i>(max-5); i--)
		{
			System.out.println("news "+i+"/"+max+"\n");
			System.out.println(bal.newsSuivante());
		}
		bal.close();
		
		
	}


			
}
