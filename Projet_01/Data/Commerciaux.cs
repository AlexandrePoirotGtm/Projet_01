using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Data
{
	public class Commerciaux : Personne,ILogger
	{
        public string Pseudo { get; set; }
        public string MotDePasse { get; set; }

        bool ILogger.Connexion(string pseudo, string mdp)
        {
			return(pseudo == Pseudo && MotDePasse == mdp);
        }
	}
}
