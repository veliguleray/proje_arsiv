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

namespace proje_arsiv
{
    public partial class anaform : Form
    {
        public anaform()
        {
            InitializeComponent();
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

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

        private void yeniEvrakOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void veriİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void evrakİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            evrak_islemleri evrak = new evrak_islemleri();
            evrak.Show();
            this.Hide();
        }

        private void yeniEvrakOluşturToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
        }

        private void evrakDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void evrakSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void yeniEvrakOluşturToolStripMenuItem_Click_2(object sender, EventArgs e)
        {
            

        }

        private void evrakDüzenleToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            evrak_düzenle anafrm = new evrak_düzenle();
            anafrm.Show();
            this.Hide();

        }

        private void evrakSilToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            

        }

        private void bölümToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bölüm anafrm = new bölüm();
            anafrm.Show();
            this.Hide();
        }

        private void kullanıcıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void anaform_Load(object sender, EventArgs e)
        {

        }

        private void odaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oda anafrm = new oda();
            anafrm.Show();
            this.Hide();
        }

        private void rafToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            raf anafrm = new raf();
            anafrm.Show();
            this.Hide();
        }

        private void klasörToolStripMenuItem1_Click(object sender, EventArgs e)
        {
             
        }

        private void dosyaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
