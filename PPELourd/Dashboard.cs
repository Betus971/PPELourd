using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PPELourd
{
   
    public partial class Dashboard : Form
    {
        MySqlConnection connection = new MySqlConnection("server=localhost;database=c#;uid=donavan;pwd=dodo;");
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
            MySqlConnection con = new MySqlConnection(conString);
            con.Open();
            string createtable = "SELECT u.nom, u.prenom, r.date_debut, r.date_fin " +
                               "FROM reservation r " +
                               "INNER JOIN user u ON r.user_id = u.id";
            MySqlCommand cmd = new MySqlCommand(createtable, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            DataGridView1.DataSource = dt;
        }
    }
}
