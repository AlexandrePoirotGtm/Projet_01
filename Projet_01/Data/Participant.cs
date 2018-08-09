using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metier;


namespace Data
{
	public class Participant : Personne ,IClientèle 
	{
		public int NuméroTéléphone { get ; set; }
		public string Adresse { get; set ; }
        public string Age { get; set; }
		
	}
}
