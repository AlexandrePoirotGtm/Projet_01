using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
	class Client : Personne
	{
        public int NumeroDeTelephone { get; set; }
        public string Adresse { get; set; }
        public bool Civilite { get; set; }
	}
}
