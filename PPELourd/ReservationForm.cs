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
        public ReservationForm(int idEquipement = 0, int idCategorie = 0, bool ouvertparDoubleClick = false)
        {
            InitializeComponent();
            this.idEquipement = idEquipement;
            this.idCategorie = idCategorie;
            this.OuvertPartDoubleClick = ouvertparDoubleClick;

            if (User.GetutilisateurConnecte != null)
            {
                UserStatus.Text = $"Connecté en tant que : {User.GetutilisateurConnecte().GetPseudo}";
                LoadCategories();
            }
            else
            {
                UserStatus.Text = "Aucun utilisateur est connecté";
            }
        }

        private void LoadCategories()
        {
            using (MySqlConnection con = new MySqlConnection("server=localhost;database=ppelourd;user=donavan;password=dodo;"))
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
            using (MySqlConnection con = new MySqlConnection("server=localhost;database=ppelourd;uid=donavan;pwd=dodo"))
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

            DateTime dateDebut = DateTimePickeReservation1.Value;
            DateTime dateFin = DateTimePickeReservation2.Value;

            if (dateFin <= dateDebut)
            {
                MessageBox.Show("La date de fin doit être après la date de début.");
                return;
            }

            int idEquipement = (int)ComboBoxEquipement.SelectedValue;
            int idUtilisateur = User.GetutilisateurConnecte()?.Id ?? 0;

            if (idUtilisateur == 0)
            {
                MessageBox.Show("Aucun utilisateur connecté.");
                return;
            }
            using (MySqlConnection con = new MySqlConnection("server=localhost;database=ppelourd;uid=donavan;pwd=dodo"))
            {
                try
                {
                    con.Open();
                    string insertQuery = "INSERT INTO reservation (user_id,equipement_id, date_debut, date_fin) " +
                                         "VALUES  (@idUtilisateur ,@idEquipement, @dateDebut, @dateFin)";

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

        private void DateTimePickeReservation1_ValueChanged(object sender, EventArgs e)
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

        private void DateTimePickeReservation1_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime dateSelectionnee = DateTimePickeReservation1.Value;
            DateTime deuxMoisPlusTard = dateSelectionnee.AddMonths(2);

            DateTimePickeReservation2.MinDate = dateSelectionnee;
            DateTimePickeReservation2.MaxDate = deuxMoisPlusTard;

            if (DateTimePickeReservation2.Value < dateSelectionnee)
            {
                DateTimePickeReservation2.Value = dateSelectionnee;
            }
            else if (DateTimePickeReservation2.Value > deuxMoisPlusTard)
            {
                DateTimePickeReservation2.Value = deuxMoisPlusTard;
            }
        }

        private void DateTimePickeReservation2_ValueChanged(object sender, EventArgs e)
        {
            DateTime dateSelectionnee1 = DateTimePickeReservation1.Value;
            DateTime deuxMoisPlusTard = dateSelectionnee1.AddMonths(2);

            if (DateTimePickeReservation2.Value < dateSelectionnee1)
            {
                DateTimePickeReservation2.Value = dateSelectionnee1;
            }
            else if (DateTimePickeReservation2.Value > deuxMoisPlusTard)
            {
                DateTimePickeReservation2.Value = deuxMoisPlusTard;
            }
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {

        }

        private void UserStatus_Click(object sender, EventArgs e)
        {

        }

        private void ButtonToDashboard_Click(object sender, EventArgs e)
        {
            var dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();

        }
    }
}
