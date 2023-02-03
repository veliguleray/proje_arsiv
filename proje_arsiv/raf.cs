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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proje_arsiv
{
    public partial class raf : Form
    {
        public raf()
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


        
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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

        private void FrmRaflar_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            SqlCommand komut = new SqlCommand("select * from oda");
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.ValueMember = "o_id";
            comboBox1.DisplayMember = "o_ad";
            comboBox1.DataSource = dt;
            verilerigoster("select r_id as 'Raf ID',r_ad as 'Raf Adı',b_ad as 'Bölüm Adı',o_ad as 'Oda Adı' from oda INNER JOIN bolum ON oda.o_id=bolum.o_id INNER JOIN raf ON bolum.b_id=raf.b_id");
        }

       
        public int varMi(string aranan)
        {
            int sonuc;
            string sorgu = "Select Count(r_ad) from raf where r_ad= '" + textBox1.Text + "'";
            SqlCommand komut = new SqlCommand(sorgu, bgl.baglanti());

            sonuc = Convert.ToInt32(komut.ExecuteScalar());
            bgl.baglanti().Close();
            return sonuc;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into raf (r_ad,b_id,o_id) values (@p1,@p2,@p3)", bgl.baglanti());
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Bölüm ekleyiniz.");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Boş geçilemez.");
            }
            else
            {
                if (varMi(textBox1.Text) != 0)
                {
                    MessageBox.Show(textBox1.Text + " mevcuttur.");
                }
                else
                {
                    komut.Parameters.AddWithValue("@p1", textBox1.Text);
                    komut.Parameters.AddWithValue("@p2", comboBox2.SelectedValue);
                    komut.Parameters.AddWithValue("@p3", comboBox1.SelectedValue);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Raf eklendi.");
                    verilerigoster("select r_id as 'Raf ID',r_ad as 'Raf Adı',b_ad as 'Bölüm Adı',o_ad as 'Oda Adı' from oda INNER JOIN bolum ON oda.o_id=bolum.o_id INNER JOIN raf ON bolum.b_id=raf.b_id");
                    
                    textBox1.Clear();
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    textBox1.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from raf where r_id = @p1", bgl.baglanti());
            if (textBox1.Text == "")
            {
                MessageBox.Show("Sileceğiniz rafı seçiniz.");
            }
            else
            {
                DialogResult dialogResult = new DialogResult();
                dialogResult = MessageBox.Show("Rafı Siliyorsunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();
                    MessageBox.Show("Raf silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    verilerigoster("select r_id as 'Raf ID',r_ad as 'Raf Adı',b_ad as 'Bölüm Adı',o_ad as 'Oda Adı' from oda INNER JOIN bolum ON oda.o_id=bolum.o_id INNER JOIN raf ON bolum.b_id=raf.b_id");
                  
                    textBox1.Clear();
                    comboBox1.ResetText();
                    comboBox2.ResetText();
                    textBox1.Focus();
                }
            }
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
            MessageBox.Show("Çıkış yapıldı.");
            Form1 anafrm = new Form1();
            anafrm.Show();
            this.Hide();
        }

        private void raf_Load(object sender, EventArgs e)
        {

        }
    }
}
