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
        public Dashboard()
        {
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AfficherTable_Click(object sender, EventArgs e)
        {
            String conString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
            using MySqlConnection con = new MySqlConnection(conString);
            {
                try
                {
                    con.Open();
                    string query = "SELECT u.nom, u.prenom, e.nom AS equipement, c.nom AS categorie, r.date_debut, r.date_fin " +
                           "FROM reservation r " +
                           "INNER JOIN user u ON r.user_id = u.id " +
                           "INNER JOIN equipement e ON r.equipement_id = e.id " +
                           "INNER JOIN categorie c ON e.categorie_id = c.id";



                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            DataGridView1.DataSource = dt;
                        }
                    }

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erreur :" + ex.Message);
                }

            }
         }       
           
        

       

        private void ButtonAfficherReservationForm_Click(object sender, EventArgs e)
        {
            var reservation = new ReservationForm();
            reservation.Show();
           this.Hide();
        }
    }
}
