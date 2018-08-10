using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Metier;
using Data;
namespace Application
{
    public static class OutilsApplication
    {
        public static string PosezQuestion(string question)
        {
            Console.WriteLine(question);
            return (Console.ReadLine());
        }

        public static string PosezQuestionObligatoire(string question)
        {
            string laQuestion = PosezQuestion(question);
            while (string.IsNullOrWhiteSpace(laQuestion))
            {
                laQuestion = PosezQuestion(question);
            }
            return laQuestion;
        }

        public static string PosezQuestion(string question, ConsoleColor couleur)
        {
            Console.ForegroundColor = couleur;
            Console.WriteLine(question);
            Console.ResetColor();
            return (Console.ReadLine());
        }

        public static string PosezQuestionObligatoire(string question, ConsoleColor couleur)
        {
            Console.ForegroundColor = couleur;
            string laQuestion = PosezQuestion(question);
            while (string.IsNullOrWhiteSpace(laQuestion))
            {
                laQuestion = PosezQuestion(question);
            }
            Console.ResetColor();
            return laQuestion;
        }

        public static void AffichezMessage(string message, ConsoleColor couleur)
        {
            Console.ForegroundColor = couleur;
            Console.Write(message);
            Console.ResetColor();
        }

        public static bool Loggin()
        {
            string pseudo;
            string motDePasse;
			OutilsData outilsD = new OutilsData();

			AffichezMessage("Bienvenue chez Bo'Voyage\n", ConsoleColor.Green);
            AffichezMessage("Veuillez vous Identifier\n", ConsoleColor.Green);
            pseudo = PosezQuestionObligatoire("Votre pseudo : ",ConsoleColor.Green);
            motDePasse = PosezQuestionObligatoire("Votre Mot de passe : ",ConsoleColor.Green);
            while(!outilsD.Connexion(pseudo,motDePasse))
            {
                Console.Clear();
                AffichezMessage("Pseudo ou Mot de passe invalide...veuillez Réessayer\n",ConsoleColor.Red);
                pseudo = PosezQuestionObligatoire("Votre pseudo : ", ConsoleColor.Green);
                motDePasse = PosezQuestionObligatoire("Votre Mot de passe : ", ConsoleColor.Green);
            }
            AffichezMessage("Connexion réussi\nBienvenue "+pseudo,ConsoleColor.Yellow);
            return (true);
        }

        public static void AffichageMenu()
        {
            Console.Clear();
            AffichezMessage("\tMENU\n",ConsoleColor.Gray);
            AffichezMessage("\n1- Créer un client",ConsoleColor.Cyan);
            AffichezMessage("\n2- Créér un voyage",ConsoleColor.Cyan);
            AffichezMessage("\n3- Gérer un dossier",ConsoleColor.Cyan);
        }

		public static void CenterText(string text)
		{
			int winWidth = (Console.WindowWidth / 2 - 15);
			Console.WriteLine(new string(' ', winWidth) + $"{text.PadRight(30)}\n");
		}
	}
}
