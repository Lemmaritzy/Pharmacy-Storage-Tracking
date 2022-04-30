using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmacy_Storage_Tracking.faturalar;
using Pharmacy_Storage_Tracking.forms;
using Pharmacy_Storage_Tracking.kullanıcılar;

namespace Pharmacy_Storage_Tracking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
         timer1.Start();       
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            label3.Text = DateTime.Now.ToString("dddd , MMM dd yyyy,hh:mm:ss");

        }

        private void btnİlac_Click(object sender, EventArgs e)
        {
            ilaclar ilac = new ilaclar();
            ilac.Show();
        }

        private void btnKullanici_Click(object sender, EventArgs e)
        {
            users _kullanicilar = new users();
            _kullanicilar.Show();
        }

        private void btnFatura_Click(object sender, EventArgs e)
        {
            fatura _faturalar = new fatura();
            _faturalar.Show();
        }
    }
}