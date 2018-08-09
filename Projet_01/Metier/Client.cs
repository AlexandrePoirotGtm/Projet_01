using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
	public class Client : Personne, IClientèle, ILogger
	{
		public int NumeroDeTelephone { get; set; }
		public string Adresse { get; set; }
		public bool Civilite { get; set; }
		public int NuméroTéléphone { get; set; }
		public string Pseudo { get; set; }
		public string MotDePasse { get; set; }
	}
}
