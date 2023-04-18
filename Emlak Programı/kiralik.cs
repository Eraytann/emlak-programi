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
    public partial class kiralik : Form
    {
        public kiralik()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            kiralikisyeri frm_kiralikisyeri = new kiralikisyeri();
            frm_kiralikisyeri.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            kiralikkonut frm_kiralikkonut=new kiralikkonut();
            frm_kiralikkonut.ShowDialog();
        }
    }
}
