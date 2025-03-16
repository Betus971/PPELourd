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
        private string GetConnectionString()
        {
            return  $"server={server};uid={uid};pwd={password};database={database}";
        }
        public Dashboard()
        {
            InitializeComponent();
           
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        } 
        
        
        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Vérifiez que l'index de la ligne est valide
            {
                // Obtenez la ligne sélectionnée
                DataGridViewRow selectedRow = DataGridView1.Rows[e.RowIndex];

                // Vérifiez que la cellule "IDReservation" n'est pas vide
                if (selectedRow.Cells["IDReservation"].Value != DBNull.Value)
                {
                    try
                    {
                        // Extrayez l'ID de réservation de la cellule
                        int idReservation = Convert.ToInt32(selectedRow.Cells["IDReservation"].Value);

                        // Affichez l'ID de réservation pour vérification (optionnel)
                        MessageBox.Show("ID de réservation sélectionné : " + idReservation);

                        // Ouvrez le formulaire de réservation avec l'ID de réservation
                        var reservationForm = new ReservationForm(idReservation);
                        reservationForm.ShowDialog();

                        // Après la modification ou le rendu de l'équipement, mettez à jour l'état de l'équipement
                        // et rechargez la liste des réservations
                        AfficherTable_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la récupération de l'ID de réservation : " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("ID de réservation non valide.");
                }
            }
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
                    string query = @"SELECT 
                               r.id AS IDReservation,
                              u.pseudo AS Utilisateur, 
                              e.nom AS Equipement, 
                                c.nom AS Categorie, 
                                r.date_debut, 
                                r.date_fin 
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
                            DataGridView1.DataSource = dt;
                            DataGridView1.Columns["IDReservation"].Visible = false;
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
            var reservation = new ReservationForm();
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
    }
}
