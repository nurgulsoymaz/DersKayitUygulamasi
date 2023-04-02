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
            listView1.Items.Clear();//en son eklenen g�r�ns�n her defada temizlensin


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


            //kat� at�klar grup say�s�
            baglan.Open();
            SqlCommand komut1 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'kat� at�klar'", baglan);
            SqlDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
                label16.Text = oku1[0].ToString();
            }
            baglan.Close();

            //i�me sular�n�n ar�t�lmas�
            baglan.Open();
            SqlCommand komut4 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = '��me Sular�n�n Ar�t�lmas�'", baglan);
            SqlDataReader oku4 = komut4.ExecuteReader();
            while (oku4.Read())
            {
                label21.Text = oku4[0].ToString();
            }
            baglan.Close();


            //At�ksular�n ar�t�lmas�
            baglan.Open();
            SqlCommand komut3 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'At�ksular�n Ar�t�lmas�'", baglan);
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

            //Hava Kirlili�i
            baglan.Open();
            SqlCommand komut5 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Hava Kirlili�i'", baglan);
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

            string[] students = new string[] { "��renci1", "��renci2", "��renci3", "��renci4", "��renci5", "��renci6", "��renci7", "��renci8", "��renci9", "��renci10", "��renci11", "��renci12", "��renci13", "��renci14", "��renci15", "��renci16", "��renci17", "��renci18", "��renci19", "��renci20", "��renci21", "��renci22", "��renci23", "��renci24", "��renci25", "��renci26", "��renci27", "��renci28", "��renci29", "��renci30" };

            // Gruplar�n bilgilerini tan�mlama

            Dictionary<string, List<string>> groups = new Dictionary<string, List<string>>();
            groups.Add("Kat� At�k", new List<string> { "Kat� At�klar" });
            groups.Add("At�ksular�n Ar�t�lmas�", new List<string> { "Biyolojik Temel ��lemler", "At�ksular�n Ar�t�lmas�" });
            groups.Add("��me Sular�n�n Ar�t�lmas�", new List<string> { "Fiziksel Temel ��lemler", "��me Sular�n�n Ar�t�lmas�" });
            groups.Add("Su Temini ve Kanalizasyon", new List<string> { "Hidrolik", "Su Temini", "At�ksular�n Uzakla�t�r�lmas�" });
            groups.Add("Hava Kirlili�i", new List<string> { "Hava Kirlili�i", "Hava Kirlili�i Kontrol�" });


            // ��rencilerin ders ge�me notlar�n� tan�mlama
            string harf1 = "AA,BA,BB,BC,CA,CB,CC,DD,FF,GG";
            string harf2 = "AA,BA,BB,BC,CA,CB,CC,DD,FF,GG";
            string harf3 = "AA,BA,BB,BC,CA,CB,CC,DD,FF,GG";

            string tercih1 = "Kat� At�klar,At�ksular�n Ar�t�lmas�,��me Sular�n�n Ar�t�lmas�,Su Temini ve Kanalizasyon,Hava Kirlili�i";
            string tercih2 = "Kat� At�klar,At�ksular�n Ar�t�lmas�,��me Sular�n�n Ar�t�lmas�,Su Temini ve Kanalizasyon,Hava Kirlili�i";
            string tercih3 = "Kat� At�klar,At�ksular�n Ar�t�lmas�,��me Sular�n�n Ar�t�lmas�,Su Temini ve Kanalizasyon,Hava Kirlili�i";



            if (comboBox2.SelectedIndex == 0)
            { 

                if (comboBox7.SelectedIndex == 0)
                {
                    textBox4.Text = "Kat� At�klar";
                }
                else if (comboBox7.SelectedIndex == 1)
                {
                    textBox4.Text = "At�ksular�n Ar�t�lmas�";
                }
                else if (comboBox7.SelectedIndex == 2)
                {
                    textBox4.Text = "��me Sular�n�n Ar�t�lmas�";
                }       
                else if (comboBox7.SelectedIndex == 3)
                {
                    textBox4.Text = "Su Temini ve Kanalizasyon";
                }
                else
                {
                    textBox4.Text = "Hava Kirlili�i";
                }

            }

            else if (comboBox3.SelectedIndex == 0)
            {

                if (comboBox8.SelectedIndex == 0)
                {
                    textBox4.Text = "Kat� At�klar";
                }
                else if (comboBox8.SelectedIndex == 1)
                {
                    textBox4.Text = "At�ksular�n Ar�t�lmas�";
                }
                else if (comboBox8.SelectedIndex == 2)
                {
                    textBox4.Text = "��me Sular�n�n Ar�t�lmas�";
                }
                else if (comboBox8.SelectedIndex == 3)
                {

                    textBox4.Text = "Su Temini ve Kanalizasyon";
                }
                else
                {
                    textBox4.Text = "Hava Kirlili�i ";
                }
            }

            else if (comboBox5.SelectedIndex == 0)
            {

                if (comboBox9.SelectedIndex == 0)
                {
                    textBox4.Text = "Kat� At�klar";
                }
                else if (comboBox9.SelectedIndex == 1)
                {
                    textBox4.Text = "At�ksular�n Ar�t�lmas�";
                }
                else if (comboBox9.SelectedIndex == 2)
                {
                    textBox4.Text = "��me Sular�n�n Ar�t�lmas�";
                }
                else if (comboBox9.SelectedIndex == 3)
                {

                    textBox4.Text = "Su Temini ve Kanalizasyon";
                }
                else
                {
                    textBox4.Text = "Hava Kirlili�i";
                }
                   
            }
            //"Kat� At�klar, At�ksular�n Ar�t�lmas�,��me Sular�n�n Ar�t�lmas�,Su Temini ve Kanalizasyon,Hava Kirlili�i";
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
                    MessageBox.Show("Kay�t ba�ar�l� bir �ekilde ger�ekle�ti");
                }
           
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------

            // SqlCommand nesnesi olu�turulduktan sonra parametreleri olu�turun
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
             MessageBox.Show("Hata: Su Temini ve Kanalizasyon grubu maksimum kapasiteye ula�t�.Tercihinizi de�i�tiriniz");
             return;
            }
            baglan.Close();
            //kat� at�klar
             int count1 = 0;
   
            {
             baglan.Open();
             SqlCommand countCommand1 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'kat� at�klar'", baglan);
             count1 = Convert.ToInt32(countCommand1.ExecuteScalar());
            }
            if (count1 > 6)
            {
             MessageBox.Show("Hata:kat� at�klar grubu maksimum kapasiteye ula�t�.Tercihinizi de�i�tiriniz");
             return;
            }
            baglan.Close();
            //��me Sular�n�n Ar�t�lmas�
            int count2 = 0;
            {
          baglan.Open();
          SqlCommand countCommand2 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = '��me Sular�n�n Ar�t�lmas�'", baglan);
          count2 = Convert.ToInt32(countCommand2.ExecuteScalar());
             }
           if (count2 > 6)
            {
             MessageBox.Show("Hata: ��me Sular�n�n Ar�t�lmas� grubu maksimum kapasiteye ula�t�.Tercihinizi de�i�tiriniz");
             return;
            }
            baglan.Close();
            //At�ksular�n Ar�t�lmas�
            int count3 = 0;

           {
            baglan.Open();
            SqlCommand countCommand3 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'At�ksular�n Ar�t�lmas�'", baglan);
            count3 = Convert.ToInt32(countCommand3.ExecuteScalar());
            }
            if (count3 > 6)
            {
             MessageBox.Show("Hata: At�ksular�n Ar�t�lmas�' grubu maksimum kapasiteye ula�t�.Tercihinizi de�i�tiriniz");
             return;
            }
            baglan.Close();
            //Hava Kirlili�i
            int count4 = 0;

            {
              baglan.Open();
              SqlCommand countCommand4 = new SqlCommand("SELECT COUNT(*) FROM kayitlar WHERE grup = 'Hava Kirlili�i'", baglan);
              count4 = Convert.ToInt32(countCommand4.ExecuteScalar());
            }
            if (count4 > 6)
            {
             MessageBox.Show("Hata: Hava Kirlili�i grubu maksimum kapasiteye ula�t�.Tercihinizi de�i�tiriniz");
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
        //�ift t�klama ile silme
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
            MessageBox.Show("G�ncelleme ba�ar�l� bir �ekilde ger�ekle�ti");
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