using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Data
{

	public class OutilsData
	{
		const string CheminFichierDest = @"...\Destination.txt";
		const string CheminFichierVoya = @"...\Voyages.txt";
		const string CheminFichierDoss = @"...\Dossier.txt";
		const string CheminFichierCli = @"...\Clients.txt";
		const string CheminFichierPart = @"...\Participants.txt";
		const string CheminFichierComm = @"...\Commerciaux.txt";
                
        const char SeparateurChamps = '\n';


        private List<Destination> destinations;
		private List<Voyage> voyages;
		private List<Dossier> dossiers;
		private List<Client> clients;
		private List<Participant> participants;
		private List<Commerciaux> commerciaux;

        private void InitialiserListeClients()
        {
            if (this.clients == null)
            {
                LireFichierClients();
            }
        }

        // =============== GESTION DES CLIENTS==================//
        // ========== Déclaration d'un nouveau client ==========//

        public IEnumerable<Client> GetListeClients()
        {
            InitialiserListeClients();
            return this.clients;
        }

        public void Enregistrer(Client client)
        {
            InitialiserListeClients();

            if (!this.clients.Contains(client))
            {
                this.clients.Add(client);
            }

            this.EcrireFichierClient();
        }

        public void Supprimer(Client client)
        {
            InitialiserListeClients();

            this.clients.Remove(client);
            this.EcrireFichierClient();
        }

        private void LireFichierClients()
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
                    num = champs[3];
                    //client.Civilite = champs[4]);  Pseudo ? Mot de passe ?

                    clients.Add(client);
                }
            }
        }

        private void EcrireFichierClient()
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


        // =============== GESTION DES DESTINATIONS ==================//
        // ==========  === = ======== ========= ===== ===== ==========//





        public void SelectionnerVoyage(Voyage voyage)
        {
            if (!this.voyages.Contains(voyage))
            {
                this.voyages.Add(voyage);
            }
            this.EcrireFichierVoyage();
            EcrireFichierVoyage();
        }

        

        public void EnregistrerParticipants(Participant participant) 
        {
            if (!this.participants.Contains(participant))
            {
                this.participants.Add(participant);
            }
            this.EcrireFichierVoyage();
            EcrireFichierParticipants();
        }




        

        // A RAJOUTER AUSSI POUR PARTICIPANTS DESTINATIONS VOYAGE



        

        private void EcrireFichierVoyage()
        {
            var contenuFichier = new StringBuilder();
            foreach (var voyage in this.voyages)
            {
                contenuFichier.AppendLine(string.Join(
                                            SeparateurChamps.ToString(),
                                            voyage.Destination,
                                            voyage.DateDeDepart,
                                            voyage.DateDeFin,
                                            voyage.PrixPersonne,
                                            voyage.NombresParticipantsMax));
                // pseudo ??

                File.WriteAllText(CheminFichierVoya, contenuFichier.ToString());
            }
        }

        private void EcrireFichierParticipants()
        {
            var contenuFichier = new StringBuilder();
            foreach (var participant in this.participants)
            {
                contenuFichier.AppendLine(string.Join(
                                            SeparateurChamps.ToString(),
                                            participant.Age,
                                            participant.Nom,
                                            participant.Prenom,
                                            participant.NuméroTéléphone,
                                            participant.Adresse));
                // pseudo ??

                File.WriteAllText(CheminFichierPart, contenuFichier.ToString());
            }
        }





        public void CreerDossier()
        {

        }
    }
}
