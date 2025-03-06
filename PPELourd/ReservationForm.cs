using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPELourd
{
    public partial class ReservationForm : Form
    {
        private List<Reservation> reservations = new List<Reservation>();
        public ReservationForm()
        {
            InitializeComponent();
        }

        private void LoadEquipements()
        {
            string query = "SELECT id, nom FROM Equipement WHERE disponible = 1";
            DataTable dt = BDD.ExecuteQuery(query);

            ComboBoxEquipement.Items.Clear(); // Nettoyer la liste avant de charger

            foreach (DataRow row in dt.Rows)
            {
                ComboBoxEquipement.Items.Add(new KeyValuePair<int, string>((int)row["id"], row["nom"].ToString()));
            }

            ComboBoxEquipement.DisplayMember = "Value";
            ComboBoxEquipement.ValueMember = "Key";
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            if (User.UtilisateurConnecte != null)
            {
                labelUtilisateur.Text = $"Connecté en tant que : {User.UtilisateurConnecte.Pseudo}";
                LoadEquipements(); // Charger les équipements lors du chargement du formulaire
            }
            else
            {
                MessageBox.Show("Aucun utilisateur connecté.");
                this.Close();
            }
        }
        private void ButtonReservation_Click(object sender, EventArgs e)
        {
            if (ComboBoxEquipement.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un équipement.");
                return;
            }

            if (User.UtilisateurConnecte == null)
            {
                MessageBox.Show("Utilisateur non connecté.");
                return;
            }

            var equipement = (KeyValuePair<int, string>)ComboBoxEquipement.SelectedItem;
            int userId = User.UtilisateurConnecte.Id;
            DateTime dateDebut = DateTime.Now;
            DateTime dateFin = dateDebut.AddDays(7); // Exemple : réservation pour 7 jours

            try
            {
                string insertQuery = "INSERT INTO Reservation (user_id, equipement_id, date_debut, date_fin) " +
                                     "VALUES (@userId, @equipementId, @dateDebut, @dateFin)";

                BDD.ExecuteQueryWithParameters(insertQuery, new Dictionary<string, object>
                {
                    { "@userId", userId },
                    { "@equipementId", equipement.Key },
                    { "@dateDebut", dateDebut },
                    { "@dateFin", dateFin }
                });

                // Désactiver l'équipement après réservation
                string updateQuery = "UPDATE Equipement SET disponible = 0 WHERE id = @equipementId";
                BDD.ExecuteQueryWithParameters(updateQuery, new Dictionary<string, object>
                {
                    { "@equipementId", equipement.Key }
                });

                MessageBox.Show("Réservation enregistrée !");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la réservation : {ex.Message}");
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
