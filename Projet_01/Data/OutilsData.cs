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

            //var dossier = new Dossier();
        }

        private void LireFichierClient()
        {
            this.clients = new List<Client>();
            if (File.Exists(CheminFichierCli))
            {
                var lignes = File.ReadAllLines(CheminFichierCli);
                foreach (var ligne in lignes)
                {
                    var champs = ligne.Split(SeparateurChamps);

                    var client = new Client();
                    client.Nom = champs[0];
                    client.Prenom = champs[1];
                    client.Adresse = champs[2];
                    string num = client.NuméroTéléphone.ToString();
                    num= champs[3];
                    //client.Civilite = champs[4]);  

                    clients.Add(client);
                }
            }
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
