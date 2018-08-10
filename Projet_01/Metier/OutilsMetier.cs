using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Metier
{
	public static class OutilsMetier
	{

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        // ===============================  METHODES DE MANIPULATION DES CLIENTS ++++++++++++++++++++++++++++++++++//
        public static void CreerClient()
       {
            //OutilsApplication.AffichezMessage("\n1- Créer un client", ConsoleColor.Cyan);
        }

        public static void ListerClients()
        {
            OutilsData outils = new OutilsData();
            var listeClients = outils.GetListeClients();
            AfficherClients(listeClients);
           

        }

        private static void AfficherClients(IEnumerable<Client> listeClients)
        {
            Console.Write("{0,-3} | ", "ID");
            Console.Write("{0,-10} |", "M/Mme");
            Console.Write("{0,-10} |", "NOM");
            Console.Write("{0,-10} |", "PRENOM");
            Console.Write("{0,-20} |", "ADRESSE");
            Console.Write("{0,-20} |", "NUMERO DE TELEPHONE");
            Console.Write("{0,-10} ", "PSEUDO");
            Console.Write("{0,-10} ", "MOT DE PASSE");

            Console.WriteLine();
            Console.WriteLine(new string('-', Console.WindowWidth));

            int i = 1;

            foreach (var client in listeClients)
            {
                Console.Write("{0,-3} ", i);
                Console.Write("{0,-10} ", client.Civilite);
                Console.Write("{0,-10} ", client.Nom);
                Console.Write("{0,-20} ", client.Prenom);
                Console.Write("{0,-20} ", client.Adresse);
                Console.Write("{0,-20} ", client.NuméroTéléphone);
                Console.Write("{0,-20} ", client.Pseudo);
                Console.Write("{0,-10} \n\n", client.MotDePasse);
                i++;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            //Console.ReadKey();
        }

        public static void SupprimerClients()
        {

        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        // ===============================  METHODES DE MANIPULATION DES VOYAGES ++++++++++++++++++++++++++++++++++//

        public static void ListerVoyages()
        {

        }

        public static void RechercherVoyage()
        {

        }

        public static void SelectionnerVoyage()
        {

        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        // ===============================  METHODES DE MANIPULATION DES DOSSIERS ++++++++++++++++++++++++++++++++++//

        public static void CreerDossier()
        {

        }



        



    }
}
