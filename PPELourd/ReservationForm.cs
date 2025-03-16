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
        private int idReservation;
        private bool OuvertPartDoubleClick;





        // private List<Reservation> reservations = new List<Reservation>();
        public ReservationForm(int idEquipement = 0, int idReservation = 0, int idCategorie = 0, bool ouvertparDoubleClick = false)
        {
            InitializeComponent();
            this.idEquipement = idEquipement;
            this.idCategorie = idCategorie;
            this.OuvertPartDoubleClick = ouvertparDoubleClick;
            this.idReservation = idReservation;  // On l'affecte dans le constructeur


            if (idReservation > 0)
            {
                ChargerReservation(idReservation); // Appeler la méthode pour charger les détails de la réservation
            }
            else
            {
                // Si aucun ID de réservation n'est fourni, vous pouvez initialiser le formulaire pour une nouvelle réservation
                MessageBox.Show("Aucun ID de réservation fourni. Préparation pour une nouvelle réservation.");
            }


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

        private void ChargerReservation(int idReservation)
        {
            string conString = "server=localhost;database=ppelourd;uid=donavan;pwd=dodo;";

            using (MySqlConnection con = new MySqlConnection(conString))
            {
                try
                {
                    con.Open();
                    string query = @"SELECT
                                      e.id AS EquipementId,
                                        e.nom AS Equipement,
                                        c.nom AS Categorie,
                                        r.date_debut,
                                         r.date_fin
                                                 FROM reservation r
                                                                    INNER JOIN equipement e ON r.equipement_id = e.id
                                                                    INNER JOIN categorie c ON e.categorie_id = c.id
                                                                    WHERE r.id = @idReservation";
                           MessageBox.Show("ID de réservation : " + idReservation);
            MessageBox.Show("Requête SQL : " + query);

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idReservation", idReservation);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Afficher les valeurs pour le débogage
                                MessageBox.Show("Equipement: " + reader["Equipement"].ToString());
                                MessageBox.Show("Categorie: " + reader["Categorie"].ToString());
                                MessageBox.Show("Date Debut: " + reader["date_debut"].ToString());
                                MessageBox.Show("Date Fin: " + reader["date_fin"].ToString());

                                // Charger les valeurs dans les contrôles
                                label1.Text = reader["Equipement"].ToString();
                                labelUtilisateur.Text = reader["Categorie"].ToString();
                                DateTimePickeReservation1.Value = Convert.ToDateTime(reader["date_debut"]);
                                DateTimePickeReservation2.Value = Convert.ToDateTime(reader["date_fin"]);

                                // Remplir le ComboBox avec l'équipement correspondant
                                ComboBoxEquipement.SelectedValue = Convert.ToInt32(reader["EquipementId"]);

                                // Charger les équipements en fonction de la catégorie si besoin
                                LoadEquipements(Convert.ToInt32(reader["EquipementId"]));
                            }
                            else
                            {
                                MessageBox.Show("Aucune réservation trouvée avec cet ID.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la récupération des données : " + ex.Message);
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

        private void ButtonRendreEquipement_Click(object sender, EventArgs e)
        {
            // Confirmer si l'utilisateur veut rendre l'équipement
            var result = MessageBox.Show("Voulez-vous vraiment rendre cet équipement ?", "Confirmation", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                // Mettre à jour l'état de l'équipement pour le rendre disponible
                string conString = "server=localhost;database=ppelourd;uid=donavan;pwd=dodo;";

                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    try
                    {
                        con.Open();

                        // Mise à jour de l'équipement pour le rendre disponible
                        string updateQuery = "UPDATE equipement SET disponible = 1 WHERE id = (SELECT equipement_id FROM reservation WHERE id = @idReservation)";
                        MySqlCommand updateCmd = new MySqlCommand(updateQuery, con);
                        updateCmd.Parameters.AddWithValue("@idReservation", idReservation);
                        updateCmd.ExecuteNonQuery();

                        // Supprimer la réservation de la base de données
                        string deleteQuery = "DELETE FROM reservation WHERE id = @idReservation";
                        MySqlCommand deleteCmd = new MySqlCommand(deleteQuery, con);
                        deleteCmd.Parameters.AddWithValue("@idReservation", idReservation);
                        deleteCmd.ExecuteNonQuery();

                        MessageBox.Show("L'équipement a été rendu et la réservation supprimée avec succès.");
                        this.Close(); // Fermer le formulaire de réservation
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }


}



































































