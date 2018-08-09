using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
	public interface ILogger
	{
        string Pseudo { get; set;}
        string MotDePasse { get; set; }

        bool Connexion(string pseudo,string mdp);
    }
}
