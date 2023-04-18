using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Emlak_Programı
{
    public partial class YoneticiMenu : Form
    {
        public YoneticiMenu()
        {
            InitializeComponent();
        }

        private void pboxIlanKayit_Click(object sender, EventArgs e)
        {
            secim frm_secim = new secim();
            frm_secim.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           uyeKayit frm_uyekayit = new uyeKayit();
           frm_uyekayit.ShowDialog();
        }

        private void pbox_Click(object sender, EventArgs e)
        {

        }
    }
}
