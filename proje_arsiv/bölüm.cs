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
    public partial class bölüm : Form
    {
        public bölüm()
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
            string sorgu = "Select Count(b_ad) from bolum where b_ad= '" + textBox2.Text + "'";
            SqlCommand komut = new SqlCommand(sorgu, bgl.baglanti());

            sonuc = Convert.ToInt32(komut.ExecuteScalar());
            bgl.baglanti().Close();
            return sonuc;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into bolum (b_ad,o_id) values (@p1,@p2)", bgl.baglanti());
            if (textBox2.Text == "")
            {
                MessageBox.Show("Bölüm adı boş geçilemez.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (varMi(textBox2.Text) != 0)
                {
                    MessageBox.Show(textBox2.Text + " adında bir bölüm zaten mevcut.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    komut.Parameters.AddWithValue("@p1", textBox2.Text);
                    komut.Parameters.AddWithValue("@p2", textBox1.Text);
                    komut.ExecuteNonQuery();

                    bgl.baglanti().Close();

                    MessageBox.Show("Bölüm eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    verilerigoster("select b_id as 'Bölüm ID',b_ad as 'Bölüm Adı',o_ad as 'Oda Adı' from oda INNER JOIN bolum ON oda.o_id=bolum.o_id");

                    textBox2.Clear();
                    textBox2.Focus();
                    textBox1.ResetText();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from bolum" +
                " where b_id=@p1", bgl.baglanti());
            if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen silmek istediğiniz bir bölüm ismi seçiniz.");
            }
            else
            {
                DialogResult dialogResult = new DialogResult();
                dialogResult = MessageBox.Show("Seçilen bölümü silmek istiyor musunuz?");
                if (dialogResult == DialogResult.Yes)
                {
                    komut.Parameters.AddWithValue("@p1", textBox3.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Bölüm silindi.");
                    verilerigoster("select b_id as 'Bölüm ID',b_ad as 'Bölüm Adı',o_ad as 'Oda Adı' from oda INNER JOIN bolum ON oda.o_id=bolum.o_id");
                    
                    textBox2.Clear();
                    textBox1.ResetText();
                    textBox2.Focus();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch (Exception)
            {

            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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

        private void çıkışToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Çıkış yapıldı.");
            Form1 anafrm = new Form1();
            anafrm.Show();
            this.Hide();
        }

        private void anaSayfaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            
            anaform anafrm = new anaform();
            anafrm.Show();
            this.Hide();
        }

        private void bölüm_Load(object sender, EventArgs e)
        {

        }
    }
}
