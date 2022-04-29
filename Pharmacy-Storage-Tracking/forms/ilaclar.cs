using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;
namespace Pharmacy_Storage_Tracking.forms
{
    public partial class ilaclar : Form
    {
        public ilaclar()
        {
            InitializeComponent();
        }

        private MySqlConnection conn = new MySqlConnection("server=localhost;database=pharmacytracking;uid=root;pwd='';");
        private MySqlCommand cmd = new MySqlCommand();
        private MySqlDataAdapter da = new MySqlDataAdapter();
        private DataSet ds = new DataSet();
        private void ilaclar_Load(object sender, EventArgs e)
        {
            styleGrid();
            ilaclistele();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
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
        private string sorgu;
        private void button1_Click(object sender, EventArgs e)
        {
            
            conn.Open();
            sorgu = "Select ilaç_adı as 'İlaç',ATC as 'ATC kodu',sınıf as 'Sınıf',firma as 'Firma',fiyat as 'Fiyat',recete as 'Reçete',birim_miktar as 'Birim Miktar',birim_cinsi as 'Birim Cinsi',ambalaj_miktarı as 'Ambalaj Miktarı' from pills where ilaç_adı like '%"+textBox1.Text+"%'";
            MySqlCommand cmd = new MySqlCommand(sorgu,conn);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
            
        }

        public void ekleme_ilac(string a1,string a2,string a3,string a4,string a5,string a6,string a7,string a8,string a9)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText ="Insert into pilLs (ilaç_adı,ATC,sınıf,firma,fiyat,recete,birim_miktar,birim_cinsi,ambalaj_miktarı) values (@a1,@a2,@a3,@a4,@a5,@a6,@a7,@a8,@a9)";
            cmd.Parameters.AddWithValue("@a1", a1);
            cmd.Parameters.AddWithValue("@a2", a2);
            cmd.Parameters.AddWithValue("@a3", a3);
            cmd.Parameters.AddWithValue("@a4", a4);
            cmd.Parameters.AddWithValue("@a5", a5);
            cmd.Parameters.AddWithValue("@a6", a6);
            cmd.Parameters.AddWithValue("@a7", a7);
            cmd.Parameters.AddWithValue("@a8", a8);
            cmd.Parameters.AddWithValue("@a9", a9);
            object stmt;
            stmt = cmd.ExecuteNonQuery();
            if (stmt!=null)
            {
                MessageBox.Show("Kayıt başarılı");
            }
            else
            {
                MessageBox.Show("hata hata hata");
            }
            cmd.Dispose();
            conn.Close();
            
        }
        
        public void guncelleme_ilac(string a1,string a2,string a3,string a4,string a5,string a6,string a7,string a8,string a9, int id)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Update pills set ilaç_adı='"+a1+"',ATC='"+a2+"',sınıf='"+a3+"',firma='"+a4+"',fiyat="+a5+",recete='"+a6+"', birim_miktar = "+a7+",birim_cinsi='"+a8+"',ambalaj_miktarı="+a9+" where id="+id+"";
            object stmt;
            stmt = cmd.ExecuteNonQuery();
            if (stmt!=null)
            {
                MessageBox.Show("Güncelleme başarılı");
            }
            else
            {
                MessageBox.Show("hata hata hata");
            }
            cmd.Dispose();
            conn.Close();
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            ilacekle _ilacekle = new ilacekle();
            _ilacekle.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ilaclistele();
        }

        public void silme_ilac(string id)
        {
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = "Delete from pills where id=@id ";
            cmd.Parameters.AddWithValue("@id", id);
            object stmt;
            stmt = cmd.ExecuteNonQuery();
            if (stmt!=null)
            {
                MessageBox.Show("Silme işlemi başarılı");
                
            }
            else
            {
                MessageBox.Show("Silerken bir hata oluştu");
            }
            cmd.Dispose();
            conn.Close();
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            ilacsil _ilacsil = new ilacsil();
            _ilacsil.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ilacguncelle _ilacguncelle = new ilacguncelle();
            _ilacguncelle.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ilacgelismisarama iga = new ilacgelismisarama();
            iga.Show();
        }
    }
}