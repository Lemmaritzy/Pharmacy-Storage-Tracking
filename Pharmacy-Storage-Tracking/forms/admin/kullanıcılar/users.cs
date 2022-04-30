using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Pharmacy_Storage_Tracking.kullanıcılar
{
    public partial class users : Form
    {
        private MySqlConnection conn = new MySqlConnection("server=localhost;database=pharmacytracking;uid=root;pwd='';");
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
        public users()
        {
            InitializeComponent();
        }
        
        
        private void users_Load(object sender, EventArgs e)
        {
            GetUsers();
            button1.Enabled = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        void GetUsers()
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from users";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
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
            cmd.CommandText = "select * from users";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (Convert.ToString(dr["id"])==comboBox1.Text)
                {
                    textBox1.Text = (string)(dr["u_name"]);
                    textBox2.Text = (string)(dr["u_surname"]);
                    textBox3.Text = (string)(dr["username"]);
                    textBox4.Text = (string)(dr["u_password"]);
                    textBox5.Text = (string)(dr["phone_number"]);
                    textBox6.Text = (string) dr["situation"];
                    
                    if ((string)dr["situation"]=="onaylanmis")
                    {
                        textBox6.Text = "onaylanmış";
                        button1.Enabled = false;
                    }
                    else if ((string)dr["situation"]=="onaylanmamis")
                    {
                        textBox6.Text = "Onaylama Bekleyen";
                        button1.Enabled = true;
                    }
                    
                }
            }
            dr.Close();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text==null|| comboBox1.Text=="")
            {
                MessageBox.Show("Olmayan birisini onaylayamazsınız!");
            }
            else
            {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Update users set situation='onaylanmis' where id="+Convert.ToInt32(comboBox1.Text)+"";
            object stmt;
            stmt = cmd.ExecuteNonQuery();
            if (stmt!=null)
            {
                MessageBox.Show("Onaylama başarılı","Uyarı");
            }
            else
            {
                MessageBox.Show("Beklenmedik bir hata oluştu","Hata");
            }
            cmd.Dispose();
            conn.Close();
            clear();
            }
        }

        void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox6.Text = textBox5.Text = "";
            comboBox1.Text = "";
            comboBox1.Refresh();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text==null|| comboBox1.Text=="")
            {
                MessageBox.Show("Olmayan birisini silemezsiniz!");
            }
            else
            {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Delete from users where id=" + comboBox1.Text + "";
            object stmt;
            stmt=cmd.ExecuteNonQuery();
            if (stmt!=null)
            {
                MessageBox.Show("Silme işlemi başarılı", "Uyarı");
                
                clear();
            }
            else
            {
                MessageBox.Show("Beklenmedik bir hata oluştu", "Hata");
            }
            cmd.Dispose();
            conn.Close();
            comboBox1.Items.Clear();
            GetUsers();
            }
        }
    }
}