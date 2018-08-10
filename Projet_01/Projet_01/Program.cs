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
                        MenuClients(outils);                     
                        break;
                    case "2":
                        MenuVoyages(outils);
                        break;
                    case "3":
                        MenuDossiers();
                        break;
                    case "Q":
                    case "q":
                        OutilsApplication.CenterText("QUITTER");

                        Destination dest = new Destination();
                        dest.Nom = "truc";
                        outils.destinations.Add(dest);
                        Voyage vovo = new Voyage();
                        vovo.Destination = outils.destinations.FirstOrDefault();
                        outils.voyages.Add(vovo);


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


        static void MenuClients(OutilsData outils)
        {
            bool continuer = true;
            while (continuer)
            {
                var choix = OutilsApplication.AffichageMenuClient();
                switch (choix)
                {
                    case "1":
                        OutilsMetier.ListerClients(outils);
                        Console.ReadKey();
                        break;
                    case "2":
                        OutilsMetier.CreerClient(outils);
                        Console.ReadKey();
                        break;
                    case "3":
                        OutilsMetier.SupprimerClients(outils);
                        Console.ReadKey();
                        break;
                    case "Q":
                    case "q":
                        OutilsApplication.CenterText("REVENIR AU MENU PRINCIPAL");
                        return;

                }
            }
          
        }

        static void MenuVoyages(OutilsData outils)
        {
            bool continuer = true;
            while (continuer)
            {
                var choix = OutilsApplication.AffichageMenuVoyage();
                switch (choix)
                {
                    case "1":
                        OutilsMetier.ListerVoyages(outils);
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
                        break;
                    case "3":
                        OutilsApplication.CenterText("CREER UN DOSSIER\n");
                        break;
                    case "4":
                        OutilsApplication.CenterText("SUPPRIMER UN DOSSIER\n");
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
