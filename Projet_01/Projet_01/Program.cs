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
            OutilsApplication.Loggin();
            OutilsApplication.AffichageMenu();
            Console.ReadKey();
            OutilsMetier.ListerClients();


            
            //OutilsData.LectureFichier();

			

        }
	}
}
