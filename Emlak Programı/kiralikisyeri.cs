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
    public partial class kiralikisyeri : Form
    {
        public kiralikisyeri()
        {
            InitializeComponent();
        }
        string resimyolu = "";
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        DataTable tablo = new DataTable();
        private void btnResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                resimyolu = ofd.FileName;
                pictureBox4.ImageLocation = resimyolu;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ConnectionString;
            con.Open();

            //Komut Nesnesi Oluştur
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO kiralikisyeri(ilanbaslik,kira,emlaktipi,isitma,il,ilce,mkare,eklenmetarihi,mulksahibi,telefonNo,adres,resim) Values(@ilanbaslik,@kira,@emlaktipi,@isitma,@il,@ilce,@mkare,@eklenmetarihi,@mulksahibi,@telefonNo,@adres,@resim)";

            //Parametreleri Oluştur
            cmd.Parameters.Add("@ilanbaslik", OleDbType.VarChar);
            cmd.Parameters["@ilanbaslik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilanbaslik"].Value = cbIlanBasligi.Text;
            cmd.Parameters.Add("@kira", OleDbType.VarChar);
            cmd.Parameters["@kira"].Direction = ParameterDirection.Input;
            cmd.Parameters["@kira"].Value = txtKira.Text;
            cmd.Parameters.Add("@emlaktipi", OleDbType.VarChar);
            cmd.Parameters["@emlaktipi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@emlaktipi"].Value = lblisyeri.Text;
            cmd.Parameters.Add("@mkare", OleDbType.VarChar);
            cmd.Parameters["@mkare"].Direction = ParameterDirection.Input;
            cmd.Parameters["@mkare"].Value = txtMetrekare.Text;
            cmd.Parameters.Add("@il", OleDbType.VarChar);
            cmd.Parameters["@il"].Direction = ParameterDirection.Input;
            cmd.Parameters["@il"].Value = cbil.Text;
            cmd.Parameters.Add("@ilce", OleDbType.VarChar);
            cmd.Parameters["@ilce"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilce"].Value = cbIlce.Text;
            cmd.Parameters.Add("@telefonNo", OleDbType.VarChar);
            cmd.Parameters["@telefonNo"].Direction = ParameterDirection.Input;
            cmd.Parameters["@telefonNo"].Value = txtTelefon.Text;
            cmd.Parameters.Add("@isitma", OleDbType.VarChar);
            cmd.Parameters["@isitma"].Direction = ParameterDirection.Input;
            cmd.Parameters["@isitma"].Value = cbIsitma.Text;
            cmd.Parameters.Add("@eklenmetarihi", OleDbType.VarChar);
            cmd.Parameters["@eklenmetarihi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@eklenmetarihi"].Value = dtpTarih.Text;
            cmd.Parameters.Add("@mulksahibi", OleDbType.VarChar);
            cmd.Parameters["@mulksahibi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@mulksahibi"].Value = txtSahip.Text;
            cmd.Parameters.Add("@adres", OleDbType.VarChar);
            cmd.Parameters["@adres"].Direction = ParameterDirection.Input;
            cmd.Parameters["@adres"].Value = txtAdres.Text;
            cmd.Parameters.Add("@resim", OleDbType.VarChar);
            cmd.Parameters["@resim"].Direction = ParameterDirection.Input;
            cmd.Parameters["@resim"].Value = resimyolu;

            try
            {
                cmd.ExecuteNonQuery();
                txtAdres.Text = "";
                txtKira.Text = "";
                txtMetrekare.Text = "";
                cbIsitma.Text = "";
                txtTelefon.Text = "";
                cbil.Text = "";
                txtTelefon.Text = "";
                txtSahip.Text = "";
                cbIlce.Text = "";
                pictureBox4.ImageLocation = null;
                MessageBox.Show("Başarıyla Kaydedildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            //Bağlantıyı Kapat
            con.Close();
        }

        private void cbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "select ilceAdi From ilceler Where ilid=" + cbil.SelectedValue;

            OleDbDataReader dr;
            dr = cmd.ExecuteReader();
            cbIlce.Items.Clear();
            while (dr.Read())
            {
                cbIlce.Items.Add(dr[0].ToString());
            }
            con.Close();
        }

        private void ilEkle()
        {
            DataTable dt = new DataTable();
            adtr = new OleDbDataAdapter("select * from iller ", con);
            adtr.Fill(dt);
            cbil.ValueMember = "id";
            cbil.DisplayMember = "ilAdi";
            cbil.DataSource = dt;
        }

        private void kiralikisyeri_Load(object sender, EventArgs e)
        {
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ToString();
            dtpTarih.MinDate = DateTime.Now.Date;
            ilEkle();
            con.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ilanbaslik FROM kiralikisyeri";

            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbIlanBasligi.Items.Add(dr["ilanbaslik"].ToString());
            }
            con.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ConnectionString;
            con.Open();

            //Komut Nesnesi Oluştur
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE kiralikisyeri SET ilanbaslik=@ilanbaslik,kira=@kira,emlaktipi=@emlaktipi,isitma=@isitma,il=@il,ilce=@ilce,mkare=@mkare,eklenmetarihi=@eklenmetarihi,mulksahibi=@mulksahibi,telefonNo=@telefonNo,adres=@adres,resim=@resim WHERE ilanbaslik=@ilanbaslik";

            //Parametreleri Oluştur
            cmd.Parameters.Add("@ilanbaslik", OleDbType.VarChar);
            cmd.Parameters["@ilanbaslik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilanbaslik"].Value = cbIlanBasligi.Text;
            cmd.Parameters.Add("@kira", OleDbType.VarChar);
            cmd.Parameters["@kira"].Direction = ParameterDirection.Input;
            cmd.Parameters["@kira"].Value = txtKira.Text;
            cmd.Parameters.Add("@emlaktipi", OleDbType.VarChar);
            cmd.Parameters["@emlaktipi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@emlaktipi"].Value = lblisyeri.Text;
            cmd.Parameters.Add("@mkare", OleDbType.VarChar);
            cmd.Parameters["@mkare"].Direction = ParameterDirection.Input;
            cmd.Parameters["@mkare"].Value = txtMetrekare.Text;
            cmd.Parameters.Add("@il", OleDbType.VarChar);
            cmd.Parameters["@il"].Direction = ParameterDirection.Input;
            cmd.Parameters["@il"].Value = cbil.Text;
            cmd.Parameters.Add("@ilce", OleDbType.VarChar);
            cmd.Parameters["@ilce"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilce"].Value = cbIlce.Text;
            cmd.Parameters.Add("@telefonNo", OleDbType.VarChar);
            cmd.Parameters["@telefonNo"].Direction = ParameterDirection.Input;
            cmd.Parameters["@telefonNo"].Value = txtTelefon.Text;
            cmd.Parameters.Add("@isitma", OleDbType.VarChar);
            cmd.Parameters["@isitma"].Direction = ParameterDirection.Input;
            cmd.Parameters["@isitma"].Value = cbIsitma.Text;
            cmd.Parameters.Add("@eklenmetarihi", OleDbType.VarChar);
            cmd.Parameters["@eklenmetarihi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@eklenmetarihi"].Value = dtpTarih.Text;
            cmd.Parameters.Add("@mulksahibi", OleDbType.VarChar);
            cmd.Parameters["@mulksahibi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@mulksahibi"].Value = txtSahip.Text;
            cmd.Parameters.Add("@adres", OleDbType.VarChar);
            cmd.Parameters["@adres"].Direction = ParameterDirection.Input;
            cmd.Parameters["@adres"].Value = txtAdres.Text;
            cmd.Parameters.Add("@resim", OleDbType.VarChar);
            cmd.Parameters["@resim"].Direction = ParameterDirection.Input;
            cmd.Parameters["@resim"].Value = resimyolu;

            try
            {
                cmd.ExecuteNonQuery();
                txtAdres.Text = "";
                txtKira.Text = "";
                txtMetrekare.Text = "";
                cbIsitma.Text = "";
                txtTelefon.Text = "";
                cbil.Text = "";
                txtTelefon.Text = "";
                txtSahip.Text = "";
                cbIlce.Text = "";
                pictureBox4.ImageLocation = null;
                MessageBox.Show("Başarıyla Güncellendi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            //Bağlantıyı Kapat
            con.Close();
        }

        private void cbIlanBasligi_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ConnectionString;
            con.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kiralikisyeri WHERE ilanbaslik=@ilanbaslik";
            cmd.Parameters.Add("@ilanbaslik", OleDbType.Char);
            cmd.Parameters["@ilanbaslik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilanbaslik"].Value = cbIlanBasligi.Text;

            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                txtAdres.Text = dr["adres"].ToString();
                txtKira.Text = dr["kira"].ToString();
                txtSahip.Text = dr["mulksahibi"].ToString();
                txtTelefon.Text = dr["telefonNo"].ToString();
                cbil.Text = dr["ilce"].ToString();
                cbIlce.Text = dr["ilce"].ToString();
                cbIsitma.Text = dr["isitma"].ToString();
                txtMetrekare.Text = dr["mkare"].ToString();
                lblisyeri.Text = dr["emlaktipi"].ToString();
                pictureBox4.ImageLocation = dr["resim"].ToString();
            }
            con.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //connection
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ConnectionString;
            con.Open();

            //command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "DELETE FROM kiralikisyeri WHERE ilanbaslik=@ilanbaslik";

            //Parametre
            cmd.Parameters.Add("@ilanbaslik", OleDbType.Char);
            cmd.Parameters["@ilanbaslik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilanbaslik"].Value = cbIlanBasligi.Text;
            if (MessageBox.Show("Bu Kaydı silmek istediğinizden emin misiniz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    txtAdres.Text = "";
                    txtKira.Text = "";
                    txtMetrekare.Text = "";
                    cbIsitma.Text = "";
                    txtTelefon.Text = "";
                    cbil.Text = "";
                    txtTelefon.Text = "";
                    txtSahip.Text = "";
                    cbIlce.Text = "";
                    pictureBox4.ImageLocation = null;
                    MessageBox.Show("Başarıyla Silindi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata:" + ex.Message);
                }
            }
        }
    }
}
