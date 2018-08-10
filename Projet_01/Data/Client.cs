using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
	public class Client : Personne, IClientèle, ILogger
	{
		//public int NumeroDeTelephone { get; set; }
		public string Adresse { get; set; }
		public string Civilite { get; set; }
		public string NuméroTéléphone { get; set; }
		public string Pseudo { get; set; }
		public string MotDePasse { get; set; }

        bool ILogger.Connexion(string pseudo, string mdp)
        {
            return true;
        }
    }
}
