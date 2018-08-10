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

		public static bool Loggin(OutilsData outilsD)
		{
			string pseudo;
			string motDePasse;
			
			CenterText("Bienvenue chez Bo'Voyage\n", ConsoleColor.Green);
			CenterText("Veuillez vous Identifier\n", ConsoleColor.Green);
			pseudo = PosezQuestionObligatoire("Pseudo : ", ConsoleColor.Green);
			motDePasse = EcrireMDP();
			while (!outilsD.Connexion(pseudo, motDePasse))
			{
				Console.Clear();
				AffichezMessage("Pseudo ou Mot de passe invalide...veuillez Réessayer\n", ConsoleColor.Red);
				pseudo = PosezQuestionObligatoire("Votre pseudo : ", ConsoleColor.Green);
				motDePasse = EcrireMDP();
			}
			AffichezMessage("Connexion réussi\nBienvenue " + pseudo, ConsoleColor.Yellow);
			return (true);
		}

		public static string EcrireMDP()
		{
			string mdp = "";

			string message = ("Votre Mot de passe : ");
			while (string.IsNullOrWhiteSpace(mdp))
			{
				Console.BackgroundColor = ConsoleColor.Black;
				AffichezMessage(message,ConsoleColor.Green);
				Console.ForegroundColor = ConsoleColor.White;
				Console.BackgroundColor = ConsoleColor.White;
				mdp = Console.ReadLine();
			}
			Console.ResetColor();
			return mdp;
		}

		public static string AffichageMenu()
		{
            string choix;
            Console.Clear();
			AffichezMessage("\tMENU PRINCIPAL\n", ConsoleColor.Gray);
			AffichezMessage("\n1- GESTION DES CLIENTS", ConsoleColor.Cyan);
			AffichezMessage("\n2- GESTION DES VOYAGES", ConsoleColor.Cyan);
			AffichezMessage("\n3- GESTION DES DOSSIER", ConsoleColor.Cyan);
            choix = Console.ReadLine();
            return choix;
		}



		public static void CenterText(string text)
		{
			int winWidth = (Console.WindowWidth / 2 - 15);
			Console.WriteLine(new string(' ', winWidth) + $"{text.PadRight(30)}\n");
		}

		public static void CenterText(string text, ConsoleColor couleur)
		{
			Console.ForegroundColor = couleur;
			int winWidth = (Console.WindowWidth / 2 - 15);
			Console.WriteLine(new string(' ', winWidth) + $"{text.PadRight(30)}\n");
			Console.ResetColor();
		}
	}
}
