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
            Console.Clear();
            Console.WriteLine("AJOUTER UN CONTACT\n");
            var leClient = new Client();
            Console.WriteLine(new string('-', Console.WindowWidth));

            OutilsData outils = new OutilsData();
            var listeClients = outils.GetListeClients();
            PosezQuestion("Entrer le Nom du Client", ConsoleColor.Green);
            leClient.Nom = Console.ReadLine();
            PosezQuestion("Entrer le Prénom du Client", ConsoleColor.Green);
            leClient.Prenom = Console.ReadLine();
                listeClients.Add(leClient);
            

            Console.WriteLine("Le nouveau Client a bien été ajouté\n");
            Console.ReadKey();
           // OutilsData.EnregistrerClient(leClient);

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
            Console.Write("{0,-5} |", "M/Mme");
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

        private static void AfficherVoyages(IEnumerable<Voyage> listeVoyages)
        {
            Console.Write("{0,-20} | ", "DESTINATION");
            Console.Write("{0,-10} |", "DATE DEBUT");
            Console.Write("{0,-10} |", "DATE FIN");
            Console.Write("{0,-10} |", "NB MAX Pers.");
            Console.Write("{0,-10} |", "PRIX PERSONNE");
            Console.Write("{0,-10} |", "AGENCE");
            
            Console.WriteLine();
            Console.WriteLine(new string('-', Console.WindowWidth));

            int i = 1;

            foreach (var voyage in listeVoyages)
            {
                Console.Write("{0,-3} ", i);
                Console.Write("{0,-10} ", voyage.Destination);
                Console.Write("{0,-10} ", voyage.DateDeDepart);
                Console.Write("{0,-20} ", voyage.DateDeFin);
                Console.Write("{0,-20} ", voyage.NombresParticipantsMax);
                Console.Write("{0,-20} ", voyage.PrixPersonne);
                Console.Write("{0,-20} ", voyage.Agence);
                
                i++;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            //Console.ReadKey();
        }



        public static void ListerVoyages()
        {
            OutilsData outils = new OutilsData();
            var listeVoyages = outils.GetListeVoyages();
            AfficherVoyages(listeVoyages);
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





        public static string PosezQuestion(string question, ConsoleColor couleur)
        {
            Console.ForegroundColor = couleur;
            Console.WriteLine(question);
            Console.ResetColor();
            return (Console.ReadLine());
        }

    }
}
