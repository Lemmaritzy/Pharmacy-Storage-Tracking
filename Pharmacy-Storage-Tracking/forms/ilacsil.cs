using System;
using System.Windows.Forms;

namespace Pharmacy_Storage_Tracking.forms
{
    public partial class ilacsil : Form
    {
        public ilacsil()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            ilaclar i = new ilaclar();
            i.silme_ilac(deletetext.Text);
            this.Hide();
        }
    }
}