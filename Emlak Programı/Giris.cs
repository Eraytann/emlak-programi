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
    public partial class Giris : Form
    {
        
        public Giris()
        {
            InitializeComponent();
        }
        public string Kullanicituru = "";
        public static string KullaniciAdiD = "";
        public static string AdSoyadD = "";
        public static string SifreD = "";
        private void btnGiris_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ToString();
            con.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM KullaniciBilgileri WHERE KullaniciAdi=@KullaniciAdi AND Sifre=@Sifre";
            cmd.Parameters.Add("@KullaniciAdi", OleDbType.Char);
            cmd.Parameters["@KullaniciAdi"].Value = txtKullaniciAdi.Text;
            cmd.Parameters.Add("@Sifre", OleDbType.Char);
            cmd.Parameters["@Sifre"].Value = txtSifre.Text;
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();

                KullaniciAdiD = dr[0].ToString();
                AdSoyadD = dr[1].ToString();
                SifreD = dr[2].ToString();

                Kullanicituru = dr[3].ToString();
                if (Kullanicituru == "Yönetici")
                {
                    YoneticiMenu frm_YoneticiMenu = new YoneticiMenu();
                    frm_YoneticiMenu.ShowDialog();
                }
                else if (Kullanicituru == "Misafir")
                {
                    MisafirMenu frm_MisafirMenu = new MisafirMenu();
                    frm_MisafirMenu.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifrenizi Yanlış Girdiniz.");
            }
        }

        private void Giris_Load(object sender, EventArgs e)
        {

        }
    }
}
