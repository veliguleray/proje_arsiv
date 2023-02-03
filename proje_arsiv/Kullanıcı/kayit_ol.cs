using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


namespace proje_arsiv
{
    public partial class kayit_ol : Form
    {
        public kayit_ol()
        {
            InitializeComponent();
        }


        




        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-Q6F1S5H;Initial Catalog=proje_arsiv;Integrated Security=True");
        
        private void button1_Click(object sender, EventArgs e)
        {

            string sorgu="insert into parola(ad,sifre)values(@v1,@v2)";
            SqlCommand komut = new SqlCommand(sorgu, baglanti);
            komut.Parameters.AddWithValue("@v1", textBox1.Text);
            komut.Parameters.AddWithValue("@v2", textBox2.Text);
            baglanti.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Kaydınız başarıyla tamamlandı.");
            textBox1.Clear();
            textBox2.Clear();
            baglanti.Close();
            Form1 anafrm = new Form1();
            anafrm.Show();
            this.Hide();





            ////baglanti.Open();
            ////SqlCommand komut = new SqlCommand("insert into parola (ad,sifre) Values (@p1,@p2)", bgl.baglanti());
            //////SqlCommand komut = new SqlCommand("Select * from parola(ad,sifre)values(@v1,@v2)", baglanti);
            ////if (durum == true)
            ////{
            ////    komut.Parameters.AddWithValue("@v1", textBox1.Text);
            ////    komut.Parameters.AddWithValue("@v2", textBox2.Text);
            ////    komut.ExecuteNonQuery();
            ////    bgl.baglanti().Close();

            ////    MessageBox.Show("Kullanıcı adı şifre oluşturuldu. Giriş Sayfasına Yönlendirileceksiniz.");
            ////}
            ////else
            ////{
            ////    MessageBox.Show("Hata");

            ////}

            ////baglanti.Close();
        }

        private void kayit_ol_Load(object sender, EventArgs e)
        {

        }
    }
}
