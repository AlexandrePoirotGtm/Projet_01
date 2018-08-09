using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{

	class OutilsData
	{
		const string CheminFichierDest = @"...\Destination.txt";
		const string CheminFichierVoya = @"...\Voyages.txt";
		const string CheminFichierDoss = @"...\Dossier.txt";
		const string CheminFichierCli = @"...\Clients.txt";
		const string CheminFichierPart = @"...\Participants.txt";
		const string CheminFichierComm = @"...\Commerciaux.txt";


		private List<Destination> destinations;
		private List<Voyage> voyages;
		private List<Dossier> dossiers;
		private List<Client> clients;
		private List<Participant> partipants;
		private List<Commerciaux> commerciaux;

		public void RemplirClient()
		{
			
		}


	}
}
