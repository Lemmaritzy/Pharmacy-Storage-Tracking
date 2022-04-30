using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pharmacy_Storage_Tracking
{
    public partial class kayit : Form
    {
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=pharmacytracking;username=root;password='';");
        private MySqlCommand cmd=new MySqlCommand();
        public kayit()
        {
            InitializeComponent();
        }

        private void kayit_Load(object sender, EventArgs e)
        {
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text=="" ||textBox2.Text=="" ||textBox3.Text=="" ||textBox4.Text=="" ||textBox5.Text=="" || maskedTextBox1.Text=="")
            {
                MessageBox.Show("Lütfen boş bırakmayınız");
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = maskedTextBox1.Text = "";
            }
            else
            {
                if (textBox4.Text==textBox5.Text)
                {
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "Insert into users (u_name,u_surname,username,u_password,phone_number) values (@name,@surname,@username,@password,@email)";
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@surname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@username", textBox3.Text);
                    cmd.Parameters.AddWithValue("@password", textBox4.Text);
                    cmd.Parameters.AddWithValue("@email", maskedTextBox1.Text);
                    object stmt;
                    stmt=cmd.ExecuteNonQuery();
                    if (stmt!=null)
                    {
                        MessageBox.Show("Kayıt başarılı. Onaylandıktan sonra sisteme giriş yapabilirsiniz");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kayıt işlemi sırasında bir hata oluştu. Lütfen tekrar deneyiniz");
                        textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = maskedTextBox1.Text = "";
                    }
                    cmd.Dispose();
                    conn.Close();


                }
            }
        }
    }
}