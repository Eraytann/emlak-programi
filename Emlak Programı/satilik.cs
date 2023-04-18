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
    public partial class satilik : Form
    {
        public satilik()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SatilikKonut frm_SatilikKonut = new SatilikKonut();
            frm_SatilikKonut.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            satilikarsa frm_satilikarsa = new satilikarsa();
            frm_satilikarsa.ShowDialog();
        }
    }
}
