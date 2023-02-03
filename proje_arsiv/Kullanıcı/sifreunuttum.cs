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
using System.Data.Sql;
using System.Net;
using System.Net.Mail;





namespace proje_arsiv
{
    public partial class sifreunuttum : Form
    {
        public sifreunuttum()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-Q6F1S5H;Initial Catalog=proje_arsiv;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            sqlbaglantisi bgln = new sqlbaglantisi();
            SqlCommand komut = new SqlCommand("Select * from parola where ad='" + textBox1.Text.ToString()+"'and sifre ='" + textBox2.Text.ToString() + "'", bgln.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                try
                {
                    if (bgln.baglanti().State == ConnectionState.Closed)
                    {
                        bgln.baglanti().Close();
                    }

                    SmtpClient smtpserver = new SmtpClient();
                    MailMessage mail = new MailMessage();

                    string tarih = DateTime.Now.ToLongDateString();
                    string mailadresin =("visualsdeneme2022@gmail.com");
                    string sifre =("1a2b3c4d5e6f7g");
                    string smptsrvr =("smtp.gmail.com");
                    string kime = (oku["eposta"].ToString());
                    string konu = ("şifreniz");
                    string yaz = ("Sayın," + oku["ad"].ToString()+"\n"+"bizden"+tarih+" tarihinde şifre hatırlatma talebinde bulundunuz."+"\n"+"Parolanız: " + oku["Şifre"].ToString()+"\n İyi Günler");
                    
                    smtpserver.Credentials = new NetworkCredential(mailadresin, sifre);
                    smtpserver.Port = 587;
                    smtpserver.Host = smptsrvr;
                    smtpserver.EnableSsl = true;
                    mail.From = new MailAddress(mailadresin);
                    mail.To.Add(kime);
                    mail.Subject = konu;
                    mail.Body = yaz;
                    smtpserver.Send(mail); 

                    DialogResult bilgi = new DialogResult();
                    bilgi = MessageBox.Show("Şifreniz mail adresinize gönderilmiştir.");
                    this.Hide();    

                }
                catch(Exception Hata)
                {
                    MessageBox.Show("Mail gönderme hatası",Hata.Message);

                }


            }
        
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anaform anafrm = new anaform();
            anafrm.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çıkış yapıldı.");
            Form1 anafrm = new Form1();
            anafrm.Show();
            this.Hide();
        }

        private void sifreunuttum_Load(object sender, EventArgs e)
        {

        }
    }
}
