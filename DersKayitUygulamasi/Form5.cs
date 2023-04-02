using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DersKayitUygulamasi
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }


        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-66BEJ8D\\SQLEXPRESS;Initial Catalog=ogrenci;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        private void verilerigoster()
        {
            listView1.Items.Clear();//en son eklenen görünsün her defada temizlensin
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select*From kayitlar", baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();

                ekle.Text = oku["numara"].ToString();
                ekle.SubItems.Add(oku["adi"].ToString());
                ekle.SubItems.Add(oku["soyadi"].ToString());
                ekle.SubItems.Add(oku["alinanders1"].ToString());
                ekle.SubItems.Add(oku["harf1"].ToString());
                ekle.SubItems.Add(oku["alinanders2"].ToString());
                ekle.SubItems.Add(oku["harf2"].ToString());
                ekle.SubItems.Add(oku["alinanders3"].ToString());
                ekle.SubItems.Add(oku["harf3"].ToString());
                ekle.SubItems.Add(oku["tercih1"].ToString());
                ekle.SubItems.Add(oku["tercih2"].ToString());
                ekle.SubItems.Add(oku["tercih3"].ToString());
                ekle.SubItems.Add(oku["grup"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void BtnKayıt_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            //katı atıklar grup sayısı
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'katı atıklar'", baglan);
            SqlDataReader oku1 = komut1.ExecuteReader();
             while (oku1.Read())
            {
                label2.Text= oku1[0].ToString();
            }
             baglan.Close();

            //içme sularının arıtılması
            baglan.Open();
            SqlCommand komut4 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'İçme Sularının Arıtılması'", baglan);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                label6.Text = oku4[0].ToString();
            }
            baglan.Close();


            //Atıksuların arıtılması
            baglan.Open();
            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Atıksuların Arıtılması'", baglan);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                label4.Text = oku3[0].ToString();
            }
            baglan.Close();

            //su temini ve kanalizasyon
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Su Temini ve Kanalizasyon'", baglan);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                label8.Text = oku2[0].ToString();
            }
            baglan.Close();

            //Hava Kirliliği
            baglan.Open();
            SqlCommand komut5 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Hava Kirliliği'", baglan);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                label10.Text = oku5[0].ToString();
            }
            baglan.Close();

        }
        int numara = 0;
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {

            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete From kayitlar where numara = (" + numara + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
        }


        private void label3_AutoSizeChanged(object sender, EventArgs e)
        {

        }

        private void BtnFrm1_Click(object sender, EventArgs e)
        {
      
                Form1 derskayit = new Form1();
                derskayit.Show();
                this.Hide();
        
        }
    }
}
