﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
	class Voyage
	{
		public DateTime DateDeDepart { get; set; }
		public DateTime DateDeFin { get; set; }
		public double PrixPersonne { get; set; }
		public int NombresParticipantsMax { get; set; }
		public string Agence { get; set; }
	}
}
