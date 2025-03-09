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


            String conString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
            MySqlConnection con = new MySqlConnection(conString);
            MySqlCommand cmd = new MySqlCommand(query, con);

            con.Open();
            var reader = cmd.ExecuteReader();


            var succes = reader.HasRows;
            if (succes)
            
            
            
            
            {
                var dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("ya une erreur");


            }

        }
    }
}
