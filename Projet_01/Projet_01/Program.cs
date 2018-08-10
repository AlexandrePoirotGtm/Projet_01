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
                        MenuVoyages();
                        break;
                    case "3":
                        MenuDossiers();
                        break;
                    case "Q":
                    case "q":
                        OutilsApplication.CenterText("QUITTER");
                        outils.Testament();
                        return;
                    default:
                        Console.WriteLine("Choix invalide, recommencez");
                        Console.ReadKey();
                        OutilsApplication.AffichageMenu();
                        break;
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
                        OutilsMetier.ListerClients();
                        Console.ReadKey();
                        break;
                    case "2":
                        OutilsMetier.CreerClient();
                        Console.ReadKey();
                        break;
                    case "3":
                        OutilsMetier.SupprimerClients();
                        Console.ReadKey();
                        break;
                    case "Q":
                    case "q":
                        OutilsApplication.CenterText("REVENIR AU MENU PRINCIPAL");
                        return;

                }
            }
          
        }

        static void MenuVoyages()
        {
            bool continuer = true;
            while (continuer)
            {
                var choix = OutilsApplication.AffichageMenuVoyage();
                switch (choix)
                {
                    case "1":
                        OutilsMetier.ListerVoyages();
                        Console.ReadKey();
                        break;
                    case "2":
                        OutilsMetier.RechercherVoyage();
                        Console.ReadKey();
                        break;
                    case "Q":
                    case "q":
                        OutilsApplication.CenterText("REVENIR AU MENU PRINCIPAL");
                        return;

                }
            }
        }

        static void MenuDossiers()
        {
            bool continuer = true;
            while (continuer)
            {
                var choix = OutilsApplication.AffichageMenuDossier();
                switch (choix)
                {
                    case "1":
                        OutilsApplication.CenterText("LISTE DES DOSSIERS\n");
                        Console.ReadKey();
                        break;
                    case "2":
                        OutilsApplication.CenterText("RECHERCHER UN DOSSIER\n");
                        OutilsMetier.CreerClient();
                        break;
                    case "3":
                        OutilsApplication.CenterText("CREER UN DOSSIER\n");
                        OutilsMetier.CreerClient();
                        break;
                    case "4":
                        OutilsApplication.CenterText("SUPPRIMER UN DOSSIER\n");
                        OutilsMetier.CreerClient();
                        break;
                    case "Q":
                    case "q":
                        OutilsApplication.CenterText("REVENIR AU MENU PRINCIPAL");
                        return;

                }
            }
        }

    }
}
