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
    public partial class Inscription : Form
    {
        public Inscription()
        {
            InitializeComponent();
        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxPseudo_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxPrenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBoxNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonGotoLogin_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Hide(); // Ferme le formulaire d'inscription après une inscription réussie
        }
        

        private void ButtonInscription_Click(object sender, EventArgs e)
        {
            // Collecte des informations
            string nom = TextBoxNom.Text;
            string prenom = TextBoxPrenom.Text;
            string pseudo = TextBoxPseudo.Text;
            string password = TextBoxPassword.Text;

            // Validation des données
            if (string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom) ||
                string.IsNullOrWhiteSpace(pseudo) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Tous les champs sont obligatoires.");
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("Le mot de passe doit contenir au moins 6 caractères.");
                return;
            }

            // Insertion dans la base de données
            try
            {
                string conString = "server=localhost;database=ppelourd;uid=donavan;pwd=dodo;";

                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();
                    string query = "INSERT INTO user (nom, prenom, pseudo, password) VALUES (@nom, @prenom, @pseudo, @password)";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@nom", nom);
                        cmd.Parameters.AddWithValue("@prenom", prenom);
                        cmd.Parameters.AddWithValue("@pseudo", pseudo);
                        cmd.Parameters.AddWithValue("@password", password);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Inscription réussie !");
                       
                        loginForm loginForm = new loginForm();
                        loginForm.Show();
                        this.Hide(); // Ferme le formulaire d'inscription après une inscription réussie
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'inscription : " + ex.Message);
            }
        }

    }
    
}
