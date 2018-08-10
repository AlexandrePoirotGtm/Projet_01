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


		private List<Destination> destinations { get; set; }
		private List<Voyage> voyages { get; set; }
		private List<Dossier> dossiers { get; set; }
		private List<Client> clients { get; set; }
		private List<Participant> participants { get; set; }
		private List<Commerciaux> commerciaux { get; set; }



		// =========================== GESTION DES CLIENTS=============================//
		// ===================== Déclaration d'un nouveau client ======================//
		//=============== A METTRE PEUT-ETRE PLUTOT DANS LA COUCHE METIER ============//

		private void InitialiserListeClients()
		{
			if (this.clients == null)
			{
				LireFichierClients();
			}
		}

		public IEnumerable<Client> GetListeClients()
		{
			InitialiserListeClients();
			return this.clients;
		}

		public void EnregistrerClient(Client client)
		{
			InitialiserListeClients();

			if (!this.clients.Contains(client))
			{
				this.clients.Add(client);
			}
			this.EcrireFichierClient();
		}

		public void SupprimerClient(Client client)
		{
			InitialiserListeClients();
			this.clients.Remove(client);
			this.EcrireFichierClient();
		}

		void LireFichierClients()
		{
			// Lire un fichier
			//var cheminFichier = @"...\Clients.txt";
			if (File.Exists(CheminFichierCli))
			{
				IEnumerable<string> lignesFichier = File.ReadLines(CheminFichierCli);
				//var contactsDansFichier = new List<Contact>();
				foreach (var ligneFichier in lignesFichier)
				{
					string[] champs = ligneFichier.Split('\n');
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
			else
			{
				//Ecrire un contenu
				var contenuFichier = new StringBuilder();
				foreach (var client in clients)
				{
					contenuFichier.AppendLine(string.Join(" \n", client.Nom, client.Prenom, client.Adresse, client.NuméroTéléphone));
				}
				File.WriteAllText(CheminFichierCli, contenuFichier.ToString());
			}
			Console.ReadKey();
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


		//public static void EcrireFichier(List<Client> clients)
		//{
		//    StreamWriter fileWriter = new StreamWriter(CheminFichierCli);
		//    foreach (Client a in clients)
		//    {

		//        fileWriter.WriteLine($"Accompagnants:");
		//        fileWriter.WriteLine("nom-" + a.Nom);
		//        fileWriter.WriteLine("prenom-" + a.Prenom);
		//        fileWriter.WriteLine("civilite-" + a.Adresse);
		//        int num = a.NuméroTéléphone;
		//        string numero = num.ToString();
		//        fileWriter.WriteLine("tele-" + numero);
		//        fileWriter.WriteLine("date-" + a.DateDeNaissance);
		//        fileWriter.WriteLine("Id-" + a.Id);
		//        fileWriter.WriteLine("****************");

		//    }
		//    fileWriter.Close();

		//}


		// ========================= GESTION DES PARTICIPANTS =======================//
		// ==========  === = ======== ========= ===== ===== ==========//


		private void InitialiserListeParticipants()
		{
			if (this.participants == null)
			{
				LireFichierParticipants();
			}
		}

		public IEnumerable<Participant> GetListeParticipants()
		{
			InitialiserListeParticipants();
			return this.participants;
		}

		public void EnregistrerParticipants(Participant participant)
		{
			if (!this.participants.Contains(participant))
			{
				this.participants.Add(participant);
			}
			this.EcrireFichierParticipants();
			EcrireFichierParticipants();
		}

		public void SupprimerParticipants(Participant participant)
		{
			InitialiserListeParticipants();
			this.participants.Remove(participant);
			this.EcrireFichierParticipants();
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


				File.WriteAllText(CheminFichierPart, contenuFichier.ToString());
			}
		}

		private void LireFichierParticipants()
		{
			this.participants = new List<Participant>();
			if (File.Exists(CheminFichierPart))
			{
				var lignes = File.ReadAllLines(CheminFichierPart);
				foreach (var ligne in lignes)
				{
					var champs = ligne.Split(SeparateurChamps);

					var participant = new Participant();
					participant.Nom = champs[0];
					participant.Prenom = champs[1];
					participant.Adresse = champs[2];
					string num = participant.NuméroTéléphone.ToString();
					num = champs[3];
					//client.Civilite = champs[4]);  Pseudo ? Mot de passe ?

					participants.Add(participant);
				}
			}
		}


		// ========================= GESTION DES DESTINATIONS =======================//
		// ==========  === = ======== ========= ===== ===== ==========//


		private void InitialiserListeDestinations()
		{
			if (this.destinations == null)
			{
				LireFichierDestinations();
			}
		}

        public IEnumerable<Destination> GetListeDestinations()
        {
            InitialiserListeDestinations();
            return this.destinations;
        }

        public void EnregistrerDestinations(Destination destination)
        {
            if (!this.destinations.Contains(destination))
            {
                this.destinations.Add(destination);
            }
            this.EcrireFichierDestinations();
            EcrireFichierDestinations();
        }

        public void SupprimerDestinations(Destination destination)
        {
            InitialiserListeDestinations();
            this.destinations.Remove(destination);
            this.EcrireFichierDestinations();
        }

        private void EcrireFichierDestinations()
        {
            var contenuFichier = new StringBuilder();
            foreach (var destination in this.destinations)
            {
                contenuFichier.AppendLine(string.Join(
                                            SeparateurChamps.ToString(),
                                            destination.Description,
                                            destination.Nom,
                                            destination.Pays,
                                            destination.Region,
                                            destination.Continent));


                File.WriteAllText(CheminFichierDest, contenuFichier.ToString());
            }
        }

		private void LireFichierDestinations()
		{
			this.destinations = new List<Destination>();
			if (File.Exists(CheminFichierDest))
			{
				var lignes = File.ReadAllLines(CheminFichierDest);
				foreach (var ligne in lignes)
				{
					var champs = ligne.Split(SeparateurChamps);

					var destination = new Destination();
					destination.Nom = champs[0];
					destination.Description = champs[1];
					destination.Continent = champs[2];
					destination.Pays = champs[3];
					destination.Region = champs[4];

					//client.Civilite = champs[4]);  Pseudo ? Mot de passe ?

					destinations.Add(destination);
				}
			}
		}








		// A RAJOUTER AUSSI POUR DESTINATIONS VOYAGE

		public void SelectionnerVoyage(Voyage voyage)
		{
			if (!this.voyages.Contains(voyage))
			{
				this.voyages.Add(voyage);
			}
			this.EcrireFichierVoyage();
			EcrireFichierVoyage();
		}



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


		public bool Connexion(string pseudo, string mdp)
		{
			foreach (ILogger log in commerciaux)
			{
				if (log.Connexion(pseudo, mdp))
					return true;
			}
			return false;
		}




		public void CreerDossier()
		{

		}
	}
}
