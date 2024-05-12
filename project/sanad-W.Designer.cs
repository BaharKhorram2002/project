
namespace project
{
    partial class frmsanad_W
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
            this.lbltitlew = new System.Windows.Forms.Label();
            this.cmbcode = new System.Windows.Forms.ComboBox();
            this.lblcodem = new System.Windows.Forms.Label();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.lbltitleMoen = new System.Windows.Forms.Label();
            this.lblcodew = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.rdbdebtor = new System.Windows.Forms.RadioButton();
            this.rdbcreditor = new System.Windows.Forms.RadioButton();
            this.gpbox = new System.Windows.Forms.GroupBox();
            this.cmbTHesabW = new System.Windows.Forms.ComboBox();
            this.lblTHesab = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblrem = new System.Windows.Forms.Label();
            this.lblTrem = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbltitlew
            // 
            this.lbltitlew.AutoSize = true;
            this.lbltitlew.BackColor = System.Drawing.Color.Transparent;
            this.lbltitlew.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbltitlew.Location = new System.Drawing.Point(313, 93);
            this.lbltitlew.Name = "lbltitlew";
            this.lbltitlew.Size = new System.Drawing.Size(27, 38);
            this.lbltitlew.TabIndex = 29;
            this.lbltitlew.Text = "..";
            // 
            // cmbcode
            // 
            this.cmbcode.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbcode.FormattingEnabled = true;
            this.cmbcode.Location = new System.Drawing.Point(604, 101);
            this.cmbcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbcode.MaxLength = 2;
            this.cmbcode.Name = "cmbcode";
            this.cmbcode.Size = new System.Drawing.Size(125, 37);
            this.cmbcode.TabIndex = 1;
            this.cmbcode.SelectedIndexChanged += new System.EventHandler(this.cmbcode_SelectedIndexChanged);
            this.cmbcode.TextUpdate += new System.EventHandler(this.cmbcode_TextUpdate);
            this.cmbcode.TextChanged += new System.EventHandler(this.cmbcode_TextChanged);
            this.cmbcode.Enter += new System.EventHandler(this.cmbcode_Enter);
            this.cmbcode.Leave += new System.EventHandler(this.cmbcode_Leave);
            // 
            // lblcodem
            // 
            this.lblcodem.AutoSize = true;
            this.lblcodem.BackColor = System.Drawing.Color.Transparent;
            this.lblcodem.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblcodem.Location = new System.Drawing.Point(802, 262);
            this.lblcodem.Name = "lblcodem";
            this.lblcodem.Size = new System.Drawing.Size(54, 38);
            this.lblcodem.TabIndex = 23;
            this.lblcodem.Text = "مبلغ";
            // 
            // txtprice
            // 
            this.txtprice.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.txtprice.Location = new System.Drawing.Point(531, 266);
            this.txtprice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(177, 39);
            this.txtprice.TabIndex = 2;
            this.txtprice.TextChanged += new System.EventHandler(this.txtprice_TextChanged);
            // 
            // lbltitleMoen
            // 
            this.lbltitleMoen.AutoSize = true;
            this.lbltitleMoen.BackColor = System.Drawing.Color.Transparent;
            this.lbltitleMoen.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbltitleMoen.Location = new System.Drawing.Point(759, 339);
            this.lbltitleMoen.Name = "lbltitleMoen";
            this.lbltitleMoen.Size = new System.Drawing.Size(97, 38);
            this.lbltitleMoen.TabIndex = 28;
            this.lbltitleMoen.Text = "شرح سند";
            // 
            // lblcodew
            // 
            this.lblcodew.AutoSize = true;
            this.lblcodew.BackColor = System.Drawing.Color.Transparent;
            this.lblcodew.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblcodew.Location = new System.Drawing.Point(787, 93);
            this.lblcodew.Name = "lblcodew";
            this.lblcodew.Size = new System.Drawing.Size(69, 38);
            this.lblcodew.TabIndex = 27;
            this.lblcodew.Text = "کد کل";
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnadd.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnadd.ForeColor = System.Drawing.Color.White;
            this.btnadd.Location = new System.Drawing.Point(228, 645);
            this.btnadd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(617, 74);
            this.btnadd.TabIndex = 6;
            this.btnadd.Text = "افزودن";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtdescription
            // 
            this.txtdescription.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.txtdescription.Location = new System.Drawing.Point(239, 339);
            this.txtdescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdescription.Size = new System.Drawing.Size(490, 106);
            this.txtdescription.TabIndex = 4;
            // 
            // rdbdebtor
            // 
            this.rdbdebtor.AutoSize = true;
            this.rdbdebtor.Location = new System.Drawing.Point(30, 22);
            this.rdbdebtor.Name = "rdbdebtor";
            this.rdbdebtor.Size = new System.Drawing.Size(72, 31);
            this.rdbdebtor.TabIndex = 30;
            this.rdbdebtor.TabStop = true;
            this.rdbdebtor.Text = "بدهکار";
            this.rdbdebtor.UseVisualStyleBackColor = true;
            // 
            // rdbcreditor
            // 
            this.rdbcreditor.AutoSize = true;
            this.rdbcreditor.Location = new System.Drawing.Point(167, 22);
            this.rdbcreditor.Name = "rdbcreditor";
            this.rdbcreditor.Size = new System.Drawing.Size(82, 31);
            this.rdbcreditor.TabIndex = 31;
            this.rdbcreditor.TabStop = true;
            this.rdbcreditor.Text = "بستانکار";
            this.rdbcreditor.UseVisualStyleBackColor = true;
            // 
            // gpbox
            // 
            this.gpbox.BackColor = System.Drawing.Color.Transparent;
            this.gpbox.Controls.Add(this.rdbcreditor);
            this.gpbox.Controls.Add(this.rdbdebtor);
            this.gpbox.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gpbox.Location = new System.Drawing.Point(250, 253);
            this.gpbox.Name = "gpbox";
            this.gpbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gpbox.Size = new System.Drawing.Size(272, 59);
            this.gpbox.TabIndex = 3;
            this.gpbox.TabStop = false;
            this.gpbox.Text = "ماهیت:";
            // 
            // cmbTHesabW
            // 
            this.cmbTHesabW.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold);
            this.cmbTHesabW.FormattingEnabled = true;
            this.cmbTHesabW.Location = new System.Drawing.Point(588, 476);
            this.cmbTHesabW.MaxLength = 2;
            this.cmbTHesabW.Name = "cmbTHesabW";
            this.cmbTHesabW.Size = new System.Drawing.Size(93, 37);
            this.cmbTHesabW.TabIndex = 5;
            this.cmbTHesabW.SelectedIndexChanged += new System.EventHandler(this.cmbTHesabW_SelectedIndexChanged);
            this.cmbTHesabW.TextUpdate += new System.EventHandler(this.cmbTHesabW_TextUpdate);
            this.cmbTHesabW.TextChanged += new System.EventHandler(this.cmbTHesabW_TextChanged);
            this.cmbTHesabW.Enter += new System.EventHandler(this.cmbTHesabW_Enter);
            this.cmbTHesabW.Leave += new System.EventHandler(this.cmbTHesabW_Leave);
            // 
            // lblTHesab
            // 
            this.lblTHesab.AutoSize = true;
            this.lblTHesab.BackColor = System.Drawing.Color.Transparent;
            this.lblTHesab.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTHesab.Location = new System.Drawing.Point(700, 474);
            this.lblTHesab.Name = "lblTHesab";
            this.lblTHesab.Size = new System.Drawing.Size(145, 38);
            this.lblTHesab.TabIndex = 60;
            this.lblTHesab.Text = "کد طرف حساب";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(787, 570);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 38);
            this.label1.TabIndex = 63;
            this.label1.Text = "مانده";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(798, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 38);
            this.label2.TabIndex = 64;
            this.label2.Text = "مانده";
            // 
            // lblrem
            // 
            this.lblrem.AutoSize = true;
            this.lblrem.BackColor = System.Drawing.Color.Transparent;
            this.lblrem.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblrem.Location = new System.Drawing.Point(490, 197);
            this.lblrem.Name = "lblrem";
            this.lblrem.Size = new System.Drawing.Size(53, 38);
            this.lblrem.TabIndex = 65;
            this.lblrem.Text = "---";
            // 
            // lblTrem
            // 
            this.lblTrem.AutoSize = true;
            this.lblTrem.BackColor = System.Drawing.Color.Transparent;
            this.lblTrem.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTrem.Location = new System.Drawing.Point(490, 570);
            this.lblTrem.Name = "lblTrem";
            this.lblTrem.Size = new System.Drawing.Size(53, 38);
            this.lblTrem.TabIndex = 66;
            this.lblTrem.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(550, 512);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 26);
            this.label3.TabIndex = 67;
            this.label3.Text = "کد نباید بیش از دو رقم باشد";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(571, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 26);
            this.label4.TabIndex = 68;
            this.label4.Text = "کد نباید بیش از دو رقم باشد";
            // 
            // frmsanad_W
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::project.Properties.Resources.photocollage_202382014591245;
            this.ClientSize = new System.Drawing.Size(1182, 953);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTrem);
            this.Controls.Add(this.lblrem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTHesabW);
            this.Controls.Add(this.lblTHesab);
            this.Controls.Add(this.gpbox);
            this.Controls.Add(this.lbltitlew);
            this.Controls.Add(this.cmbcode);
            this.Controls.Add(this.lblcodem);
            this.Controls.Add(this.txtprice);
            this.Controls.Add(this.lbltitleMoen);
            this.Controls.Add(this.lblcodew);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtdescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmsanad_W";
            this.Text = "ثبت سند کل";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmsanad_W_Load);
            this.gpbox.ResumeLayout(false);
            this.gpbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltitlew;
        private System.Windows.Forms.ComboBox cmbcode;
        private System.Windows.Forms.Label lblcodem;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.Label lbltitleMoen;
        private System.Windows.Forms.Label lblcodew;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.RadioButton rdbdebtor;
        private System.Windows.Forms.RadioButton rdbcreditor;
        private System.Windows.Forms.GroupBox gpbox;
        private System.Windows.Forms.ComboBox cmbTHesabW;
        private System.Windows.Forms.Label lblTHesab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblrem;
        private System.Windows.Forms.Label lblTrem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}