using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Emlak_Programı
{
    public partial class uyeKayit : Form
    {
        public uyeKayit()
        {
            InitializeComponent();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ToString();
            con.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO KullaniciBilgileri (KullaniciAdi,AdSoyad,Sifre,Turu) Values(@KullaniciAdi,@Adsoyad,@Sifre,@Turu)";

            cmd.Parameters.Add("@KullaniciAdi", OleDbType.Char);
            cmd.Parameters["@KullaniciAdi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@KullaniciAdi"].Value = txtKullaniciAdi.Text;
            cmd.Parameters.Add("@AdSoyad", OleDbType.Char);
            cmd.Parameters["@AdSoyad"].Direction = ParameterDirection.Input;
            cmd.Parameters["@AdSoyad"].Value = txtAdSoyad.Text;
            cmd.Parameters.Add("@Sifre", OleDbType.Char);
            cmd.Parameters["@Sifre"].Direction = ParameterDirection.Input;
            cmd.Parameters["@Sifre"].Value = txtSifre.Text;
            cmd.Parameters.Add("@Turu", OleDbType.Char);
            cmd.Parameters["@Turu"].Direction = ParameterDirection.Input;
            cmd.Parameters["@Turu"].Value = comboBox1.Text;

            try
            {
                cmd.ExecuteNonQuery();
                txtAdSoyad.Text = "";
                txtKullaniciAdi.Text = "";
                txtSifre.Text = "";
                comboBox1.Text = "";
                MessageBox.Show("Kullanıcı Kaydedildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir Hata Oluştu: " + ex.Message);
            }
            con.Close();
        }

        private void uyeKayit_Load(object sender, EventArgs e)
        {

        }
    }
}
