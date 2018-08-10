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
        static List<Client> clients = new List<Client>();
        
        static void Main(string[] args)
		{
			//Console.WriteLine("Hello World!!!");
			//Console.WriteLine("Hello GTM!!!");
            Client cli = new Client();
			OutilsData outils = new OutilsData();
            OutilsApplication.Loggin(outils.get);
            OutilsApplication.AffichageMenu();
            Console.ReadKey();


             void centerText(string text)
            {
                int winWidth = (Console.WindowWidth / 2 - 15);
                Console.WriteLine(new string(' ', winWidth) + $"{text.PadRight(30)}\n");
            }
            //OutilsData.LectureFichier();



        }
	}
}
