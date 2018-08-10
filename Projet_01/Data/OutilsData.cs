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

		const char SeparateurChamps = ';';


		private List<Destination> destinations = new List<Destination>();
		private List<Voyage> voyages = new List<Voyage>();
		private List<Dossier> dossiers = new List<Dossier>();
		private List<Client> clients = new List<Client>();
		private List<Participant> participants = new List<Participant>();
		private List<Commerciaux> commerciaux = new List<Commerciaux>();

		public OutilsData()
		{
            InitialiserListeDestinations();
            InitialiserListeClients();
            InitialiserListeParticipants();
            InitialiserListeCommerciaux();
            InitialiserListeVoyages();
		}

		 public void Testament()
		{
			EcrireFichierClient();
			EcrireFichierCommerciaux();
			EcrireFichierDestinations();
			EcrireFichierParticipants();
			EcrireFichierVoyages();
		}

		// =========================== GESTION DES CLIENTS=============================//
		// ===================== Déclaration d'un nouveau client ======================//
		//=============== A METTRE PEUT-ETRE PLUTOT DANS LA COUCHE METIER ============//

		private void InitialiserListeClients()
		{
			if (File.Exists(CheminFichierCli))
			{
				LireFichierClients();
			}
            else
            {
                File.Create(CheminFichierCli);
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
			
				IEnumerable<string> lignesFichier = File.ReadLines(CheminFichierCli);
            //var contactsDansFichier = new List<Contact>();
            foreach (var ligneFichier in lignesFichier)
            {
                string[] champs = ligneFichier.Split('\n');
                var client = new Client();
                client.Civilite = bool.Parse(champs[0]);
                client.Nom = champs[1];
                client.Prenom = champs[2];
                client.Adresse = champs[3];
                string num = client.NuméroTéléphone.ToString();
                num = champs[4];
                
                client.Pseudo = champs[5];
                client.MotDePasse = champs[6];

                clients.Add(client);
            }
		}

		public void EcrireFichierClient()
		{
			var contenuFichier = new StringBuilder();
			foreach (var client in this.clients)
			{
				contenuFichier.AppendLine(string.Join(
											SeparateurChamps.ToString(),
                                            client.Civilite,
                                            client.Nom,
											client.Prenom,
											client.Adresse,
											client.NuméroTéléphone,
                                            client.Pseudo,
                                            client.MotDePasse
											));
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
			if (File.Exists(CheminFichierPart))
			{
				LireFichierParticipants();
			}
            else
            {
                File.Create(CheminFichierPart);
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
			//EcrireFichierParticipants();
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


		// ========================= GESTION DES DESTINATIONS =======================//
		// ==========  === = ======== ========= ===== ===== ==========//


		private void InitialiserListeDestinations()
		{
			if (File.Exists(CheminFichierDest))
			{
				LireFichierDestinations();
			}
            else
            {
                File.Create(CheminFichierDest);
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
           // EcrireFichierDestinations();
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

        // ========================= GESTION DES COMMERCIAUX =======================//
        // ========================= === = ======== ========= ===== ===== ==========//

        public IEnumerable<Commerciaux> GetListeCommerciaux()
        {
            InitialiserListeCommerciaux();
            return this.commerciaux;
        }

        private void InitialiserListeCommerciaux()
        {
            if (File.Exists(CheminFichierComm))
            {
                LireFichierCommerciaux();
            }
            else
            {
                File.Create(CheminFichierComm);
            }
        }

        public void EnregistrerCommerciaux(Commerciaux commercial)
        {
            if (!this.commerciaux.Contains(commercial))
            {
                this.commerciaux.Add(commercial);
            }
            this.EcrireFichierCommerciaux();
            //EcrireFichierCommerciaux();
        }

        private void LireFichierCommerciaux()
        {
            //this.commerciaux = new List<Commerciaux>();
            
                var lignes = File.ReadAllLines(CheminFichierComm);
                foreach (var ligne in lignes)
                {
                    var champs = ligne.Split(SeparateurChamps);

                    var commercial = new Commerciaux();
                    commercial.Nom = champs[0];
                    commercial.Prenom = champs[1];
                    commercial.Pseudo = champs[2];
                    commercial.MotDePasse = champs[3];
                    

                    //client.Civilite = champs[4]);  Pseudo ? Mot de passe ?

                    commerciaux.Add(commercial);
                }
           
        }

        private void EcrireFichierCommerciaux()
        {
            var contenuFichier = new StringBuilder();
            foreach (var commercial in this.commerciaux)
            {
                contenuFichier.AppendLine(string.Join(
                                            SeparateurChamps.ToString(),
                                            commercial.Nom,
                                            commercial.Prenom,
                                            commercial.Pseudo,
                                            commercial.MotDePasse));


                File.WriteAllText(CheminFichierComm, contenuFichier.ToString());
            }
        }


        // ========================= GESTION DES VOYAGES =======================//
        // ========================= === = ======== ========= ===== ===== ==========//

        public IEnumerable<Voyage> GetListeVoyages()
        {
            InitialiserListeVoyages();
            return this.voyages;
        }

        private void InitialiserListeVoyages()
        {
            if (File.Exists(CheminFichierVoya))
            {
                LireFichierVoyages();
            }
            else
            {
                File.Create(CheminFichierVoya);
            }
        }

        public void EnregistrerVoyages(Voyage voyage)
        {
            if (!this.voyages.Contains(voyage))
            {
                this.voyages.Add(voyage);
            }
            this.EcrireFichierVoyages();
            //EcrireFichierCommerciaux();
        }

        private void LireFichierVoyages()
        {
            this.voyages = new List<Voyage>();
            
                var lignes = File.ReadAllLines(CheminFichierVoya);
                foreach (var ligne in lignes)
                {
                    var champs = ligne.Split(SeparateurChamps);

                    var voyage = new Voyage();
                    voyage.DateDeDepart = DateTime.Parse(champs[0]);
                    voyage.DateDeFin = DateTime.Parse(champs[1]);
                    voyage.PrixPersonne = double.Parse(champs[2]);
                    voyage.NombresParticipantsMax = int.Parse(champs[3]);
                    voyage.Agence = champs[4];
                   // voyage.Destination = champs[5];
                    voyages.Add(voyage);
                }
           
        }

        private void EcrireFichierVoyages()
        {
            var contenuFichier = new StringBuilder();
            foreach (var voyage in this.voyages)
            {
                contenuFichier.AppendLine(string.Join(
                                            SeparateurChamps.ToString(),
                                            voyage.DateDeDepart,
                                            voyage.DateDeFin,
                                            voyage.PrixPersonne,
                                            voyage.NombresParticipantsMax,
                                            voyage.Agence));
                File.WriteAllText(CheminFichierVoya, contenuFichier.ToString());
            }
        }


        // ========================= GESTION DE CONNEXION =======================//
        // ========================= === = ======== ========= ===== ===== ==========//

        public bool Connexion(string pseudo, string mdp)
		{
			//OutilsData outils = new OutilsData();
			//InitialiserListeCommerciauxs();
			Commerciaux George = new Commerciaux();
			George.Pseudo = pseudo;
			George.MotDePasse = mdp;
			George.Nom = "Doggo";
			George.Prenom = "George";
			
			commerciaux.Add(George);

			foreach (Commerciaux com in commerciaux)
			{
				Console.WriteLine(com.Pseudo);
			}
			foreach (ILogger log in commerciaux)
			{
				if (log.Connexion(pseudo, mdp))
					return true;
			}
			return false;
		}

	}
}
