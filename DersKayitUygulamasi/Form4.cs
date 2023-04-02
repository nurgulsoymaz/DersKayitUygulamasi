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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        //BİR RASTGELE KOD OLUŞSUN VE O KODU GİRİP GİRİŞ YAPALIM

        //void kodolustur()
        //{
        //Random rastgele = new Random();
        //int sayi = rastgele.Next(10000, 100000);
        //TextBox2.Text=sayi.ToString();
        private void Form4_Load(object sender, EventArgs e)
        {
            //void kodolustur();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "yildizakademi" && textBox2.Text == "site1234")
            {
                Form5 derskayit = new Form5();
                derskayit.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Hatalı bilgi girişi : Kullanıcı adı veye şifre yanlış girildi", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

       
    }
}
