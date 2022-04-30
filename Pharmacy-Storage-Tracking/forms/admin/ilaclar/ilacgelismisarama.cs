using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pharmacy_Storage_Tracking.forms
{
    public partial class ilacgelismisarama : Form
    {
        private MySqlConnection conn = new MySqlConnection("Server=localhost;Database=pharmacytracking;username=root;password='';");
        private DataTable dt = new DataTable();
        private MySqlCommand cmd = new MySqlCommand();
        public ilacgelismisarama()
        {
            InitializeComponent();
        }

        private void ilacgelismisarama_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("İlaç Adı");
            comboBox1.Items.Add("ATC");
            comboBox1.Items.Add("Sınıf");
            comboBox1.Items.Add("Firma");
            comboBox1.Items.Add("Reçete");
            
        }

        private string sorgu;
        private void button1_Click(object sender, EventArgs e)
        {
            string secim = comboBox1.Text;

            conn.Open();

           if ( secim=="İlaç Adı")
            {
                sorgu="Select id,ilaç_adı as 'İlaç',ATC as 'ATC kodu',sınıf as 'Sınıf',firma as 'Firma',fiyat as 'Fiyat',recete as 'Reçete',birim_miktar as 'Birim Miktar',birim_cinsi as 'Birim Cinsi',ambalaj_miktarı as 'Ambalaj Miktarı' from pills where ilaç_adı like '%"+textBox1.Text+"%'";
            }
            else if ( secim=="ATC")
            {
                sorgu="Select id,ilaç_adı as 'İlaç',ATC as 'ATC kodu',sınıf as 'Sınıf',firma as 'Firma',fiyat as 'Fiyat',recete as 'Reçete',birim_miktar as 'Birim Miktar',birim_cinsi as 'Birim Cinsi',ambalaj_miktarı as 'Ambalaj Miktarı' from pills where ATC like '%"+textBox1.Text+"%'";
            }
            else if ( secim=="Sınıf")
            {
                sorgu="Select ilaç_adı as 'İlaç',ATC as 'ATC kodu',sınıf as 'Sınıf',firma as 'Firma',fiyat as 'Fiyat',recete as 'Reçete',birim_miktar as 'Birim Miktar',birim_cinsi as 'Birim Cinsi',ambalaj_miktarı as 'Ambalaj Miktarı' from pills where sınıf like '%"+textBox1.Text+"%'";
            }
            else if ( secim=="Firma")
            {
               sorgu="Select ilaç_adı as 'İlaç',ATC as 'ATC kodu',sınıf as 'Sınıf',firma as 'Firma',fiyat as 'Fiyat',recete as 'Reçete',birim_miktar as 'Birim Miktar',birim_cinsi as 'Birim Cinsi',ambalaj_miktarı as 'Ambalaj Miktarı' from pills where firma like '%"+textBox1.Text+"%'";
            }
            else if (secim=="Reçete")
            {
               sorgu="Select ilaç_adı as 'İlaç',ATC as 'ATC kodu',sınıf as 'Sınıf',firma as 'Firma',fiyat as 'Fiyat',recete as 'Reçete',birim_miktar as 'Birim Miktar',birim_cinsi as 'Birim Cinsi',ambalaj_miktarı as 'Ambalaj Miktarı' from pills where recete like '%"+textBox1.Text+"%'";
            }

            MySqlCommand cmd = new MySqlCommand(sorgu,conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}