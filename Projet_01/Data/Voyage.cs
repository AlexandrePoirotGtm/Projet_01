using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
	public class Voyage
	{
		public DateTime? DateDeDepart { get; set; }
		public DateTime? DateDeFin { get; set; }
		public double PrixPersonne { get; set; }
		public int NombresParticipantsMax { get; set; }
		public string Agence { get; set; }
		public Destination Destination { get; set; }

        public Voyage()
        {
            DateDeDepart = DateTime.Parse("01/01/0001");
            DateDeFin = DateTime.Parse("01/01/0001");
            NombresParticipantsMax = 0;
            PrixPersonne = 0;
            Agence = "Agence";
        }

		public Destination RecupDest(string liste, char separateurChamps)
		{
			var champs = liste.Split(separateurChamps);

			Destination = new Destination();
			Destination.Nom = champs[0];
			Destination.Description = champs[1];
			Destination.Continent = champs[2];
			Destination.Pays = champs[3];
			Destination.Region = champs[4];

			return Destination;
		}

		public StringBuilder SaveDest(char SeparateurChamps)
		{
			var detailDest = new StringBuilder();
			detailDest.AppendLine(string.Join(SeparateurChamps.ToString(),
												Destination.Nom,
												Destination.Description,
												Destination.Continent,
												Destination.Pays,
												Destination.Region));
			return detailDest;
		}
	}

}
