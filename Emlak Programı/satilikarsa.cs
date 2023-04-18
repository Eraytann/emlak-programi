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

    public partial class satilikarsa : Form
    {
        string resimyolu = "";
        public satilikarsa()
        {
            InitializeComponent();
        }
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        OleDbConnection con = new OleDbConnection();
        OleDbCommand cmd = new OleDbCommand();
        DataTable tablo = new DataTable();
        private void satilikarsa_Load(object sender, EventArgs e)
        {
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ToString();
            dtpTarih.MinDate = DateTime.Now.Date;
            ilEkle();
            con.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ilanbaslik FROM satilikarsa";

            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbilanbaslik.Items.Add(dr["ilanbaslik"].ToString());
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

        private void btnResim_Click(object sender, EventArgs e)
        {

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
            cmd.CommandText = "INSERT INTO satilikarsa(ilanbaslik,fiyat,emlaktipi,mkare,il,ilce,telefonNo,maxKat,mkarefiyati,ilgilibdiye,eklenmetarihi,mulksahibi,katkarsilik,adres,resim,DenizManzarali,ElektrikHatti,Kanalizasyon,Su,YolaYakin,DogaManzarali,GolManzarali,Parselli,TelefonHatti,YoluAcilmis,Projeli,TopluUlasim,imarli,SanayiElektrigi) Values(@ilanbaslik,@fiyat,@emlaktipi,@mkare,@il,@ilce,@telefonNo,@maxKat,@mkarefiyati,@ilgilibdiye,@eklenmetarihi,@mulksahibi,@katkarsilik,@adres,@resim,@DenizManzarali,@ElektrikHatti,@Kanalizasyon,@Su,@YolaYakin,@DogaManzarali,@GolManzarali,@Parselli,@TelefonHatti,@YoluAcilmis,@Projeli,@TopluUlasim,@imarli,@SanayiElektrigi)";

            //Parametreleri Oluştur
            cmd.Parameters.Add("@ilanbaslik", OleDbType.VarChar);
            cmd.Parameters["@ilanbaslik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilanbaslik"].Value = cbilanbaslik.Text;
            cmd.Parameters.Add("@fiyat", OleDbType.VarChar);
            cmd.Parameters["@fiyat"].Direction = ParameterDirection.Input;
            cmd.Parameters["@fiyat"].Value = txtFiyat.Text;
            cmd.Parameters.Add("@emlaktipi", OleDbType.VarChar);
            cmd.Parameters["@emlaktipi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@emlaktipi"].Value = lblEmlakTipi.Text;
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
            cmd.Parameters.Add("@maxKat", OleDbType.VarChar);
            cmd.Parameters["@maxKat"].Direction = ParameterDirection.Input;
            cmd.Parameters["@maxKat"].Value = txtKatSayisi.Text;
            cmd.Parameters.Add("@mkarefiyatı", OleDbType.VarChar);
            cmd.Parameters["@mkarefiyatı"].Direction = ParameterDirection.Input;
            cmd.Parameters["@mkarefiyatı"].Value = txtBirimFiyati.Text;
            cmd.Parameters.Add("@ilgilibdiye", OleDbType.VarChar);
            cmd.Parameters["@ilgilibdiye"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilgilibdiye"].Value = txtIlgiliBelediye.Text;
            cmd.Parameters.Add("@eklenmetarihi", OleDbType.VarChar);
            cmd.Parameters["@eklenmetarihi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@eklenmetarihi"].Value = dtpTarih.Text;
            cmd.Parameters.Add("@mulksahibi", OleDbType.VarChar);
            cmd.Parameters["@mulksahibi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@mulksahibi"].Value = txtSahip.Text;
            cmd.Parameters.Add("@katkarsilik", OleDbType.VarChar);
            cmd.Parameters["@katkarsilik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@katkarsilik"].Value = (int)chbKatKarsiligi.CheckState;
            cmd.Parameters.Add("@adres", OleDbType.VarChar);
            cmd.Parameters["@adres"].Direction = ParameterDirection.Input;
            cmd.Parameters["@adres"].Value = txtAdres.Text;
            cmd.Parameters.Add("@resim", OleDbType.VarChar);
            cmd.Parameters["@resim"].Direction = ParameterDirection.Input;
            cmd.Parameters["@resim"].Value = resimyolu;
            cmd.Parameters.Add("@DenizManzarali", OleDbType.VarChar);
            cmd.Parameters["@DenizManzarali"].Direction = ParameterDirection.Input;
            cmd.Parameters["@DenizManzarali"].Value = (int)chbDenizManzarali.CheckState;
            cmd.Parameters.Add("@ElektrikHatti", OleDbType.VarChar);
            cmd.Parameters["@ElektrikHatti"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ElektrikHatti"].Value = (int)chbElektrikHatti.CheckState;
            cmd.Parameters.Add("@Kanalizasyon", OleDbType.VarChar);
            cmd.Parameters["@Kanalizasyon"].Direction = ParameterDirection.Input;
            cmd.Parameters["@Kanalizasyon"].Value = (int)chbKanalizasyon.CheckState;
            cmd.Parameters.Add("@Su", OleDbType.VarChar);
            cmd.Parameters["@Su"].Direction = ParameterDirection.Input;
            cmd.Parameters["@Su"].Value = (int)chbSu.CheckState;
            cmd.Parameters.Add("@YolaYakin", OleDbType.VarChar);
            cmd.Parameters["@YolaYakin"].Direction = ParameterDirection.Input;
            cmd.Parameters["@YolaYakin"].Value = (int)chbYolaYakin.CheckState;
            cmd.Parameters.Add("@DogaManzarali", OleDbType.VarChar);
            cmd.Parameters["@DogaManzarali"].Direction = ParameterDirection.Input;
            cmd.Parameters["@DogaManzarali"].Value = (int)chbDogaManzarali.CheckState;
            cmd.Parameters.Add("@GolManzarali", OleDbType.VarChar);
            cmd.Parameters["@GolManzarali"].Direction = ParameterDirection.Input;
            cmd.Parameters["@GolManzarali"].Value = (int)chbGolManzarali.CheckState;
            cmd.Parameters.Add("@Parselli", OleDbType.VarChar);
            cmd.Parameters["@Parselli"].Direction = ParameterDirection.Input;
            cmd.Parameters["@Parselli"].Value = (int)chbParselli.CheckState;
            cmd.Parameters.Add("@TelefonHatti", OleDbType.VarChar);
            cmd.Parameters["@TelefonHatti"].Direction = ParameterDirection.Input;
            cmd.Parameters["@TelefonHatti"].Value = (int)chbTelefonHatti.CheckState;
            cmd.Parameters.Add("@YoluAcilmis", OleDbType.VarChar);
            cmd.Parameters["@YoluAcilmis"].Direction = ParameterDirection.Input;
            cmd.Parameters["@YoluAcilmis"].Value = (int)chbDenizManzarali.CheckState;
            cmd.Parameters.Add("@Projeli", OleDbType.VarChar);
            cmd.Parameters["@Projeli"].Direction = ParameterDirection.Input;
            cmd.Parameters["@Projeli"].Value = (int)chbProjeli.CheckState;
            cmd.Parameters.Add("@TopluUlasim", OleDbType.VarChar);
            cmd.Parameters["@TopluUlasim"].Direction = ParameterDirection.Input;
            cmd.Parameters["@TopluUlasim"].Value = (int)chbTopluUlasim.CheckState;
            cmd.Parameters.Add("@imarli", OleDbType.VarChar);
            cmd.Parameters["@imarli"].Direction = ParameterDirection.Input;
            cmd.Parameters["@imarli"].Value = (int)chbImarli.CheckState;
            cmd.Parameters.Add("@SanayiElektrigi", OleDbType.VarChar);
            cmd.Parameters["@SanayiElektrigi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@SanayiElektrigi"].Value = (int)chbSanayiElektrigi.CheckState;

            try
            {
                cmd.ExecuteNonQuery();
                cbilanbaslik.Text = "";
                txtAdres.Text = "";
                txtFiyat.Text = "";
                txtMetrekare.Text = "";
                txtTelefon.Text = "";
                cbil.Text = "";
                txtTelefon.Text = "";
                txtKatSayisi.Text = "";
                txtBirimFiyati.Text = "";
                txtIlgiliBelediye.Text = "";
                txtSahip.Text = "";
                pictureBox4.ImageLocation = null;
                chbKatKarsiligi.Checked = false;
                chbDenizManzarali.Checked = false;
                chbElektrikHatti.Checked = false;
                chbKanalizasyon.Checked = false;
                chbSu.Checked = false;
                chbYolaYakin.Checked = false;
                chbDogaManzarali.Checked = false;
                chbGolManzarali.Checked = false;
                chbParselli.Checked = false;
                chbTelefonHatti.Checked = false;
                chbYoluAcilmis.Checked = false;
                chbProjeli.Checked = false;
                chbTopluUlasim.Checked = false;
                chbImarli.Checked = false;
                chbSanayiElektrigi.Checked = false;
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

        private void cbilanbaslik_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ConnectionString;
            con.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM satilikarsa WHERE ilanbaslik=@ilanbaslik";
            cmd.Parameters.Add("@ilanbaslik", OleDbType.Char);
            cmd.Parameters["@ilanbaslik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilanbaslik"].Value = cbilanbaslik.Text;

            OleDbDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                txtAdres.Text = dr["adres"].ToString();
                txtBirimFiyati.Text = dr["mkarefiyati"].ToString();
                txtFiyat.Text = dr["fiyat"].ToString();
                txtIlgiliBelediye.Text = dr["ilgilibdiye"].ToString();
                txtKatSayisi.Text = dr["maxKat"].ToString();
                txtMetrekare.Text = dr["mkare"].ToString();
                txtSahip.Text = dr["mulksahibi"].ToString();
                txtTelefon.Text = dr["telefonNo"].ToString();
                cbil.Text = dr["il"].ToString();
                cbIlce.Text = dr["ilce"].ToString();
                chbDenizManzarali.Checked = Convert.ToBoolean(dr["DenizManzarali"].ToString());
                chbDogaManzarali.Checked = Convert.ToBoolean(dr["DogaManzarali"].ToString());
                chbElektrikHatti.Checked = Convert.ToBoolean(dr["ElektrikHatti"].ToString());
                chbGolManzarali.Checked = Convert.ToBoolean(dr["GolManzarali"].ToString());
                chbImarli.Checked = Convert.ToBoolean(dr["imarli"].ToString());
                chbKanalizasyon.Checked = Convert.ToBoolean(dr["Kanalizasyon"].ToString());
                chbKatKarsiligi.Checked = Convert.ToBoolean(dr["katkarsilik"].ToString());
                chbParselli.Checked = Convert.ToBoolean(dr["Parselli"].ToString());
                chbProjeli.Checked = Convert.ToBoolean(dr["Projeli"].ToString());
                chbSanayiElektrigi.Checked = Convert.ToBoolean(dr["SanayiElektrigi"].ToString());
                chbSu.Checked = Convert.ToBoolean(dr["Su"].ToString());
                chbTelefonHatti.Checked = Convert.ToBoolean(dr["TelefonHatti"].ToString());
                chbTopluUlasim.Checked = Convert.ToBoolean(dr["TopluUlasim"].ToString());
                chbYolaYakin.Checked = Convert.ToBoolean(dr["YolaYakin"].ToString());
                chbYoluAcilmis.Checked = Convert.ToBoolean(dr["YoluAcilmis"].ToString());
                pictureBox4.ImageLocation = dr["resim"].ToString();
            }
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ConnectionString;
            con.Open();

            //Komut Nesnesi Oluştur
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE satilikarsa SET ilanbaslik=@ilanbaslik,fiyat=@fiyat,emlaktipi=@emlaktipi,mkare=@mkare,il=@il,ilce=@ilce,telefonNo=@telefonNo,maxKat=@maxKat,mkarefiyati=@mkarefiyati,ilgilibdiye=@ilgilibdiye,eklenmetarihi=@eklenmetarihi,mulksahibi=@mulksahibi,katkarsilik=@katkarsilik,adres=@adres,resim=@resim,DenizManzarali=@DenizManzarali,ElektrikHatti=@ElektrikHatti,Kanalizasyon=@Kanalizasyon,Su=@Su,YolaYakin=@YolaYakin,DogaManzarali=@DogaManzarali,GolManzarali=@GolManzarali,Parselli=@Parselli,TelefonHatti=@TelefonHatti,YoluAcilmis=@YoluAcilmis,Projeli=@Projeli,TopluUlasim=@TopluUlasim,imarli=@imarli,SanayiElektrigi=@SanayiElektrigi WHERE ilanbaslik=@ilanbaslik";

            //Parametreleri Oluştur
            cmd.Parameters.Add("@ilanbaslik", OleDbType.VarChar);
            cmd.Parameters["@ilanbaslik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilanbaslik"].Value = cbilanbaslik.Text;
            cmd.Parameters.Add("@fiyat", OleDbType.VarChar);
            cmd.Parameters["@fiyat"].Direction = ParameterDirection.Input;
            cmd.Parameters["@fiyat"].Value = txtFiyat.Text;
            cmd.Parameters.Add("@emlaktipi", OleDbType.VarChar);
            cmd.Parameters["@emlaktipi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@emlaktipi"].Value = lblEmlakTipi.Text;
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
            cmd.Parameters.Add("@maxKat", OleDbType.VarChar);
            cmd.Parameters["@maxKat"].Direction = ParameterDirection.Input;
            cmd.Parameters["@maxKat"].Value = txtKatSayisi.Text;
            cmd.Parameters.Add("@mkarefiyatı", OleDbType.VarChar);
            cmd.Parameters["@mkarefiyatı"].Direction = ParameterDirection.Input;
            cmd.Parameters["@mkarefiyatı"].Value = txtBirimFiyati.Text;
            cmd.Parameters.Add("@ilgilibdiye", OleDbType.VarChar);
            cmd.Parameters["@ilgilibdiye"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilgilibdiye"].Value = txtIlgiliBelediye.Text;
            cmd.Parameters.Add("@eklenmetarihi", OleDbType.VarChar);
            cmd.Parameters["@eklenmetarihi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@eklenmetarihi"].Value = dtpTarih.Text;
            cmd.Parameters.Add("@mulksahibi", OleDbType.VarChar);
            cmd.Parameters["@mulksahibi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@mulksahibi"].Value = txtSahip.Text;
            cmd.Parameters.Add("@katkarsilik", OleDbType.VarChar);
            cmd.Parameters["@katkarsilik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@katkarsilik"].Value = (int)chbKatKarsiligi.CheckState;
            cmd.Parameters.Add("@adres", OleDbType.VarChar);
            cmd.Parameters["@adres"].Direction = ParameterDirection.Input;
            cmd.Parameters["@adres"].Value = txtAdres.Text;
            cmd.Parameters.Add("@resim", OleDbType.VarChar);
            cmd.Parameters["@resim"].Direction = ParameterDirection.Input;
            cmd.Parameters["@resim"].Value = resimyolu;
            cmd.Parameters.Add("@DenizManzarali", OleDbType.VarChar);
            cmd.Parameters["@DenizManzarali"].Direction = ParameterDirection.Input;
            cmd.Parameters["@DenizManzarali"].Value = (int)chbDenizManzarali.CheckState;
            cmd.Parameters.Add("@ElektrikHatti", OleDbType.VarChar);
            cmd.Parameters["@ElektrikHatti"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ElektrikHatti"].Value = (int)chbElektrikHatti.CheckState;
            cmd.Parameters.Add("@Kanalizasyon", OleDbType.VarChar);
            cmd.Parameters["@Kanalizasyon"].Direction = ParameterDirection.Input;
            cmd.Parameters["@Kanalizasyon"].Value = (int)chbKanalizasyon.CheckState;
            cmd.Parameters.Add("@Su", OleDbType.VarChar);
            cmd.Parameters["@Su"].Direction = ParameterDirection.Input;
            cmd.Parameters["@Su"].Value = (int)chbSu.CheckState;
            cmd.Parameters.Add("@YolaYakin", OleDbType.VarChar);
            cmd.Parameters["@YolaYakin"].Direction = ParameterDirection.Input;
            cmd.Parameters["@YolaYakin"].Value = (int)chbYolaYakin.CheckState;
            cmd.Parameters.Add("@DogaManzarali", OleDbType.VarChar);
            cmd.Parameters["@DogaManzarali"].Direction = ParameterDirection.Input;
            cmd.Parameters["@DogaManzarali"].Value = (int)chbDogaManzarali.CheckState;
            cmd.Parameters.Add("@GolManzarali", OleDbType.VarChar);
            cmd.Parameters["@GolManzarali"].Direction = ParameterDirection.Input;
            cmd.Parameters["@GolManzarali"].Value = (int)chbGolManzarali.CheckState;
            cmd.Parameters.Add("@Parselli", OleDbType.VarChar);
            cmd.Parameters["@Parselli"].Direction = ParameterDirection.Input;
            cmd.Parameters["@Parselli"].Value = (int)chbParselli.CheckState;
            cmd.Parameters.Add("@TelefonHatti", OleDbType.VarChar);
            cmd.Parameters["@TelefonHatti"].Direction = ParameterDirection.Input;
            cmd.Parameters["@TelefonHatti"].Value = (int)chbTelefonHatti.CheckState;
            cmd.Parameters.Add("@YoluAcilmis", OleDbType.VarChar);
            cmd.Parameters["@YoluAcilmis"].Direction = ParameterDirection.Input;
            cmd.Parameters["@YoluAcilmis"].Value = (int)chbDenizManzarali.CheckState;
            cmd.Parameters.Add("@Projeli", OleDbType.VarChar);
            cmd.Parameters["@Projeli"].Direction = ParameterDirection.Input;
            cmd.Parameters["@Projeli"].Value = (int)chbProjeli.CheckState;
            cmd.Parameters.Add("@TopluUlasim", OleDbType.VarChar);
            cmd.Parameters["@TopluUlasim"].Direction = ParameterDirection.Input;
            cmd.Parameters["@TopluUlasim"].Value = (int)chbTopluUlasim.CheckState;
            cmd.Parameters.Add("@imarli", OleDbType.VarChar);
            cmd.Parameters["@imarli"].Direction = ParameterDirection.Input;
            cmd.Parameters["@imarli"].Value = (int)chbImarli.CheckState;
            cmd.Parameters.Add("@SanayiElektrigi", OleDbType.VarChar);
            cmd.Parameters["@SanayiElektrigi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@SanayiElektrigi"].Value = (int)chbSanayiElektrigi.CheckState;

            try
            {
                cmd.ExecuteNonQuery();
                cbilanbaslik.Text = "";
                txtAdres.Text = "";
                txtFiyat.Text = "";
                txtMetrekare.Text = "";
                txtTelefon.Text = "";
                cbil.Text = "";
                txtTelefon.Text = "";
                txtKatSayisi.Text = "";
                txtBirimFiyati.Text = "";
                txtIlgiliBelediye.Text = "";
                txtSahip.Text = "";
                pictureBox4.ImageLocation = null;
                chbKatKarsiligi.Checked = false;
                chbDenizManzarali.Checked = false;
                chbElektrikHatti.Checked = false;
                chbKanalizasyon.Checked = false;
                chbSu.Checked = false;
                chbYolaYakin.Checked = false;
                chbDogaManzarali.Checked = false;
                chbGolManzarali.Checked = false;
                chbParselli.Checked = false;
                chbTelefonHatti.Checked = false;
                chbYoluAcilmis.Checked = false;
                chbProjeli.Checked = false;
                chbTopluUlasim.Checked = false;
                chbImarli.Checked = false;
                chbSanayiElektrigi.Checked = false;
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
            cmd.CommandText = "DELETE FROM satilikarsa WHERE ilanbaslik=@ilanbaslik";

            //Parametre
            cmd.Parameters.Add("@ilanbaslik", OleDbType.Char);
            cmd.Parameters["@ilanbaslik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilanbaslik"].Value = cbilanbaslik.Text;
            if (MessageBox.Show("Bu Kaydı silmek istediğinizden emin misiniz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    cbilanbaslik.Text = "";
                    txtAdres.Text = "";
                    txtFiyat.Text = "";
                    txtMetrekare.Text = "";
                    txtTelefon.Text = "";
                    cbil.Text = "";
                    txtTelefon.Text = "";
                    txtKatSayisi.Text = "";
                    txtBirimFiyati.Text = "";
                    txtIlgiliBelediye.Text = "";
                    txtSahip.Text = "";
                    pictureBox4.ImageLocation = null;
                    chbKatKarsiligi.Checked = false;
                    chbDenizManzarali.Checked = false;
                    chbElektrikHatti.Checked = false;
                    chbKanalizasyon.Checked = false;
                    chbSu.Checked = false;
                    chbYolaYakin.Checked = false;
                    chbDogaManzarali.Checked = false;
                    chbGolManzarali.Checked = false;
                    chbParselli.Checked = false;
                    chbTelefonHatti.Checked = false;
                    chbYoluAcilmis.Checked = false;
                    chbProjeli.Checked = false;
                    chbTopluUlasim.Checked = false;
                    chbImarli.Checked = false;
                    chbSanayiElektrigi.Checked = false;
                    pictureBox4.ImageLocation = null;
                    MessageBox.Show("Başarıyla Silindi!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata:" + ex.Message);
                }
            }
            }


            private void btnResim_Click_1(object sender, EventArgs e)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    resimyolu = ofd.FileName;
                    pictureBox4.ImageLocation = resimyolu;
                }
            }

            private void tabPage1_Click(object sender, EventArgs e)
            {

            }

            private void button1_Click(object sender, EventArgs e)
            {
                txtAdres.Text = "";
                txtBirimFiyati.Text = "";
                txtFiyat.Text = "";
                txtIlgiliBelediye.Text = "";
                txtKatSayisi.Text = "";
                txtMetrekare.Text = "";
                txtSahip.Text = "";
                txtTelefon.Text = "";
                cbil.Text = "";
                cbIlce.Text = "";
                chbDenizManzarali.Checked = false;
                chbDogaManzarali.Checked = false;
                chbElektrikHatti.Checked = false;
                chbGolManzarali.Checked = false;
                chbImarli.Checked = false;
                chbKanalizasyon.Checked = false;
                chbKatKarsiligi.Checked = false;
                chbParselli.Checked = false;
                chbProjeli.Checked = false;
                chbSanayiElektrigi.Checked = false;
                chbSu.Checked = false;
                chbTelefonHatti.Checked = false;
                chbTopluUlasim.Checked = false;
                chbYolaYakin.Checked = false;
                chbYoluAcilmis.Checked = false;
                pictureBox4.ImageLocation = null;
            }

            private void pictureBox4_Click(object sender, EventArgs e)
            {

            }
        }
    }
