using System;
using System.Windows.Forms;

namespace Pharmacy_Storage_Tracking.forms
{
    public partial class ilacekle : Form
    {
        public ilacekle()
        {
            InitializeComponent();
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
                i.ekleme_ilac(t1.Text,t2.Text,t3.Text,t4.Text,t5.Text,t6.Text,t7.Text,t8.Text,t9.Text);
                temizle();
                this.Hide();
                
            }
            
            
        }
    }
}