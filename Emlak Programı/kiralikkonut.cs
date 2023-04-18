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
    public partial class kiralikkonut : Form
    {
        public kiralikkonut()
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
            cmd.CommandText = "INSERT INTO kiralikkonut(ilanbaslik,Kira,emlaktipi,mkare,isitma,katsayisi,balkonsayisi,bulundugukat,il,ilce,eklenmetarihi,mulksahibi,banyosayisi,adres,alarm,odasalon,beyazesya,gunesenerjisi,uydu,otopark,guvenlik,garaj,yanginmerdiveni,asansor,diyafon,kapici,panjur,teras,esyali,jenerator,resim) Values(@ilanbaslik,@Kira,@emlaktipi,@mkare,@isitma,@katsayisi,@balkonsayisi,@bulundugukat,@il,@ilce,@eklenmetarihi,@mulksahibi,@banyosayisi,@adres,@alarm,@odasalon,@beyazesya,@gunesenerjisi,@uydu,@otopark,@guvenlik,@garaj,@yanginmerdiveni,@asansor,@diyafon,@kapici,@panjur,@teras,@esyali,@jenerator,@resim)";

            //Parametreleri Oluştur
            cmd.Parameters.Add("@ilanbaslik", OleDbType.VarChar);
            cmd.Parameters["@ilanbaslik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilanbaslik"].Value = cbIlanBasligi.Text;
            cmd.Parameters.Add("@Kira", OleDbType.VarChar);
            cmd.Parameters["@Kira"].Direction = ParameterDirection.Input;
            cmd.Parameters["@Kira"].Value = txtKira.Text;
            cmd.Parameters.Add("@emlaktipi", OleDbType.VarChar);
            cmd.Parameters["@emlaktipi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@emlaktipi"].Value = cbEmlakTipi.Text;
            cmd.Parameters.Add("@mkare", OleDbType.VarChar);
            cmd.Parameters["@mkare"].Direction = ParameterDirection.Input;
            cmd.Parameters["@mkare"].Value = txtMetrekare.Text;
            cmd.Parameters.Add("@isitma", OleDbType.VarChar);
            cmd.Parameters["@isitma"].Direction = ParameterDirection.Input;
            cmd.Parameters["@isitma"].Value = cbIsitma.Text;
            cmd.Parameters.Add("@odasalon", OleDbType.VarChar);
            cmd.Parameters["@odasalon"].Direction = ParameterDirection.Input;
            cmd.Parameters["@odasalon"].Value = cbOdaSalon.Text;
            cmd.Parameters.Add("@katsayisi", OleDbType.VarChar);
            cmd.Parameters["@katsayisi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@katsayisi"].Value = cbBinadakiKatSayisi.Text;
            cmd.Parameters.Add("@bulundugukat", OleDbType.VarChar);
            cmd.Parameters["@bulundugukat"].Direction = ParameterDirection.Input;
            cmd.Parameters["@bulundugukat"].Value = cbBulunduguKat.Text;
            cmd.Parameters.Add("@il", OleDbType.VarChar);
            cmd.Parameters["@il"].Direction = ParameterDirection.Input;
            cmd.Parameters["@il"].Value = cbil.Text;
            cmd.Parameters.Add("@ilce", OleDbType.VarChar);
            cmd.Parameters["@ilce"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilce"].Value = cbIlce.Text;
            cmd.Parameters.Add("@eklenmetarihi", OleDbType.VarChar);
            cmd.Parameters["@eklenmetarihi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@eklenmetarihi"].Value = dtpTarih.Text;
            cmd.Parameters.Add("@mulksahibi", OleDbType.VarChar);
            cmd.Parameters["@mulksahibi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@mulksahibi"].Value = txtSahip.Text;
            cmd.Parameters.Add("@banyosayisi", OleDbType.VarChar);
            cmd.Parameters["@banyosayisi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@banyosayisi"].Value = cBanyosayisi.Text;
            cmd.Parameters.Add("@adres", OleDbType.VarChar);
            cmd.Parameters["@adres"].Direction = ParameterDirection.Input;
            cmd.Parameters["@adres"].Value = txtAdres.Text;
            cmd.Parameters.Add("@alarm", OleDbType.Integer);
            cmd.Parameters["@alarm"].Direction = ParameterDirection.Input;
            cmd.Parameters["@alarm"].Value = (int)chbAlarm.CheckState;
            cmd.Parameters.Add("@balkonsayisi", OleDbType.VarChar);
            cmd.Parameters["@balkonsayisi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@balkonsayisi"].Value = cbBalkonSayisi.Text;
            cmd.Parameters.Add("@beyazesya", OleDbType.VarChar);
            cmd.Parameters["@beyazesya"].Direction = ParameterDirection.Input;
            cmd.Parameters["@beyazesya"].Value = (int)chbBeyazEsya.CheckState; ;
            cmd.Parameters.Add("@gunesenerjisi", OleDbType.VarChar);
            cmd.Parameters["@gunesenerjisi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@gunesenerjisi"].Value = (int)chbGunesEnerjisi.CheckState;
            cmd.Parameters.Add("@uydu", OleDbType.VarChar);
            cmd.Parameters["@uydu"].Direction = ParameterDirection.Input;
            cmd.Parameters["@uydu"].Value = (int)chbKabloTVUydu.CheckState; ;
            cmd.Parameters.Add("@otopark", OleDbType.VarChar);
            cmd.Parameters["@otopark"].Direction = ParameterDirection.Input;
            cmd.Parameters["@otopark"].Value = (int)chbOtopark.CheckState;
            cmd.Parameters.Add("@guvenlik", OleDbType.VarChar);
            cmd.Parameters["@guvenlik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@guvenlik"].Value = (int)chbGuvenlik.CheckState;
            cmd.Parameters.Add("@garaj", OleDbType.VarChar);
            cmd.Parameters["@garaj"].Direction = ParameterDirection.Input;
            cmd.Parameters["@garaj"].Value = (int)chbKapaliGaraj.CheckState;
            cmd.Parameters.Add("@yanginmerdiveni", OleDbType.VarChar);
            cmd.Parameters["@yanginmerdiveni"].Direction = ParameterDirection.Input;
            cmd.Parameters["@yanginmerdiveni"].Value = (int)chbYanginMerdiveni.CheckState;
            cmd.Parameters.Add("@asansor", OleDbType.VarChar);
            cmd.Parameters["@asansor"].Direction = ParameterDirection.Input;
            cmd.Parameters["@asansor"].Value = (int)chbAsansor.CheckState;
            cmd.Parameters.Add("@diyafon", OleDbType.VarChar);
            cmd.Parameters["@diyafon"].Direction = ParameterDirection.Input;
            cmd.Parameters["@diyafon"].Value = (int)chbGoruntuluDiyafon.CheckState;
            cmd.Parameters.Add("@kapici", OleDbType.VarChar);
            cmd.Parameters["@kapici"].Direction = ParameterDirection.Input;
            cmd.Parameters["@kapici"].Value = (int)chbKapici.CheckState;
            cmd.Parameters.Add("@panjur", OleDbType.VarChar);
            cmd.Parameters["@panjur"].Direction = ParameterDirection.Input;
            cmd.Parameters["@panjur"].Value = (int)chbPanjur.CheckState;
            cmd.Parameters.Add("@teras", OleDbType.VarChar);
            cmd.Parameters["@teras"].Direction = ParameterDirection.Input;
            cmd.Parameters["@teras"].Value = (int)chbTerasVeranda.CheckState;
            cmd.Parameters.Add("@esyali", OleDbType.VarChar);
            cmd.Parameters["@esyali"].Direction = ParameterDirection.Input;
            cmd.Parameters["@esyali"].Value = (int)chbEsyali.CheckState;
            cmd.Parameters.Add("@jenerator", OleDbType.VarChar);
            cmd.Parameters["@jenerator"].Direction = ParameterDirection.Input;
            cmd.Parameters["@jenerator"].Value = (int)chbJenerator.CheckState;
            cmd.Parameters.Add("@resim", OleDbType.VarChar);
            cmd.Parameters["@resim"].Direction = ParameterDirection.Input;
            cmd.Parameters["@resim"].Value = resimyolu;

            try
            {
                cmd.ExecuteNonQuery();
                cbIlanBasligi.Text = "";
                txtAdres.Text = "";
                txtKira.Text = "";
                txtMetrekare.Text = "";
                txtSahip.Text = "";
                txtTelefon.Text = "";
                cBanyosayisi.Text = "";
                cbBalkonSayisi.Text = "";
                cbBinadakiKatSayisi.Text = "";
                cbBulunduguKat.Text = "";
                cbEmlakTipi.Text = "";
                cbil.Text = "";
                cbIlce.Text = "";
                cbIsitma.Text = "";
                cbOdaSalon.Text = "";
                chbAlarm.Checked = false;
                chbAsansor.Checked = false;
                chbBeyazEsya.Checked = false;
                chbEsyali.Checked = false;
                chbGoruntuluDiyafon.Checked = false;
                chbGunesEnerjisi.Checked = false;
                chbGuvenlik.Checked = false;
                chbJenerator.Checked = false;
                chbKabloTVUydu.Checked = false;
                chbKapaliGaraj.Checked = false;
                chbKapici.Checked = false;
                chbOtopark.Checked = false;
                chbPanjur.Checked = false;
                chbTerasVeranda.Checked = false;
                chbYanginMerdiveni.Checked = false;
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

        private void kiralikkonut_Load(object sender, EventArgs e)
        {
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ToString();
            dtpTarih.MinDate = DateTime.Now.Date;
            ilEkle();
            con.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ilanbaslik FROM kiralikkonut";

            OleDbDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                cbIlanBasligi.Items.Add(dr["ilanbaslik"].ToString());
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

        private void cbIlanBasligi_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ConnectionString;
            con.Open();

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.CommandText = "SELECT * FROM kiralikkonut WHERE ilanbaslik=@ilanbaslik";
            cmd.Parameters.Add("@ilanbaslik", OleDbType.Char);
            cmd.Parameters["@ilanbaslik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilanbaslik"].Value = cbIlanBasligi.Text;

            OleDbDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                txtKira.Text = dr["kira"].ToString();
                cbEmlakTipi.Text = dr["emlaktipi"].ToString();
                txtMetrekare.Text = dr["mkare"].ToString();
                cbIsitma.Text = dr["isitma"].ToString();
                cbBinadakiKatSayisi.Text = dr["katsayisi"].ToString();
                cbBulunduguKat.Text = dr["bulundugukat"].ToString();
                cbil.Text = dr["il"].ToString();
                cbOdaSalon.Text = dr["odasalon"].ToString();
                cbIlce.Text = dr["ilce"].ToString();
                dtpTarih.Text = dr["eklenmetarihi"].ToString();
                txtSahip.Text = dr["mulksahibi"].ToString();
                cbBalkonSayisi.Text = dr["balkonsayisi"].ToString();
                cBanyosayisi.Text = dr["banyosayisi"].ToString();
                txtAdres.Text = dr["adres"].ToString();
                chbAlarm.Checked = Convert.ToBoolean(dr["Alarm"].ToString());
                chbAsansor.Checked = Convert.ToBoolean(dr["asansor"].ToString());
                chbBeyazEsya.Checked = Convert.ToBoolean(dr["Beyazesya"].ToString());
                chbEsyali.Checked = Convert.ToBoolean(dr["esyali"].ToString());
                chbGoruntuluDiyafon.Checked = Convert.ToBoolean(dr["diyafon"].ToString());
                chbGunesEnerjisi.Checked = Convert.ToBoolean(dr["gunesenerjisi"].ToString());
                chbGuvenlik.Checked = Convert.ToBoolean(dr["guvenlik"].ToString());
                chbJenerator.Checked = Convert.ToBoolean(dr["jenerator"].ToString());
                chbKabloTVUydu.Checked = Convert.ToBoolean(dr["uydu"].ToString());
                chbKapaliGaraj.Checked = Convert.ToBoolean(dr["garaj"].ToString());
                chbKapici.Checked = Convert.ToBoolean(dr["kapici"].ToString());
                chbOtopark.Checked = Convert.ToBoolean(dr["otopark"].ToString());
                chbPanjur.Checked = Convert.ToBoolean(dr["panjur"].ToString());
                chbTerasVeranda.Checked = Convert.ToBoolean(dr["teras"].ToString());
                chbYanginMerdiveni.Checked = Convert.ToBoolean(dr["yanginmerdiveni"].ToString());
                pictureBox4.ImageLocation = dr["resim"].ToString();
            }
            con.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //connection
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["emlakveri"].ConnectionString;
            con.Open();

            //command
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE kiralikkonut SET ilanbaslik=@ilanbaslik,odasalon=@odasalon,kira=@kira,balkonsayisi=@balkonsayisi,emlaktipi=@emlaktipi,mkare=@mkare,isitma=@isitma,katsayisi=@katsayisi,bulundugukat=@bulundugukat,il=@il,ilce=@ilce,eklenmetarihi=@eklenmetarihi,mulksahibi=@mulksahibi,banyosayisi=@banyosayisi,adres=@adres,alarm=@alarm,beyazesya=@beyazesya,gunesenerjisi=@gunesenerjisi,uydu=@uydu,otopark=@otopark,guvenlik=@guvenlik,garaj=@garaj,yanginmerdiveni=@yanginmerdiveni,asansor=@asansor,diyafon=@diyafon,kapici=@kapici,panjur=@panjur,teras=@teras,esyali=@esyali,jenerator=@jenerator,resim=@Resim WHERE ilanbaslik=@ilanbaslik";

            //parametreler
            cmd.Parameters.Add("@ilanbaslik", OleDbType.VarChar);
            cmd.Parameters["@ilanbaslik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilanbaslik"].Value = cbIlanBasligi.Text;
            cmd.Parameters.Add("@Kira", OleDbType.VarChar);
            cmd.Parameters["@Kira"].Direction = ParameterDirection.Input;
            cmd.Parameters["@Kira"].Value = txtKira.Text;
            cmd.Parameters.Add("@emlaktipi", OleDbType.VarChar);
            cmd.Parameters["@emlaktipi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@emlaktipi"].Value = cbEmlakTipi.Text;
            cmd.Parameters.Add("@mkare", OleDbType.VarChar);
            cmd.Parameters["@mkare"].Direction = ParameterDirection.Input;
            cmd.Parameters["@mkare"].Value = txtMetrekare.Text;
            cmd.Parameters.Add("@isitma", OleDbType.VarChar);
            cmd.Parameters["@isitma"].Direction = ParameterDirection.Input;
            cmd.Parameters["@isitma"].Value = cbIsitma.Text;
            cmd.Parameters.Add("@katsayisi", OleDbType.VarChar);
            cmd.Parameters["@katsayisi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@katsayisi"].Value = cbBinadakiKatSayisi.Text;
            cmd.Parameters.Add("@bulundugukat", OleDbType.VarChar);
            cmd.Parameters["@bulundugukat"].Direction = ParameterDirection.Input;
            cmd.Parameters["@bulundugukat"].Value = cbBulunduguKat.Text;
            cmd.Parameters.Add("@il", OleDbType.VarChar);
            cmd.Parameters["@il"].Direction = ParameterDirection.Input;
            cmd.Parameters["@il"].Value = cbil.Text;
            cmd.Parameters.Add("@ilce", OleDbType.VarChar);
            cmd.Parameters["@ilce"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilce"].Value = cbIlce.Text;
            cmd.Parameters.Add("@odasalon", OleDbType.VarChar);
            cmd.Parameters["@odasalon"].Direction = ParameterDirection.Input;
            cmd.Parameters["@odasalon"].Value = cbOdaSalon.Text;
            cmd.Parameters.Add("@balkonsayisi", OleDbType.VarChar);
            cmd.Parameters["@balkonsayisi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@balkonsayisi"].Value = cbBalkonSayisi.Text;
            cmd.Parameters.Add("@eklenmetarihi", OleDbType.VarChar);
            cmd.Parameters["@eklenmetarihi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@eklenmetarihi"].Value = dtpTarih.Text;
            cmd.Parameters["@eklenmetarihi"].Direction = ParameterDirection.Input;
            cmd.Parameters.Add("@mulksahibi", OleDbType.VarChar);
            cmd.Parameters["@mulksahibi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@mulksahibi"].Value = txtSahip.Text;
            cmd.Parameters.Add("@banyosayisi", OleDbType.VarChar);
            cmd.Parameters["@banyosayisi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@banyosayisi"].Value = cBanyosayisi.Text;
            cmd.Parameters.Add("@adres", OleDbType.VarChar);
            cmd.Parameters["@adres"].Direction = ParameterDirection.Input;
            cmd.Parameters["@adres"].Value = txtAdres.Text;
            cmd.Parameters.Add("@alarm", OleDbType.Integer);
            cmd.Parameters["@alarm"].Direction = ParameterDirection.Input;
            cmd.Parameters["@alarm"].Value = (int)chbAlarm.CheckState;
            cmd.Parameters.Add("@beyazesya", OleDbType.VarChar);
            cmd.Parameters["@beyazesya"].Direction = ParameterDirection.Input;
            cmd.Parameters["@beyazesya"].Value = (int)chbBeyazEsya.CheckState; ;
            cmd.Parameters.Add("@gunesenerjisi", OleDbType.VarChar);
            cmd.Parameters["@gunesenerjisi"].Direction = ParameterDirection.Input;
            cmd.Parameters["@gunesenerjisi"].Value = (int)chbGunesEnerjisi.CheckState;
            cmd.Parameters.Add("@uydu", OleDbType.VarChar);
            cmd.Parameters["@uydu"].Direction = ParameterDirection.Input;
            cmd.Parameters["@uydu"].Value = (int)chbKabloTVUydu.CheckState; ;
            cmd.Parameters.Add("@otopark", OleDbType.VarChar);
            cmd.Parameters["@otopark"].Direction = ParameterDirection.Input;
            cmd.Parameters["@otopark"].Value = (int)chbOtopark.CheckState;
            cmd.Parameters.Add("@guvenlik", OleDbType.VarChar);
            cmd.Parameters["@guvenlik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@guvenlik"].Value = (int)chbGuvenlik.CheckState;
            cmd.Parameters.Add("@garaj", OleDbType.VarChar);
            cmd.Parameters["@garaj"].Direction = ParameterDirection.Input;
            cmd.Parameters["@garaj"].Value = (int)chbKapaliGaraj.CheckState;
            cmd.Parameters.Add("@yanginmerdiveni", OleDbType.VarChar);
            cmd.Parameters["@yanginmerdiveni"].Direction = ParameterDirection.Input;
            cmd.Parameters["@yanginmerdiveni"].Value = (int)chbYanginMerdiveni.CheckState;
            cmd.Parameters.Add("@asansor", OleDbType.VarChar);
            cmd.Parameters["@asansor"].Direction = ParameterDirection.Input;
            cmd.Parameters["@asansor"].Value = (int)chbAsansor.CheckState;
            cmd.Parameters.Add("@diyafon", OleDbType.VarChar);
            cmd.Parameters["@diyafon"].Direction = ParameterDirection.Input;
            cmd.Parameters["@diyafon"].Value = (int)chbGoruntuluDiyafon.CheckState;
            cmd.Parameters.Add("@kapici", OleDbType.VarChar);
            cmd.Parameters["@kapici"].Direction = ParameterDirection.Input;
            cmd.Parameters["@kapici"].Value = (int)chbKapici.CheckState;
            cmd.Parameters.Add("@panjur", OleDbType.VarChar);
            cmd.Parameters["@panjur"].Direction = ParameterDirection.Input;
            cmd.Parameters["@panjur"].Value = (int)chbPanjur.CheckState;
            cmd.Parameters.Add("@teras", OleDbType.VarChar);
            cmd.Parameters["@teras"].Direction = ParameterDirection.Input;
            cmd.Parameters["@teras"].Value = (int)chbTerasVeranda.CheckState;
            cmd.Parameters.Add("@esyali", OleDbType.VarChar);
            cmd.Parameters["@esyali"].Direction = ParameterDirection.Input;
            cmd.Parameters["@esyali"].Value = (int)chbEsyali.CheckState;
            cmd.Parameters.Add("@jenerator", OleDbType.VarChar);
            cmd.Parameters["@jenerator"].Direction = ParameterDirection.Input;
            cmd.Parameters["@jenerator"].Value = (int)chbJenerator.CheckState;
            cmd.Parameters.Add("@resim", OleDbType.VarChar);
            cmd.Parameters["@resim"].Direction = ParameterDirection.Input;
            cmd.Parameters["@resim"].Value = resimyolu;

            try
            {
                cmd.ExecuteNonQuery();
                cbIlanBasligi.Text = "";
                cbEmlakTipi.Text = "";
                txtAdres.Text = "";
                txtKira.Text = "";
                txtMetrekare.Text = "";
                txtSahip.Text = "";
                txtTelefon.Text = "";
                cBanyosayisi.Text = "";
                cbBalkonSayisi.Text = "";
                cbBinadakiKatSayisi.Text = "";
                cbBulunduguKat.Text = "";
                cbEmlakTipi.Text = "";
                cbil.Text = "";
                cbIlce.Text = "";
                cbIsitma.Text = "";
                cbOdaSalon.Text = "";
                chbAlarm.Checked = false;
                chbAsansor.Checked = false;
                chbBeyazEsya.Checked = false;
                chbEsyali.Checked = false;
                chbGoruntuluDiyafon.Checked = false;
                chbGunesEnerjisi.Checked = false;
                chbGuvenlik.Checked = false;
                chbJenerator.Checked = false;
                chbKabloTVUydu.Checked = false;
                chbKapaliGaraj.Checked = false;
                chbKapici.Checked = false;
                chbOtopark.Checked = false;
                chbPanjur.Checked = false;
                chbTerasVeranda.Checked = false;
                chbYanginMerdiveni.Checked = false;
                pictureBox4.ImageLocation = null;
                MessageBox.Show("Başarıyla Güncellendi!");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Hata:" + ex.Message);
            }
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
            cmd.CommandText = "DELETE FROM kiralikkonut WHERE ilanbaslik=@ilanbaslik";

            //Parametre
            cmd.Parameters.Add("@ilanbaslik", OleDbType.Char);
            cmd.Parameters["@ilanbaslik"].Direction = ParameterDirection.Input;
            cmd.Parameters["@ilanbaslik"].Value = cbIlanBasligi.Text;
            if (MessageBox.Show("Bu Kaydı silmek istediğinizden emin misiniz?", "Dikkat!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    cmd.ExecuteNonQuery();
                    cbIlanBasligi.Text = "";
                    cbEmlakTipi.Text = "";
                    txtAdres.Text = "";
                    txtKira.Text = "";
                    txtMetrekare.Text = "";
                    txtSahip.Text = "";
                    txtTelefon.Text = "";
                    cBanyosayisi.Text = "";
                    cbBalkonSayisi.Text = "";
                    cbBinadakiKatSayisi.Text = "";
                    cbBulunduguKat.Text = "";
                    cbEmlakTipi.Text = "";
                    cbil.Text = "";
                    cbBalkonSayisi.Text = "";
                    cbIlce.Text = "";
                    cbIsitma.Text = "";
                    cbOdaSalon.Text = "";
                    chbAlarm.Checked = false;
                    chbAsansor.Checked = false;
                    chbBeyazEsya.Checked = false;
                    chbEsyali.Checked = false;
                    chbGoruntuluDiyafon.Checked = false;
                    chbGunesEnerjisi.Checked = false;
                    chbGuvenlik.Checked = false;
                    chbJenerator.Checked = false;
                    chbKabloTVUydu.Checked = false;
                    chbKapaliGaraj.Checked = false;
                    chbKapici.Checked = false;
                    chbOtopark.Checked = false;
                    chbPanjur.Checked = false;
                    chbTerasVeranda.Checked = false;
                    chbYanginMerdiveni.Checked = false;
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
