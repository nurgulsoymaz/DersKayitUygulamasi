using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DersKayitUygulamasi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}

        private void btnForm2_Click(object sender, EventArgs e)
        {
            Form2 frm= new Form2();
            frm.Show();
            this.Hide();
        }

        private void btnForm4_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }

        private void birimHakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
