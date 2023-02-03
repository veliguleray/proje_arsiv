using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proje_arsiv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-Q6F1S5H;Initial Catalog=proje_arsiv;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox_login_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sifreunuttum anafrm = new sifreunuttum();
            anafrm.Show();
            this.Hide();
        }

        private void button_girisyap_Click(object sender, EventArgs e)
        {

            try
            {
                baglanti.Open();
                string sql = "Select * From parola where Ad=@adi AND sifre=@sifresi";
                SqlParameter prmt1 = new SqlParameter ("adi",textBox_login.Text.Trim());
                SqlParameter prmt2 = new SqlParameter ("sifresi",textBox_password.Text.Trim());

                SqlCommand komut = new SqlCommand(sql, baglanti);
                komut.Parameters.Add (prmt1);
                komut.Parameters.Add (prmt2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if (dt.Rows.Count>0)
                {
                    anaform fr = new anaform();
                    fr.Show();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("hatalı giriş");
            }











            /*
            if (textBox_login.Text=="" || textBox_password.Text=="")
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");

            }
                else
	            {
                if (textBox_login.Text=="admin" && textBox_password.Text=="123")
                {
                    anaform anafrm = new anaform();
                    anafrm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı ve/veya Şifre Hatalıdır.");
                }
	            }*/
            
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            kayit_ol anafrm = new kayit_ol();
            anafrm.Show();
            this.Hide();
        }
    }
}
