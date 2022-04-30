using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pharmacy_Storage_Tracking.forms
{
    public partial class ilacguncelle : Form
    {
        public ilacguncelle()
        {
            InitializeComponent();
        }

        private MySqlConnection conn = new MySqlConnection("server=localhost;database=pharmacytracking;uid=root;pwd='';");
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataReader dr;
        private void ilacguncelle_Load(object sender, EventArgs e)
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from pills";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["id"]);
            }
            dr.Close();
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from pills";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                if (Convert.ToString(dr["id"])== comboBox1.Text)
                {
                    t1.Text =Convert.ToString(dr["ilaç_adı"]); 
                    t2.Text =  Convert.ToString(dr["ATC"]); 
                    t3.Text = Convert.ToString(dr["sınıf"]);
                    t4.Text =  Convert.ToString(dr["firma"]);
                    t5.Text =  Convert.ToString(dr["fiyat"]);
                    t6.Text = Convert.ToString(dr["recete"]);
                    t7.Text = Convert.ToString(dr["birim_miktar"]);  
                    t8.Text =  Convert.ToString(dr["birim_cinsi"]);
                    t9.Text = Convert.ToString(dr["ambalaj_miktarı"]);
                    break;
                }
            }
            dr.Close();
            conn.Close();
            
        }

        void temizle()
        {
            t1.Text = t2.Text = t3.Text = t4.Text = t5.Text = t6.Text = t7.Text = t8.Text = t9.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (t1.Text=="" || t1.Text==null||t2.Text=="" || t2.Text==null||t3.Text=="" || t3.Text==null||t4.Text=="" || t4.Text==null||t5.Text=="" || t5.Text==null||t6.Text=="" || t6.Text==null||t7.Text=="" || t7.Text==null||t8.Text=="" || t8.Text==null||t9.Text=="" || t9.Text==null)
            {
                MessageBox.Show("Boş alan geçilemez");
            }
            else
            {
                ilaclar i = new ilaclar();
                i.guncelleme_ilac(t1.Text,t2.Text,t3.Text,t4.Text,t5.Text,t6.Text,t7.Text,t8.Text,t9.Text,Convert.ToInt32(comboBox1.Text));
                temizle();
                this.Hide();
                
            }
            
        }
    }
}