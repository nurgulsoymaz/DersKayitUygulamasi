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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskBand;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DersKayitUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-66BEJ8D\\SQLEXPRESS;Initial Catalog=ogrenci;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");



        private void verilerigoster()
        {
            listView1.Items.Clear();//en son eklenen görünsün her defada temizlensin


            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * From kayitlar", baglan); 

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
        private void button4_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


            //katý atýklar grup sayýsý
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'katý atýklar'", baglan);
            SqlDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
                label16.Text = oku1[0].ToString();
            }
            baglan.Close();

            //içme sularýnýn arýtýlmasý
            baglan.Open();
            SqlCommand komut4 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Ýçme Sularýnýn Arýtýlmasý'", baglan);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                label21.Text = oku4[0].ToString();
            }
            baglan.Close();


            //Atýksularýn arýtýlmasý
            baglan.Open();
            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Atýksularýn Arýtýlmasý'", baglan);
            SqlDataReader oku3 = komut3.ExecuteReader();
            while (oku3.Read())
            {
                label18.Text = oku3[0].ToString();
            }
            baglan.Close();

            //su temini ve kanalizasyon
            baglan.Open();
            SqlCommand komut2 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Su Temini ve Kanalizasyon'", baglan);
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                label22.Text = oku2[0].ToString();
            }
            baglan.Close();

            //Hava Kirliliði
            baglan.Open();
            SqlCommand komut5 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Hava Kirliliði'", baglan);
            SqlDataReader oku5 = komut5.ExecuteReader();
            while (oku5.Read())
            {
                label24.Text = oku5[0].ToString();
            }
            baglan.Close();


        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            //baglan.Close();
            baglan.Open();
            //-----------------------------------------------------------------------------------------------------------------------

            string[] students = new string[] { "Öðrenci1", "Öðrenci2", "Öðrenci3", "Öðrenci4", "Öðrenci5", "Öðrenci6", "Öðrenci7", "Öðrenci8", "Öðrenci9", "Öðrenci10", "Öðrenci11", "Öðrenci12", "Öðrenci13", "Öðrenci14", "Öðrenci15", "Öðrenci16", "Öðrenci17", "Öðrenci18", "Öðrenci19", "Öðrenci20", "Öðrenci21", "Öðrenci22", "Öðrenci23", "Öðrenci24", "Öðrenci25", "Öðrenci26", "Öðrenci27", "Öðrenci28", "Öðrenci29", "Öðrenci30" };

            // Gruplarýn bilgilerini tanýmlama

            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
            groups.Add("Katý Atýk", new List<string> { "Katý Atýklar" });
            groups.Add("Atýksularýn Arýtýlmasý", new List<string> { "Biyolojik Temel Ýþlemler", "Atýksularýn Arýtýlmasý" });
            groups.Add("Ýçme Sularýnýn Arýtýlmasý", new List<string> { "Fiziksel Temel Ýþlemler", "Ýçme Sularýnýn Arýtýlmasý" });
            groups.Add("Su Temini ve Kanalizasyon", new List<string> { "Hidrolik", "Su Temini", "Atýksularýn Uzaklaþtýrýlmasý" });
            groups.Add("Hava Kirliliði", new List<string> { "Hava Kirliliði", "Hava Kirliliði Kontrolü" });


            // Öðrencilerin ders geçme notlarýný tanýmlama
            string harf1 = "AA,BA,BB,BC,CA,CB,CC,DD,FF,GG";
            string harf2 = "AA,BA,BB,BC,CA,CB,CC,DD,FF,GG";
            string harf3 = "AA,BA,BB,BC,CA,CB,CC,DD,FF,GG";

            string tercih1 = "Katý Atýklar,Atýksularýn Arýtýlmasý,Ýçme Sularýnýn Arýtýlmasý,Su Temini ve Kanalizasyon,Hava Kirliliði";
            string tercih2 = "Katý Atýklar,Atýksularýn Arýtýlmasý,Ýçme Sularýnýn Arýtýlmasý,Su Temini ve Kanalizasyon,Hava Kirliliði";
            string tercih3 = "Katý Atýklar,Atýksularýn Arýtýlmasý,Ýçme Sularýnýn Arýtýlmasý,Su Temini ve Kanalizasyon,Hava Kirliliði";



            if (comboBox2.SelectedIndex == 0)
            { 

                if (comboBox7.SelectedIndex == 0)
                {
                    textBox4.Text = "Katý Atýklar";
                }
                else if (comboBox7.SelectedIndex == 1)
                {
                    textBox4.Text = "Atýksularýn Arýtýlmasý";
                }
                else if (comboBox7.SelectedIndex == 2)
                {
                    textBox4.Text = "Ýçme Sularýnýn Arýtýlmasý";
                }       
                else if (comboBox7.SelectedIndex == 3)
                {
                    textBox4.Text = "Su Temini ve Kanalizasyon";
                }
                else
                {
                    textBox4.Text = "Hava Kirliliði";
                }

            }

            else if (comboBox3.SelectedIndex == 0)
            {

                if (comboBox8.SelectedIndex == 0)
                {
                    textBox4.Text = "Katý Atýklar";
                }
                else if (comboBox8.SelectedIndex == 1)
                {
                    textBox4.Text = "Atýksularýn Arýtýlmasý";
                }
                else if (comboBox8.SelectedIndex == 2)
                {
                    textBox4.Text = "Ýçme Sularýnýn Arýtýlmasý";
                }
                else if (comboBox8.SelectedIndex == 3)
                {

                    textBox4.Text = "Su Temini ve Kanalizasyon";
                }
                else
                {
                    textBox4.Text = "Hava Kirliliði ";
                }
            }

            else if (comboBox5.SelectedIndex == 0)
            {

                if (comboBox9.SelectedIndex == 0)
                {
                    textBox4.Text = "Katý Atýklar";
                }
                else if (comboBox9.SelectedIndex == 1)
                {
                    textBox4.Text = "Atýksularýn Arýtýlmasý";
                }
                else if (comboBox9.SelectedIndex == 2)
                {
                    textBox4.Text = "Ýçme Sularýnýn Arýtýlmasý";
                }
                else if (comboBox9.SelectedIndex == 3)
                {

                    textBox4.Text = "Su Temini ve Kanalizasyon";
                }
                else
                {
                    textBox4.Text = "Hava Kirliliði";
                }
                   
            }
            //"Katý Atýklar, Atýksularýn Arýtýlmasý,Ýçme Sularýnýn Arýtýlmasý,Su Temini ve Kanalizasyon,Hava Kirliliði";
            else
            {

                Random random = new Random();
                int[] selectedIndexes = new int[] { comboBox7.SelectedIndex, comboBox8.SelectedIndex, comboBox9.SelectedIndex };
                int randomIndex = random.Next(0, selectedIndexes.Length);
                string[] selectedValues = {
                comboBox7.Items[selectedIndexes[0]].ToString(),
                comboBox8.Items[selectedIndexes[1]].ToString(),
                comboBox9.Items[selectedIndexes[2]].ToString()
                        };
                textBox4.Text = selectedValues[randomIndex];

                ListViewItem item = new ListViewItem(selectedValues);
                listView1.Items.Add(item);
                    MessageBox.Show("Kayýt baþarýlý bir þekilde gerçekleþti");
                }
           
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------

            // SqlCommand nesnesi oluþturulduktan sonra parametreleri oluþturun
            SqlCommand komut = new SqlCommand("INSERT INTO kayitlar (numara,adi, soyadi, alinanders1, harf1, alinanders2, harf2, alinanders3, harf3, tercih1, tercih2, tercih3, grup) VALUES (@numara,@adi, @soyadi,  @alinanders1, @harf1, @alinanders2, @harf2, @alinanders3, @harf3, @tercih1, @tercih2, @tercih3, @grup)", baglan);

            komut.Parameters.Add("@numara", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);
            komut.Parameters.Add("@adi", SqlDbType.NVarChar, 50).Value = textBox1.Text;
            komut.Parameters.Add("@soyadi", SqlDbType.NVarChar, 50).Value = textBox2.Text;
            komut.Parameters.Add("@alinanders1", SqlDbType.NVarChar, 100).Value = comboBox1.Text;
            komut.Parameters.Add("@harf1", SqlDbType.NVarChar, 100).Value = comboBox2.Text;
            komut.Parameters.Add("@alinanders2", SqlDbType.NVarChar, 100).Value = comboBox4.Text;
            komut.Parameters.Add("@harf2", SqlDbType.NVarChar, 100).Value = comboBox3.Text;
            komut.Parameters.Add("@alinanders3", SqlDbType.NVarChar, 100).Value = comboBox6.Text;
            komut.Parameters.Add("@harf3", SqlDbType.NVarChar, 100).Value = comboBox5.Text;
            komut.Parameters.Add("@tercih1", SqlDbType.NVarChar, 100).Value = comboBox7.Text;
            komut.Parameters.Add("@tercih2", SqlDbType.NVarChar, 100).Value = comboBox8.Text;
            komut.Parameters.Add("@tercih3", SqlDbType.NVarChar, 100).Value = comboBox9.Text;

            komut.Parameters.Add("@grup", SqlDbType.NVarChar, 100).Value = textBox4.Text;

            komut.ExecuteNonQuery();
            //baglan.Close();
            //----------------------------------

            //Su Temini ve Kanalizasyon


            int count = 0;

            {
                baglan.Close(); 
                baglan.Open();
            SqlCommand countCommand = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Su Temini ve Kanalizasyon'", baglan);
            count = Convert.ToInt32(countCommand.ExecuteScalar());
            }
            if (count > 6)
            {
             MessageBox.Show("Hata: Su Temini ve Kanalizasyon grubu maksimum kapasiteye ulaþtý.Tercihinizi deðiþtiriniz");
             return;
            }
            baglan.Close();
            //katý atýklar
             int count1 = 0;
   
            {
             baglan.Open();
             SqlCommand countCommand1 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'katý atýklar'", baglan);
             count1 = Convert.ToInt32(countCommand1.ExecuteScalar());
            }
            if (count1 > 6)
            {
             MessageBox.Show("Hata:katý atýklar grubu maksimum kapasiteye ulaþtý.Tercihinizi deðiþtiriniz");
             return;
            }
            baglan.Close();
            //Ýçme Sularýnýn Arýtýlmasý
            int count2 = 0;
            {
          baglan.Open();
          SqlCommand countCommand2 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Ýçme Sularýnýn Arýtýlmasý'", baglan);
          count2 = Convert.ToInt32(countCommand2.ExecuteScalar());
             }
           if (count2 > 6)
            {
             MessageBox.Show("Hata: Ýçme Sularýnýn Arýtýlmasý grubu maksimum kapasiteye ulaþtý.Tercihinizi deðiþtiriniz");
             return;
            }
            baglan.Close();
            //Atýksularýn Arýtýlmasý
            int count3 = 0;

           {
            baglan.Open();
            SqlCommand countCommand3 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Atýksularýn Arýtýlmasý'", baglan);
            count3 = Convert.ToInt32(countCommand3.ExecuteScalar());
            }
            if (count3 > 6)
            {
             MessageBox.Show("Hata: Atýksularýn Arýtýlmasý' grubu maksimum kapasiteye ulaþtý.Tercihinizi deðiþtiriniz");
             return;
            }
            baglan.Close();
            //Hava Kirliliði
            int count4 = 0;

            {
              baglan.Open();
              SqlCommand countCommand4 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Hava Kirliliði'", baglan);
              count4 = Convert.ToInt32(countCommand4.ExecuteScalar());
            }
            if (count4 > 6)
            {
             MessageBox.Show("Hata: Hava Kirliliði grubu maksimum kapasiteye ulaþtý.Tercihinizi deðiþtiriniz");
             return;
             }
            baglan.Close();
            //-----------------------------------------------------------------
            //baglan.Close();

            verilerigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            //textBox4.Clear();
            //textBox3.Focus();

        }

        int numara = 0;
        private void btnsil_Click_1(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete From kayitlar where numara = (" + numara + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
            textBox3.Focus();
        }
        //çift týklama ile silme
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            numara = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox3.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[6].Text;
            comboBox6.Text = listView1.SelectedItems[0].SubItems[7].Text;
            comboBox5.Text = listView1.SelectedItems[0].SubItems[8].Text;
            comboBox7.Text = listView1.SelectedItems[0].SubItems[9].Text;
            comboBox8.Text = listView1.SelectedItems[0].SubItems[10].Text;
            comboBox9.Text = listView1.SelectedItems[0].SubItems[11].Text;
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update kayitlar set numara='" + textBox3.Text.ToString() + "',adi='" + textBox1.Text.ToString() + "',soyadi='" + textBox2.Text.ToString() + "',alinanders1='" + comboBox1.Text.ToString() + "',harf1='" + comboBox2.Text.ToString() + "',alinanders2='" + comboBox4.Text.ToString() + "',harf2='" + comboBox3.Text.ToString() + "',alinanders3='" + comboBox6.Text.ToString() + "',harf3='" + comboBox5.Text.ToString() + "', tercih1='" + comboBox7.Text.ToString() + "',tercih2='" + comboBox8.Text.ToString() + "',tercih3='" + comboBox9.Text.ToString() + "',grup='" + textBox4.Text.ToString() + "'    where numara=" + numara + "", baglan);

            komut.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Güncelleme baþarýlý bir þekilde gerçekleþti");
            verilerigoster();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            comboBox7.SelectedIndex = 0;
            comboBox8.SelectedIndex = 0;
            comboBox9.SelectedIndex = 0;
        }

      
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = comboBox7.SelectedItem.ToString();
          
        }
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {

            textBox4.Text = comboBox8.SelectedItem.ToString();

        }
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox4.Text = comboBox9.SelectedItem.ToString();

        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

     
    }
}