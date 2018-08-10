using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data
{
	public class Participant : Personne ,IClientèle 
	{
		public int NuméroTéléphone { get ; set; }
		public string Adresse { get; set ; }
        public int Age { get; set; }
		
	}
}
