using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Pharmacy_Storage_Tracking.forms.üye;

namespace Pharmacy_Storage_Tracking
{
    public partial class giris : Form
    {
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=pharmacytracking;username=root;password='';");
        private MySqlCommand cmd=new MySqlCommand();
        private MySqlDataReader dr;
        public giris()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void giris_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Admin");
            comboBox1.Items.Add("Üye");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == null || textBox2.Text == "" || textBox2.Text == null)
            {
                MessageBox.Show("Lütfen boş alan bırakmayınız","Uyarı");
              comboBox1.Text = textBox1.Text = textBox2.Text = "";
                
            }else
            {
                if (comboBox1.SelectedIndex==0)
                {
                    if (textBox1.Text=="admin" && textBox2.Text=="1234")
                    {
                        Form1 adminpanel = new Form1();
                        adminpanel.Show();
                        this.Hide(); 
                    }
                    else
                    {
                        MessageBox.Show("Hatalı admin adı veya şifre","Hata");
                        textBox1.Text = textBox2.Text = "";
                        comboBox1.Text = "";
                    }
                }
                else if (comboBox1.SelectedIndex==1)
                {
                    Login(textBox1.Text,textBox2.Text);

                }

               
            }
        }
        void Login(string kullanici_adi, string sifre)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Select * from users where username = '"+kullanici_adi+"' and u_password = '"+sifre+"'";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            dr.Read();
            if (Convert.ToString(dr["username"]) == kullanici_adi && Convert.ToString(dr["u_password"])==sifre && Convert.ToString(dr["situation"])=="onaylanmis")
            {
                ilaclarUye iu = new ilaclarUye();
                iu.Show();
                this.Hide();
            }
            else if (Convert.ToString(dr["username"]) == kullanici_adi && Convert.ToString(dr["u_password"])==sifre && Convert.ToString(dr["situation"])=="onaylanmamis")
            {
                MessageBox.Show("Hesabınız henüz onaylanmamıştır. Lütfen daha sonra tekrar deneyiniz");
                textBox1.Text = textBox2.Text = comboBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Hatalı Giriş");
                textBox1.Text = textBox2.Text = comboBox1.Text = "";
            }

            cmd.Dispose();
            conn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            kayit _kayit = new kayit();
            _kayit.Show();
        }
    }
}