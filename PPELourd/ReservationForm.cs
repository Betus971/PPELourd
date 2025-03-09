using MySql.Data.MySqlClient;
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
        private int idEquipement;
        private int idCategorie;
        private bool OuvertPartDoubleClick;
        

       // private List<Reservation> reservations = new List<Reservation>();
        public ReservationForm( int idEquipement = 0 , int idCategorie = 0 , bool ouvertparDoubleClick = false)
        {
            InitializeComponent();
            this.idEquipement= idEquipement;
            this.idCategorie = idCategorie;
            this.OuvertPartDoubleClick = ouvertparDoubleClick;

            if (User.UtilisateurConnecte != null)
            {
                labelUtilisateur.Text = $"Connecté en tant que : {User.UtilisateurConnecte.Pseudo}";
                LoadCategories();
            }
            else
            {
                MessageBox.Show("Aucun utilisateur connecté.");
                this.Close();
            }
        }

        private void LoadCategories()
        {
            using (MySqlConnection con = new MySqlConnection("Votre_Chaîne_De_Connexion"))
            {
                try
                {
                    con.Open();
                    string query = "SELECT id, nom FROM categorie";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    ComboBoxCategorieEquipement.DataSource = dt;
                    ComboBoxCategorieEquipement.DisplayMember = "nom";
                    ComboBoxCategorieEquipement.ValueMember = "id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void LoadEquipements(int idCategorie)
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;database=c#;uid=donavan;pwd=dodo"))
            {
                try
                {
                    con.Open();
                    string query = "SELECT id, nom FROM equipement WHERE categorie_id = @idCategorie AND disponible = 1";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, con);
                    adapter.SelectCommand.Parameters.AddWithValue("@idCategorie", idCategorie);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    ComboBoxEquipement.DataSource = dt;
                    ComboBoxEquipement.DisplayMember = "nom";
                    ComboBoxEquipement.ValueMember = "id";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des équipements : " + ex.Message);
                }
            }
        }

   
        private void ButtonReservation_Click(object sender, EventArgs e)
        {
            if (ComboBoxEquipement.SelectedValue == null)
            {
                MessageBox.Show("Veuillez sélectionner un équipement.");
                return;
            }

            DateTime dateDebut = DateReservation.Value;
            DateTime dateFin = guna2DateTimePicker1.Value;

            if (dateFin <= dateDebut)
            {
                MessageBox.Show("La date de fin doit être après la date de début.");
                return;
            }

            int idEquipement = (int)ComboBoxEquipement.SelectedValue;
            int idUtilisateur = User.UtilisateurConnecte?.Id ?? 0;

            if (idUtilisateur == 0)
            {
                MessageBox.Show("Aucun utilisateur connecté.");
                return;
            }
            using (MySqlConnection con = new MySqlConnection("server=localhost;database=c#;uid=donavan;pwd=dodo"))
            {
                try
                {
                    con.Open();
                    string insertQuery = "INSERT INTO demandes (id_equipement, id_utilisateur, date_debut, date_fin, statut_demande) " +
                                         "VALUES (@idEquipement, @idUtilisateur, @dateDebut, @dateFin, 'en attente')";

                    MySqlCommand cmd = new MySqlCommand(insertQuery, con);
                    cmd.Parameters.AddWithValue("@idEquipement", idEquipement);
                    cmd.Parameters.AddWithValue("@idUtilisateur", idUtilisateur);
                    cmd.Parameters.Add("@dateDebut", MySqlDbType.DateTime).Value = dateDebut;
                    cmd.Parameters.Add("@dateFin", MySqlDbType.DateTime).Value = dateFin;

                    cmd.ExecuteNonQuery();

                    // Marquer l'équipement comme emprunté
                    string updateQuery = "UPDATE equipement SET disponible = 0 WHERE id = @idEquipement";
                    MySqlCommand updateCmd = new MySqlCommand(updateQuery, con);
                    updateCmd.Parameters.AddWithValue("@idEquipement", idEquipement);
                    updateCmd.ExecuteNonQuery();

                    MessageBox.Show("Réservation effectuée avec succès !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ComboBoxEquipement_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void DateReservation_ValueChanged(object sender, EventArgs e)
        {

        }

        private void ComboBoxCategorieEquipement_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxCategorieEquipement.SelectedValue != null && int.TryParse(ComboBoxCategorieEquipement.SelectedValue.ToString(), out int selectedCategorieID))
            {
                LoadEquipements(selectedCategorieID);
            }
        }

      
    }
}
