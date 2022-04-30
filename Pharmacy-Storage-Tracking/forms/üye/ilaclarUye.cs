using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pharmacy_Storage_Tracking.forms.üye
{
    public partial class ilaclarUye : Form
    {
        private MySqlConnection conn = new MySqlConnection("server=localhost;database=pharmacytracking;uid=root;pwd='';");
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
        public ilaclarUye()
        {
            InitializeComponent();
        }
        public void ilaclistele()
        {
            conn.Open();
            da = new MySqlDataAdapter("Select id,ilaç_adı as 'İlaç',ATC as 'ATC kodu',sınıf as 'Sınıf',firma as 'Firma',fiyat as 'Fiyat',recete as 'Reçete',birim_miktar as 'Birim Miktar',birim_cinsi as 'Birim Cinsi',ambalaj_miktarı as 'Ambalaj Miktarı' from pills",conn);
            ds = new DataSet();
            da.Fill(ds, "pills");
            dataGridView1.DataSource = ds.Tables["pills"];
            conn.Close();

        }
        
        void styleGrid()
        {
            dataGridView1.Padding = new Padding(2);
            dataGridView1.Margin = new Padding(8);
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.ForeColor=Color.Black;
        }

        private void ilaclarUye_Load(object sender, EventArgs e)
        {
            styleGrid();
            ilaclistele();
            comboBox1.Items.Add("İlaç Adı");
            comboBox1.Items.Add("ATC");
            comboBox1.Items.Add("Sınıf");
            comboBox1.Items.Add("Firma");
            comboBox1.Items.Add("Reçete");
        }

        private string sorgu;
        

        private void button1_Click_1(object sender, EventArgs e)
        {
             string secim = comboBox1.Text;

            conn.Open();

           if ( secim=="İlaç Adı")
            {
                sorgu="Select ilaç_adı as 'İlaç',ATC as 'ATC kodu',sınıf as 'Sınıf',firma as 'Firma',fiyat as 'Fiyat',recete as 'Reçete',birim_miktar as 'Birim Miktar',birim_cinsi as 'Birim Cinsi',ambalaj_miktarı as 'Ambalaj Miktarı' from pills where ilaç_adı like '%"+textBox1.Text+"%'";
            }
            else if ( secim=="ATC")
            {
                sorgu="Select ilaç_adı as 'İlaç',ATC as 'ATC kodu',sınıf as 'Sınıf',firma as 'Firma',fiyat as 'Fiyat',recete as 'Reçete',birim_miktar as 'Birim Miktar',birim_cinsi as 'Birim Cinsi',ambalaj_miktarı as 'Ambalaj Miktarı' from pills where ATC like '%"+textBox1.Text+"%'";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}