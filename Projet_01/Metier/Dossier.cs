using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
	public class Dossier
	{
		public int NombreDeParticipants { get; set; }
		public double PrixTotal { get; set; }
		public Etat Etat { get; set; }
	}
}
