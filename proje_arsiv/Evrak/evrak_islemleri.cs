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

namespace proje_arsiv
{
    public partial class evrak_islemleri : Form
    {
        public evrak_islemleri()
        {
            InitializeComponent();
        }

        private void anaSayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anaform anafrm = new anaform();
            anafrm.Show();
            this.Hide();
        }

        private void evrakİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            evrak_islemleri evrak = new evrak_islemleri();
            evrak.Show();
            this.Hide();
        }

        private void raporlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void yeniEvrakOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Çıkış yapıldı.");
            Form1 anafrm = new Form1();
            anafrm.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void evrak_islemleri_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            evrak_düzenle anafrm = new evrak_düzenle();
            anafrm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void verilerToolStripMenuItem_Click(object sender, EventArgs e)
        {

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

        private void evrakSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
