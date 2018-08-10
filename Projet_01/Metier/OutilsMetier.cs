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
        public static void CreerClient(OutilsData outils)
        {
            Console.Clear();
            Console.WriteLine("AJOUTER UN CONTACT\n");
            var leClient = new Client();
            Console.WriteLine(new string('-', Console.WindowWidth));

            // OutilsData outils = new OutilsData();
            // var listeClients = ;

            leClient.Civilite= PosezQuestion("Mr ou Mme?", ConsoleColor.Green);        
            leClient.Nom = PosezQuestion("Entrer le Nom du Client", ConsoleColor.Green);

            leClient.Prenom = PosezQuestion("Entrer le Prénom du Client", ConsoleColor.Green);
            leClient.Adresse = PosezQuestion("Entrer l'Adresse", ConsoleColor.Green);
            leClient.NuméroTéléphone = PosezQuestion("Entrer le numéro de Tel du Client", ConsoleColor.Green);
            leClient.Pseudo = PosezQuestion("Entrer votre Pseudo", ConsoleColor.Green);
            leClient.MotDePasse = PosezQuestion("Entrer le mMot de Passe", ConsoleColor.Green);
           outils.GetListeClients().Add(leClient);
           outils.EnregistrerClient(leClient);

            Console.WriteLine("Le nouveau Client a bien été ajouté\n");

            Console.ReadKey();
            
            return;
        }


        public static void ListerClients(OutilsData outils)
        {
            Console.Clear();
            Console.WriteLine();
            CenterText("LISTE DES CLIENTS");
            Console.WriteLine();
            Console.WriteLine(new string('=', Console.WindowWidth));
            Console.WriteLine();
            AfficherClients(outils.GetListeClients());
        }

        private static void AfficherClients(List<Client> listeClients)
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


        public static void SupprimerClients(OutilsData outils)
        {
            Console.Clear();
            Console.WriteLine("SUPPRIMER UN CONTACT\n");
            int index;
            
            List<Client> maListe = outils.GetListeClients();
            Console.WriteLine(new string('-', Console.WindowWidth));

            AfficherClients(maListe);


             Console.WriteLine("\nQuel client souhaitez-vous supprimer ?", ConsoleColor.Green);
            var saisie = Console.ReadLine();
            index = int.Parse(saisie);


            if (index - 1 <= maListe.Count() - 1)
            {
                Client client = maListe.ElementAt(index - 1);
                outils.SupprimerClient(client);
                Console.WriteLine("\nLE CONTACT A ETE SUPPRIME\n");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("\nNUMERO DE CONTACT INVALIDE ...\n");
                Console.ReadKey();
                SupprimerClients(outils);
            }


        }



        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        // ===============================  METHODES DE MANIPULATION DES VOYAGES ++++++++++++++++++++++++++++++++++//

        private static void AfficherVoyages(List<Voyage> listeVoyages )
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

            foreach (var voyage in listeVoyages )
            {
                Console.Write("{0,-3} ", i);
                Console.Write("{0,-10} ", voyage.Destination.Nom);
                Console.Write("{0,-10} ", voyage.DateDeDepart);
                Console.Write("{0,-20} ", voyage.DateDeFin);
                Console.Write("{0,-20} ", voyage.NombresParticipantsMax);
                Console.Write("{0,-20} ", voyage.PrixPersonne);
                Console.Write("{0,-20} ", voyage.Agence);
                i++;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static void ListerVoyages(OutilsData outils)
        {
            Console.Clear();
            Console.WriteLine();
            CenterText("LISTE DES VOYAGES");
            Console.WriteLine();
            Console.WriteLine(new string('=', Console.WindowWidth));
            AfficherVoyages(outils.GetListeVoyages());
        }


        public static void CreerNouveauVoyage()
        {
            Console.Clear();
            Console.WriteLine();
            CenterText("EN CONSTRUCTION .......");
        }


        public static void RechercherVoyage()
        {
            Console.Clear();
            Console.WriteLine();
            CenterText("EN CONSTRUCTION .......");
        }


        public static void SelectionnerVoyage()
        {
            Console.Clear();
            Console.WriteLine();
            CenterText("EN CONSTRUCTION .......");
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        // ===============================  METHODES DE MANIPULATION DES DOSSIERS ++++++++++++++++++++++++++++++++++//


        private static void AfficherDossier()
        {
            Console.Write("{0,-20} | ", "NOM CLIENT");
            Console.Write("{0,-10} |", "NOM VOYAGE");
            Console.Write("{0,-10} |", "ETAT");
            Console.Write("{0,-10} |", "NB PARTICIPANTS");
            Console.Write("{0,-10} |", "PRIX TOTAL");
            Console.Write("{0,-10} |", "NUM ID");

            Console.WriteLine();
            Console.WriteLine(new string('=', Console.WindowWidth));
        }

        public static void ListerDossiers(OutilsData outils)
        {
            Console.Clear();
            Console.WriteLine();
            CenterText("LISTE DES DOSSIERS");
            Console.WriteLine();
            Console.WriteLine(new string('=', Console.WindowWidth));
            AfficherDossier();
        }

        public static void RechercherDossier()
        {
            Console.Clear();
            Console.WriteLine();
            CenterText("EN CONSTRUCTION .......");
            Console.ReadKey();
        }

        public static void CreerDossier()
        {
            Console.Clear();
            Console.WriteLine();
            CenterText("EN CONSTRUCTION .......");
            Console.ReadKey();
        }

        public static void SupprimerDossier()
        {
            Console.Clear();
            Console.WriteLine();
            CenterText("EN CONSTRUCTION .......");
            Console.ReadKey();
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//
        //===================================== OUTILS CONSOLE  =========================//
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++//

        public static void CenterText(string text)
        {
            int winWidth = (Console.WindowWidth / 2 - 15);
            Console.WriteLine(new string(' ', winWidth) + $"{text.PadRight(30)}\n");
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
