using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pharmacy_Storage_Tracking.faturalar
{
    public partial class fatura : Form
    {
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=pharmacytracking;username=root;password='';");
        private MySqlCommand cmd=new MySqlCommand();
        public fatura()
        {
            InitializeComponent();
        }

        private void fatura_Load(object sender, EventArgs e)
        {
            faturaGoster();
        }
        void faturaGoster()
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from faturalar";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                listBox1.Items.Add(dr["id"]);
            }
            dr.Close();
            conn.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "select * from faturalar";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (Convert.ToString(dr["id"])==listBox1.Text)
                {
                    richTextBox1.Text = Convert.ToString(dr["fatura"]);
                }
            }
            dr.Close();
            conn.Close();
        }

        
    }
}