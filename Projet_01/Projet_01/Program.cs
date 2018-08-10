using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


using Metier;
using Data;
namespace Application
{
	class Program
	{
        static void Main(string[] args)
		{
			//Console.WriteLine("Hello World!!!");
			//Console.WriteLine("Hello GTM!!!");
            Client cli = new Client();
			OutilsData outils = new OutilsData();
            OutilsApplication.Loggin(outils);

            bool continuer = true;
            while (continuer)
            {
                var choix = OutilsApplication.AffichageMenu();
                switch (choix)
                {
                    case "1":
                        MenuClients();                     
                        break;
                    case "2":
                        OutilsApplication.CenterText("GESTION DES VOYAGES");
                        MenuVoyages();
                        break;
                    case "3":
                        OutilsApplication.CenterText("GESTION DES DOSSIERS");
                        MenuDossiers();
                        break;
                    case "Q":
                        OutilsApplication.CenterText("QUITTER");
                        return;

                }
            }

           

        }


        static void MenuClients()
        {
            bool continuer = true;
            while (continuer)
            {
                var choix = OutilsApplication.AffichageMenuClient();
                switch (choix)
                {
                    case "1":
                        Console.WriteLine("C'est bon");
                        Console.ReadKey();
                        break;
                    case "2":
                        OutilsApplication.CenterText("CREER UN CLIENT\n");
                        OutilsMetier.CreerClient();
                        break;
                    case "3":
                        OutilsApplication.CenterText("SUPPRIMER UN CLIENT\n");
                        break;
                    case "Q":
                        OutilsApplication.CenterText("REVENIR AU MENU PRINCIPAL");
                        return;

                }
            }
          
        }

        static void MenuVoyages()
        {

        }

        static void MenuDossiers()
        {
            
        }

    }
}
