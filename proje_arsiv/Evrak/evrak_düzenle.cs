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
    public partial class evrak_düzenle : Form
    {
        public evrak_düzenle()
        {
            InitializeComponent();
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anaform anafrm = new anaform();
            anafrm.Show();
            this.Hide();
        }

        private void yeniEvrakOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çıkış yapıldı.");
            Form1 anafrm = new Form1();
            anafrm.Show();
            this.Hide();
        }

        private void evrakİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            evrak_islemleri evrak = new evrak_islemleri();
            evrak.Show();
            this.Hide();
        }

        private void raporlarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }



        sqlbaglantisi bgl = new sqlbaglantisi();

        void verilerigoster(string veriler)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(veriler, bgl.baglanti());
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update evrak set e_ad=@p1", bgl.baglanti());
            if (textBox1.Text == "")
            {
                MessageBox.Show("Düzenlemek istediğiniz evrağı seçin.");
            }
            else
            {
                komut.Parameters.AddWithValue("@p1", textBox1.Text);
                komut.Parameters.AddWithValue("@p2", textBox2.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Evrak kaydı güncellendi.");
                verilerigoster("select e_id as 'Evrak ID',e_ad as 'Evrak Adı' from evrak");
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        private void evrak_düzenle_Load(object sender, EventArgs e)
        {
            verilerigoster("select e_id as 'Evrak ID',e_ad as 'Evrak Adı' from evrak");

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
               }
            catch (Exception)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            verilerigoster("select e_id as 'Evrak ID',e_ad as 'Evrak Adı' from evrak where e_ad like '%" + button3.Text + "%'");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from evrak where e_id=@p1", bgl.baglanti());
            if (textBox1.Text == "")
            {
                MessageBox.Show("Silmek istediğiniz evrağı seçin.");
            }
            else
            {
                DialogResult dialogResult = new DialogResult();
                dialogResult = MessageBox.Show("Seçilen evrak kaydını silmek istiyor musunuz?");
                if (dialogResult == DialogResult.Yes)
                {
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Evrak kaydı silindi.");
                    textBox1.Clear();
                    textBox2.Clear();
                }
                verilerigoster("select e_id as 'Evrak ID',e_ad as 'Evrak Adı' from evrak");
            }
        }

        private void yeniEvrakOluşturToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

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

        private void bölümToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bölüm anafrm = new bölüm();
            anafrm.Show();
            this.Hide();
        }

        private void rafToolStripMenuItem1_Click(object sender, EventArgs e)
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

        private void evrakSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void çıkışToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Çıkış yapıldı.");
            Form1 anafrm = new Form1();
            anafrm.Show();
            this.Hide();
        }
    }
}
