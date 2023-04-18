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
    public partial class secim : Form
    {
        public secim()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            kiralik frm_kiralik = new kiralik();
            frm_kiralik.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            satilik frm_satilik = new satilik();
            frm_satilik.ShowDialog();
        }
    }
}
