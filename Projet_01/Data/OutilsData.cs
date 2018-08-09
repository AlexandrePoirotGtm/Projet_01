using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
                
        const char SeparateurChamps = ';';


        private List<Destination> destinations;
		private List<Voyage> voyages;
		private List<Dossier> dossiers;
		private List<Client> clients;
		private List<Participant> partipants;
		private List<Commerciaux> commerciaux;


		public void SelectionnerVoyage()
        {

        }

        public void CreerDossier()
        {
            //Dossier dossier = new Dossier(Client client.Nom, Voyage voyage, Participant participants);
        }



        private void EcrireFichierClient(string cheminFichier)
        {
            var contenuFichier = new StringBuilder();
            foreach (var client in this.clients)
            {
                contenuFichier.AppendLine(string.Join(
                                            SeparateurChamps.ToString(),
                                            client.Nom,
                                            client.Prenom,
                                            client.Adresse,
                                            client.NuméroTéléphone,
                                            client.Civilite));
                // pseudo ??

                File.WriteAllText(CheminFichierCli, contenuFichier.ToString());
            }
        }


    }
}
