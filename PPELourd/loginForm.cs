using MySql.Data.MySqlClient;

namespace PPELourd
{
    public partial class loginForm : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=c#;uid=donavan;pwd=dodo;");
        string server = "localhost";
        string uid = "donavan";
        string password = "dodo";
        string database = "ppelourd";
        public loginForm()
        {
            InitializeComponent();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void InscriptionButton_Click(object sender, EventArgs e)
        {

        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {

            // Récupération des valeurs des TextBox
            string pseudo = TextBoxPseudo.Text;
            string password = TextBoxMdp.Text;

            // Création de la requête SQL
            string query = $"select * from   user where  pseudo   = '{pseudo}' and password = '{password}'";
            String conString = "server=localhost;uid=donavan;pwd=dodo;database=ppelourd";


            MySqlConnection con = new MySqlConnection(conString);
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.AddWithValue("@pseudo", pseudo);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                con.Open();
                using (var reader = cmd.ExecuteReader())

                    if (reader.Read())
                    {
                        reader.Read(); // Lire la première ligne du résultat
                        int id = reader.GetInt32("id");
                        string nom = reader.GetString("nom");
                        string prenom = reader.GetString("prenom");
                        string Pseudo = reader.GetString("pseudo");
                        string mdp = reader.GetString("password");

                        User.SetUtilisateurConnecte(new User(id, nom, prenom, Pseudo, mdp));
                        // Créez le formulaire de réservation sans utiliser `this` directement
                        ReservationForm reservation = new ReservationForm();
                        reservation.Show();
                        this.Hide(); // Ici, cela devrait fonctionner si `this` est valide
                    }
                    else
                    {
                        MessageBox.Show("Erreur : utilisateur ou mot de passe incorrect");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }

        private void TextBoxMdp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
