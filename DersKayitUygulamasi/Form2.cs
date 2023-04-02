using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //sql kütüphanesini ekledim


namespace DersKayitUygulamasi
{
    public partial class Form2 : Form
    {
        SqlConnection baglan = new SqlConnection(" Data Source = DESKTOP - 66BEJ8D\\SQLEXPRESS;Initial Catalog = ogrenci; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

       
        public Form2()
        {
            InitializeComponent();
        }

        //BİR RASTGELE KOD OLUŞSUN VE O KODU GİRİP GİRİŞ YAPALIM

        //void kodolustur()
        //{
        //Random rastgele = new Random();
        //int sayi = rastgele.Next(10000, 100000);
        //TextBox2.Text=sayi.ToString();
        private void Form2_Load(object sender, EventArgs e)
        {
            //void kodolustur()
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "yildizogrenci" && textBox2.Text == "site1234") 
            {
                Form1 derskayit = new Form1();
                derskayit.Show();
                this.Hide();
            }

            else 
            {
                MessageBox.Show("Hatalı bilgi girişi : Kullanıcı adı veye şifre yanlış girildi", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
    }
}
