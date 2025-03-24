using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPELourd
{

    public partial class Dashboard : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=ppelourd;uid=donavan;pwd=dodo;");
        string server = "localhost";
        string uid = "donavan";
        string password = "dodo";
        string database = "ppelourd";
        private readonly int idCategorie;

        private string GetConnectionString()
        {
            return $"server={server};uid={uid};pwd={password};database={database}";
        }
        public Dashboard()
        {
            InitializeComponent();

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Récupérer les valeurs des colonnes de la ligne cliquée
                int idReservation = Convert.ToInt32(DataGridView1.Rows[e.RowIndex].Cells["idReservation"].Value);
                int idEquipement = Convert.ToInt32(DataGridView1.Rows[e.RowIndex].Cells["idEquipement"].Value);
                string nomEquipement = DataGridView1.Rows[e.RowIndex].Cells["Equipement"].Value.ToString();
                string nomCategorie = DataGridView1.Rows[e.RowIndex].Cells["Categorie"].Value.ToString();
                string utilisateur = DataGridView1.Rows[e.RowIndex].Cells["Utilisateur"].Value.ToString();
                DateTime dateDebut = Convert.ToDateTime(DataGridView1.Rows[e.RowIndex].Cells["DateDebut"].Value);
                DateTime dateRetour = Convert.ToDateTime(DataGridView1.Rows[e.RowIndex].Cells["DateRetour"].Value);



                // Par exemple, ouvrir un formulaire de réservation avec ces informations
                ReservationForm reservationForm = new ReservationForm(idEquipement, idCategorie, idReservation, nomCategorie, nomEquipement, true);
                reservationForm.ShowDialog();
            }
        }
       




        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            

        }


        private void AfficherTable_Click(object sender, EventArgs e)
        {
            int idUtilisateur = User.GetutilisateurConnecte()?.Id ?? 0;

            if (idUtilisateur == 0)
            {
                MessageBox.Show("Aucun utilisateur connecté.");
                return;
            }

            string conString = GetConnectionString();

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = @"
                SELECT 
                    r.id AS idReservation,  -- Ajoutez la colonne IDReservation
                    r.equipement_id AS idEquipement,  -- Ajoutez l'ID de l'équipement
                    r.date_debut AS DateDebut,
                    r.date_fin AS DateRetour,
                    u.pseudo AS Utilisateur, 
                    e.nom AS Equipement, 
                    c.nom AS Categorie
                FROM reservation r
                INNER JOIN equipement e ON r.equipement_id = e.id
                INNER JOIN categorie c ON e.categorie_id = c.id
                INNER JOIN user u ON r.user_id = u.id
                WHERE r.user_id = @idUtilisateur";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            DataGridView1.DataSource = dt;  // Remplacez DataGridView1 par DataGridView2

                            // Vérifiez si la colonne existe avant de la manipuler
                            if (DataGridView1.Columns.Contains("idReservation"))
                                DataGridView1.Columns["idReservation"].Visible = false;
                            if (DataGridView1.Columns.Contains("idEquipement"))
                                DataGridView1.Columns["idEquipement"].Visible = false;
                            if (DataGridView1.Columns.Contains("Categorie"))
                                DataGridView1.Columns["Categorie"].Visible = false;

                            // Vérification et modification des en-têtes
                            if (DataGridView1.Columns.Contains("Utilisateur"))
                                DataGridView1.Columns["Utilisateur"].HeaderText = "Utilisateur";
                            if (DataGridView1.Columns.Contains("Equipement"))
                                DataGridView1.Columns["Equipement"].HeaderText = "Equipement";
                            if (DataGridView1.Columns.Contains("Categorie"))
                                DataGridView1.Columns["Categorie"].HeaderText = "Catégorie";
                            if (DataGridView1.Columns.Contains("DateDebut"))
                                DataGridView1.Columns["DateDebut"].HeaderText = "Date Début";
                            if (DataGridView1.Columns.Contains("DateRetour"))
                                DataGridView1.Columns["DateRetour"].HeaderText = "Date Fin";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }





        private void ButtonAfficherReservationForm_Click(object sender, EventArgs e)
        {

            // Utiliser des valeurs par défaut pour ouvrir le formulaire
            int idEquipement = 0; // Valeur par défaut
            int idCategorie = 0; // Valeur par défaut
            int idReservation = 0; // Valeur par défaut
            string nomCategorie = "Catégorie par défaut"; // Valeur par défaut
            string nomEquipement = "Équipement par défaut"; // Valeur par défaut
            bool ouvertparDoubleClick = false; // Valeur par défaut
            ReservationForm reservation = new ReservationForm(idEquipement, idCategorie, idReservation, nomCategorie, nomEquipement, ouvertparDoubleClick);  // Ouvre le formulaire sans paramètres
             reservation.Show();
             this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void gunaChart1_Load(object sender, EventArgs e)
        {
            // Exemple de configuration du GunaChart
            LoadReservationData();
        }

        private void LoadReservationData()
        {
            string conString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = "SELECT e.nom AS equipement, COUNT(*) AS nombre_reservations " +
                                   "FROM reservation r " +
                                   "INNER JOIN equipement e ON r.equipement_id = e.id " +
                                   "GROUP BY e.nom";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Supposons que gunaChart1 est un composant GunaChart
                            while (reader.Read())
                            {
                                string equipement = reader.GetString("equipement");
                                int nombreReservations = reader.GetInt32("nombre_reservations");

                                // Ajouter les données au graphique
                                // Remplacez par la méthode correcte pour ajouter des données
                                //object value = gunaChart1.AddDataPoint(equipement, nombreReservations);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void gunaChart1_Load_1(object sender, EventArgs e)
        {
            // Connexion à la base de données
            using MySqlConnection con = new MySqlConnection(GetConnectionString());

            {
                con.Open();
                string query = @"
            SELECT c.nom AS NomCategorie, COUNT(r.ID) AS NombreReservations
            FROM reservation r
            JOIN equipement e ON r.equipement_id = e.id
            JOIN categorie c ON e.categorie_id = c.id
            GROUP BY c.nom";

                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();

                // Création du dataset pour le graphique
                var dataset = new Guna.Charts.WinForms.GunaBarDataset();
                dataset.Label = "Réservations par Catégorie";

                while (reader.Read())
                {
                    string categorie = reader.GetString("NomCategorie");
                    int nombreReservations = reader.GetInt32("NombreReservations");
                    dataset.DataPoints.Add(categorie, nombreReservations);
                }

                reader.Close();

                // Ajout des données au graphique
                gunaChart1.Datasets.Clear();
                gunaChart1.Datasets.Add(dataset);
                gunaChart1.Update();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Récupérer les valeurs des colonnes de la ligne cliquée
                int idReservation = Convert.ToInt32(DataGridView2.Rows[e.RowIndex].Cells["idReservation"].Value);
                int idEquipement = Convert.ToInt32(DataGridView2.Rows[e.RowIndex].Cells["idEquipement"].Value);
                string nomEquipement = DataGridView2.Rows[e.RowIndex].Cells["Equipement"].Value.ToString();
                string nomCategorie = DataGridView2.Rows[e.RowIndex].Cells["Categorie"].Value.ToString();
                string utilisateur = DataGridView2.Rows[e.RowIndex].Cells["Utilisateur"].Value.ToString();
                DateTime dateDebut = Convert.ToDateTime(DataGridView2.Rows[e.RowIndex].Cells["DateDebut"].Value);
                DateTime dateRetour = Convert.ToDateTime(DataGridView2.Rows[e.RowIndex].Cells["DateRetour"].Value);

               

                // Par exemple, ouvrir un formulaire de réservation avec ces informations
                ReservationForm reservationForm = new ReservationForm(idEquipement, idCategorie, idReservation, nomCategorie, nomEquipement, true);
                reservationForm.ShowDialog();
            }
        }

        private void OuverturePartDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Récupère l'ID de la réservation (assurez-vous que cette colonne existe dans le DataGridView)
                int idReservation = Convert.ToInt32(DataGridView1.Rows[e.RowIndex].Cells["IDReservation"].Value);
                int idEquipement = Convert.ToInt32(DataGridView1.Rows[e.RowIndex].Cells["IDEquipement"].Value);
                string nomEquipement = DataGridView1.Rows[e.RowIndex].Cells["Equipement"].Value.ToString();
                string nomCategorie = DataGridView1.Rows[e.RowIndex].Cells["Categorie"].Value.ToString();

                // Crée une nouvelle instance du formulaire de réservation et ouvre-le
                ReservationForm reservationForm = new ReservationForm(idEquipement, idCategorie, idReservation, nomCategorie, nomEquipement, true);
                reservationForm.ShowDialog();
            }

            }
    }

}
