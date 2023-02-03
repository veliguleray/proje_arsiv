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
using System.Data.SqlClient;
using System.Data.Sql;

namespace proje_arsiv
{
    public partial class oda : Form
    {
        public oda()
        {
            InitializeComponent();
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

        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }


        private void oda_Load(object sender, EventArgs e)
        {

            textBox1.Focus();
            verilerigoster("select o_id as 'Oda ID', o_ad as 'Oda Adı' from oda");

        }





        sqlbaglantisi bgl = new sqlbaglantisi();

        void verilerigoster(string veriler)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(veriler, bgl.baglanti());
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }




        public int varMi(string aranan)
        {
            int sonuc;
            string sorgu = "Select Count(o_ad) from oda where o_ad= '" + textBox1.Text + "'";
            SqlCommand komut = new SqlCommand(sorgu, bgl.baglanti());

            sonuc = Convert.ToInt32(komut.ExecuteScalar());
            bgl.baglanti().Close();
            return sonuc;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into oda (o_ad) values (@p1)", bgl.baglanti());
            if (textBox1.Text == "")
            {
                MessageBox.Show("Oda adı boş geçilemez.");
            }
            else
            {
                if (varMi(textBox1.Text) != 0)
                {
                    MessageBox.Show(textBox1.Text + " diye bir oda vardır.");
                }
                else
                {
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Oda eklendi.");
                    verilerigoster("select o_id as 'Oda ID', o_ad as 'Oda Adı' from oda");
                 
                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            verilerigoster("select o_id as 'Oda ID', o_ad as 'Oda Adı' from oda where o_ad like '%" + textBox1.Text + "%'");

        }

        private void anaSayfaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
            anaform anafrm = new anaform();
            anafrm.Show();
            this.Hide();
        }

        private void odaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oda anafrm = new oda();
            anafrm.Show();
            this.Hide();
        }

        private void bölümToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bölüm anafrm = new bölüm();
            anafrm.Show();
            this.Hide();
        }

        private void rafToolStripMenuItem_Click(object sender, EventArgs e)
        {
            raf anafrm = new raf();
            anafrm.Show();
            this.Hide();
        }

        private void evrakDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            evrak_düzenle anafrm = new evrak_düzenle();
            anafrm.Show();
            this.Hide();
        }

        private void çıkışToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Çıkış Yapıldı.");
            Form1 anafrm = new Form1();
            anafrm.Show();
            this.Hide();
        }
    }
}
