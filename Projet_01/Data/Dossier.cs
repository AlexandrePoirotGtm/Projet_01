using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Data
{
	public class Dossier
	{
		public int NombreDeParticipants { get; set; }
		public double PrixTotal { get; set; }
		public Etat Etat { get; set; }
		public IEnumerable<Participant> Participants;
		public Client Client { get; set; }
		public Voyage Voyage { get; set; }
		public int Id { get; set; }

		public Dossier(Client client,Voyage voyage, List<Participant> listParticipants)
		{
			Client = client;
			Voyage = voyage;
			Participants = listParticipants;
			NombreDeParticipants = Participants.Count();
			PrixTotal = Voyage.PrixPersonne;
			if (NombreDeParticipants != 0)
				CalculPrixTotal();

			Random rando = new Random();
			Id = rando.Next(1,1000);
		}

		 ~Dossier()
		{
			Console.WriteLine("Le dossier a bien été effacé");
			Console.ReadKey();
		}
		private void CalculPrixTotal()
		{
			
			foreach (Participant parti in Participants)
			{
				if (parti.Age < 12)
				{
					PrixTotal =+ Voyage.PrixPersonne*0.6;
				}
				else
				PrixTotal =+ Voyage.PrixPersonne;
			}
		}
	}
}
