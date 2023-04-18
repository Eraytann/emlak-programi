namespace Emlak_Programı
{
    partial class ara
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ara));
            this.rbtnKiralikKonut = new System.Windows.Forms.RadioButton();
            this.rbtnSatilikKonut = new System.Windows.Forms.RadioButton();
            this.btnAra = new System.Windows.Forms.Button();
            this.cbIsitma = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbEmlakTipi = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // rbtnKiralikKonut
            // 
            this.rbtnKiralikKonut.AutoSize = true;
            this.rbtnKiralikKonut.Location = new System.Drawing.Point(458, 37);
            this.rbtnKiralikKonut.Name = "rbtnKiralikKonut";
            this.rbtnKiralikKonut.Size = new System.Drawing.Size(84, 17);
            this.rbtnKiralikKonut.TabIndex = 43;
            this.rbtnKiralikKonut.Text = "Kiralık Konut";
            this.rbtnKiralikKonut.UseVisualStyleBackColor = true;
            // 
            // rbtnSatilikKonut
            // 
            this.rbtnSatilikKonut.AutoSize = true;
            this.rbtnSatilikKonut.Checked = true;
            this.rbtnSatilikKonut.Location = new System.Drawing.Point(322, 37);
            this.rbtnSatilikKonut.Name = "rbtnSatilikKonut";
            this.rbtnSatilikKonut.Size = new System.Drawing.Size(84, 17);
            this.rbtnSatilikKonut.TabIndex = 42;
            this.rbtnSatilikKonut.TabStop = true;
            this.rbtnSatilikKonut.Text = "Satılık Konut";
            this.rbtnSatilikKonut.UseVisualStyleBackColor = true;
            // 
            // btnAra
            // 
            this.btnAra.Image = ((System.Drawing.Image)(resources.GetObject("btnAra.Image")));
            this.btnAra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAra.Location = new System.Drawing.Point(611, 28);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(88, 39);
            this.btnAra.TabIndex = 34;
            this.btnAra.Text = "Ara";
            this.btnAra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAra.UseVisualStyleBackColor = true;
            // 
            // cbIsitma
            // 
            this.cbIsitma.DropDownHeight = 165;
            this.cbIsitma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsitma.DropDownWidth = 185;
            this.cbIsitma.FormattingEnabled = true;
            this.cbIsitma.IntegralHeight = false;
            this.cbIsitma.Items.AddRange(new object[] {
            "Klima",
            "Merkezi Sistem",
            "Güneş Enerjisi",
            "Kombi (Elektrikli)",
            "Isıtma Sistemi Yok",
            "Jeotermal",
            "Kalorifer (Akaryakıt)",
            "Kalorifer (Doğalgaz)",
            "Kalorifer (Kömür)",
            "Kat Kaloriferi (Akaryakıt)",
            "Kombi (Doğalgaz)",
            "Soba (Doğalgaz)",
            "Soba (Kömür)",
            "Yerden Isıtma"});
            this.cbIsitma.Location = new System.Drawing.Point(154, 51);
            this.cbIsitma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbIsitma.Name = "cbIsitma";
            this.cbIsitma.Size = new System.Drawing.Size(153, 21);
            this.cbIsitma.TabIndex = 33;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 32;
            this.label15.Text = "Isıtma:";
            // 
            // cbEmlakTipi
            // 
            this.cbEmlakTipi.DropDownHeight = 212;
            this.cbEmlakTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmlakTipi.DropDownWidth = 165;
            this.cbEmlakTipi.FormattingEnabled = true;
            this.cbEmlakTipi.IntegralHeight = false;
            this.cbEmlakTipi.Items.AddRange(new object[] {
            "Ahşap Ev",
            "Apartman",
            "Apartman Dairesi",
            "Çiftlik Evi",
            "Dağ Evi",
            "Daire (Bahçe Dublex)",
            "Daire (Çatı Dublex)",
            "Dublex",
            "Fourlex",
            "İkiz Ev",
            "Köşk",
            "Köy Evi",
            "Malikane",
            "Müstakil Ev",
            "Residence",
            "Stüdyo",
            "Townhouse",
            "Triplex",
            "Villa",
            "Yalı",
            "Taş Ev",
            "Apart"});
            this.cbEmlakTipi.Location = new System.Drawing.Point(154, 16);
            this.cbEmlakTipi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbEmlakTipi.Name = "cbEmlakTipi";
            this.cbEmlakTipi.Size = new System.Drawing.Size(153, 21);
            this.cbEmlakTipi.TabIndex = 29;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 19);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 13);
            this.label19.TabIndex = 28;
            this.label19.Text = "Emlak Tipi:";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgv.Location = new System.Drawing.Point(0, 110);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(730, 219);
            this.dgv.TabIndex = 27;
            // 
            // ara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 329);
            this.Controls.Add(this.rbtnKiralikKonut);
            this.Controls.Add(this.rbtnSatilikKonut);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.cbIsitma);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cbEmlakTipi);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.dgv);
            this.Name = "ara";
            this.Text = "ara";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnKiralikKonut;
        private System.Windows.Forms.RadioButton rbtnSatilikKonut;
        private System.Windows.Forms.Button btnAra;
        private System.Windows.Forms.ComboBox cbIsitma;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbEmlakTipi;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dgv;
    }
}