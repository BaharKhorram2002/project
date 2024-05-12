
namespace project
{
    partial class frmsanad_M
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
            this.lblcodeM = new System.Windows.Forms.Label();
            this.gpbox = new System.Windows.Forms.GroupBox();
            this.rdbcreditor = new System.Windows.Forms.RadioButton();
            this.rdbdebtor = new System.Windows.Forms.RadioButton();
            this.lbltitlew = new System.Windows.Forms.Label();
            this.lblprice = new System.Windows.Forms.Label();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.lbldescription = new System.Windows.Forms.Label();
            this.lblcodew = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.lbltitleM = new System.Windows.Forms.Label();
            this.cmbcodeW = new System.Windows.Forms.ComboBox();
            this.cmbcodeM = new System.Windows.Forms.ComboBox();
            this.lblTHesab = new System.Windows.Forms.Label();
            this.cmbTHesab = new System.Windows.Forms.ComboBox();
            this.cmbTHesabW = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblrem = new System.Windows.Forms.Label();
            this.lblTrem = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gpbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblcodeM
            // 
            this.lblcodeM.AutoSize = true;
            this.lblcodeM.BackColor = System.Drawing.Color.Transparent;
            this.lblcodeM.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblcodeM.Location = new System.Drawing.Point(785, 136);
            this.lblcodeM.Name = "lblcodeM";
            this.lblcodeM.Size = new System.Drawing.Size(85, 38);
            this.lblcodeM.TabIndex = 95;
            this.lblcodeM.Text = "کد معین";
            // 
            // gpbox
            // 
            this.gpbox.BackColor = System.Drawing.Color.Transparent;
            this.gpbox.Controls.Add(this.rdbcreditor);
            this.gpbox.Controls.Add(this.rdbdebtor);
            this.gpbox.Font = new System.Drawing.Font("B Nazanin", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.gpbox.Location = new System.Drawing.Point(253, 268);
            this.gpbox.Name = "gpbox";
            this.gpbox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gpbox.Size = new System.Drawing.Size(272, 59);
            this.gpbox.TabIndex = 4;
            this.gpbox.TabStop = false;
            this.gpbox.Text = "ماهیت:";
            // 
            // rdbcreditor
            // 
            this.rdbcreditor.AutoSize = true;
            this.rdbcreditor.Location = new System.Drawing.Point(167, 22);
            this.rdbcreditor.Name = "rdbcreditor";
            this.rdbcreditor.Size = new System.Drawing.Size(82, 31);
            this.rdbcreditor.TabIndex = 41;
            this.rdbcreditor.TabStop = true;
            this.rdbcreditor.Text = "بستانکار";
            this.rdbcreditor.UseVisualStyleBackColor = true;
            // 
            // rdbdebtor
            // 
            this.rdbdebtor.AutoSize = true;
            this.rdbdebtor.Location = new System.Drawing.Point(30, 22);
            this.rdbdebtor.Name = "rdbdebtor";
            this.rdbdebtor.Size = new System.Drawing.Size(72, 31);
            this.rdbdebtor.TabIndex = 40;
            this.rdbdebtor.TabStop = true;
            this.rdbdebtor.Text = "بدهکار";
            this.rdbdebtor.UseVisualStyleBackColor = true;
            // 
            // lbltitlew
            // 
            this.lbltitlew.AutoSize = true;
            this.lbltitlew.BackColor = System.Drawing.Color.Transparent;
            this.lbltitlew.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbltitlew.Location = new System.Drawing.Point(327, 73);
            this.lbltitlew.Name = "lbltitlew";
            this.lbltitlew.Size = new System.Drawing.Size(27, 38);
            this.lbltitlew.TabIndex = 93;
            this.lbltitlew.Text = "..";
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.BackColor = System.Drawing.Color.Transparent;
            this.lblprice.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblprice.Location = new System.Drawing.Point(801, 279);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(54, 38);
            this.lblprice.TabIndex = 97;
            this.lblprice.Text = "مبلغ";
            // 
            // txtprice
            // 
            this.txtprice.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.txtprice.Location = new System.Drawing.Point(566, 278);
            this.txtprice.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(177, 39);
            this.txtprice.TabIndex = 3;
            this.txtprice.TextChanged += new System.EventHandler(this.txtprice_TextChanged);
            // 
            // lbldescription
            // 
            this.lbldescription.AutoSize = true;
            this.lbldescription.BackColor = System.Drawing.Color.Transparent;
            this.lbldescription.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbldescription.Location = new System.Drawing.Point(773, 362);
            this.lbldescription.Name = "lbldescription";
            this.lbldescription.Size = new System.Drawing.Size(97, 38);
            this.lbldescription.TabIndex = 92;
            this.lbldescription.Text = "شرح سند";
            // 
            // lblcodew
            // 
            this.lblcodew.AutoSize = true;
            this.lblcodew.BackColor = System.Drawing.Color.Transparent;
            this.lblcodew.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblcodew.Location = new System.Drawing.Point(801, 73);
            this.lblcodew.Name = "lblcodew";
            this.lblcodew.Size = new System.Drawing.Size(69, 38);
            this.lblcodew.TabIndex = 91;
            this.lblcodew.Text = "کد کل";
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnadd.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnadd.ForeColor = System.Drawing.SystemColors.Control;
            this.btnadd.Location = new System.Drawing.Point(253, 614);
            this.btnadd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(617, 74);
            this.btnadd.TabIndex = 8;
            this.btnadd.Text = "افزودن";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // txtdescription
            // 
            this.txtdescription.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.txtdescription.Location = new System.Drawing.Point(253, 362);
            this.txtdescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtdescription.Size = new System.Drawing.Size(490, 106);
            this.txtdescription.TabIndex = 5;
            // 
            // lbltitleM
            // 
            this.lbltitleM.AutoSize = true;
            this.lbltitleM.BackColor = System.Drawing.Color.Transparent;
            this.lbltitleM.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbltitleM.Location = new System.Drawing.Point(328, 130);
            this.lbltitleM.Name = "lbltitleM";
            this.lbltitleM.Size = new System.Drawing.Size(27, 38);
            this.lbltitleM.TabIndex = 95;
            this.lbltitleM.Text = "..";
            // 
            // cmbcodeW
            // 
            this.cmbcodeW.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbcodeW.FormattingEnabled = true;
            this.cmbcodeW.Location = new System.Drawing.Point(566, 81);
            this.cmbcodeW.Name = "cmbcodeW";
            this.cmbcodeW.Size = new System.Drawing.Size(177, 37);
            this.cmbcodeW.TabIndex = 1;
            this.cmbcodeW.SelectedIndexChanged += new System.EventHandler(this.cmbcodeW_SelectedIndexChanged);
            this.cmbcodeW.TextUpdate += new System.EventHandler(this.cmbcodeW_TextUpdate);
            this.cmbcodeW.TextChanged += new System.EventHandler(this.cmbcodeW_TextChanged);
            this.cmbcodeW.Enter += new System.EventHandler(this.cmbcodeW_Enter);
            this.cmbcodeW.Leave += new System.EventHandler(this.cmbcodeW_Leave);
            // 
            // cmbcodeM
            // 
            this.cmbcodeM.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbcodeM.FormattingEnabled = true;
            this.cmbcodeM.Location = new System.Drawing.Point(566, 144);
            this.cmbcodeM.Name = "cmbcodeM";
            this.cmbcodeM.Size = new System.Drawing.Size(177, 37);
            this.cmbcodeM.TabIndex = 2;
            this.cmbcodeM.SelectedIndexChanged += new System.EventHandler(this.cmbcodeM_SelectedIndexChanged);
            this.cmbcodeM.TextUpdate += new System.EventHandler(this.cmbcodeM_TextUpdate);
            this.cmbcodeM.TextChanged += new System.EventHandler(this.cmbcodeM_TextChanged);
            this.cmbcodeM.Enter += new System.EventHandler(this.cmbcodeM_Enter);
            this.cmbcodeM.Leave += new System.EventHandler(this.cmbcodeM_Leave);
            // 
            // lblTHesab
            // 
            this.lblTHesab.AutoSize = true;
            this.lblTHesab.BackColor = System.Drawing.Color.Transparent;
            this.lblTHesab.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTHesab.Location = new System.Drawing.Point(725, 492);
            this.lblTHesab.Name = "lblTHesab";
            this.lblTHesab.Size = new System.Drawing.Size(145, 38);
            this.lblTHesab.TabIndex = 96;
            this.lblTHesab.Text = "کد طرف حساب";
            // 
            // cmbTHesab
            // 
            this.cmbTHesab.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbTHesab.FormattingEnabled = true;
            this.cmbTHesab.Location = new System.Drawing.Point(566, 501);
            this.cmbTHesab.Name = "cmbTHesab";
            this.cmbTHesab.Size = new System.Drawing.Size(106, 37);
            this.cmbTHesab.TabIndex = 7;
            this.cmbTHesab.SelectedIndexChanged += new System.EventHandler(this.cmbTHesab_SelectedIndexChanged);
            this.cmbTHesab.TextUpdate += new System.EventHandler(this.cmbTHesab_TextUpdate);
            this.cmbTHesab.TextChanged += new System.EventHandler(this.cmbTHesab_TextChanged);
            this.cmbTHesab.Enter += new System.EventHandler(this.cmbTHesab_Enter);
            this.cmbTHesab.Leave += new System.EventHandler(this.cmbTHesab_Leave);
            // 
            // cmbTHesabW
            // 
            this.cmbTHesabW.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbTHesabW.FormattingEnabled = true;
            this.cmbTHesabW.Location = new System.Drawing.Point(495, 500);
            this.cmbTHesabW.Name = "cmbTHesabW";
            this.cmbTHesabW.Size = new System.Drawing.Size(62, 37);
            this.cmbTHesabW.TabIndex = 6;
            this.cmbTHesabW.TextUpdate += new System.EventHandler(this.cmbTHesabW_TextUpdate);
            this.cmbTHesabW.TextChanged += new System.EventHandler(this.cmbTHesabW_TextChanged);
            this.cmbTHesabW.Enter += new System.EventHandler(this.cmbTHesabW_Enter);
            this.cmbTHesabW.Leave += new System.EventHandler(this.cmbTHesabW_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(801, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 38);
            this.label2.TabIndex = 98;
            this.label2.Text = "مانده";
            // 
            // lblrem
            // 
            this.lblrem.AutoSize = true;
            this.lblrem.BackColor = System.Drawing.Color.Transparent;
            this.lblrem.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblrem.Location = new System.Drawing.Point(525, 206);
            this.lblrem.Name = "lblrem";
            this.lblrem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblrem.Size = new System.Drawing.Size(53, 38);
            this.lblrem.TabIndex = 9;
            this.lblrem.Text = "---";
            // 
            // lblTrem
            // 
            this.lblTrem.AutoSize = true;
            this.lblTrem.BackColor = System.Drawing.Color.Transparent;
            this.lblTrem.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblTrem.Location = new System.Drawing.Point(495, 558);
            this.lblTrem.Name = "lblTrem";
            this.lblTrem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTrem.Size = new System.Drawing.Size(53, 38);
            this.lblTrem.TabIndex = 91;
            this.lblTrem.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(801, 558);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 38);
            this.label3.TabIndex = 90;
            this.label3.Text = "مانده";
            // 
            // frmsanad_M
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::project.Properties.Resources.photocollage_202382014591245;
            this.ClientSize = new System.Drawing.Size(1182, 953);
            this.ControlBox = false;
            this.Controls.Add(this.lblTrem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblrem);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbTHesabW);
            this.Controls.Add(this.cmbTHesab);
            this.Controls.Add(this.lblTHesab);
            this.Controls.Add(this.cmbcodeM);
            this.Controls.Add(this.cmbcodeW);
            this.Controls.Add(this.lbltitleM);
            this.Controls.Add(this.gpbox);
            this.Controls.Add(this.lbltitlew);
            this.Controls.Add(this.lblprice);
            this.Controls.Add(this.txtprice);
            this.Controls.Add(this.lbldescription);
            this.Controls.Add(this.lblcodew);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtdescription);
            this.Controls.Add(this.lblcodeM);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmsanad_M";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ثبت سند معین";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gpbox.ResumeLayout(false);
            this.gpbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblcodeM;
        private System.Windows.Forms.GroupBox gpbox;
        private System.Windows.Forms.RadioButton rdbcreditor;
        private System.Windows.Forms.RadioButton rdbdebtor;
        private System.Windows.Forms.Label lbltitlew;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.Label lbldescription;
        private System.Windows.Forms.Label lblcodew;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label lbltitleM;
        private System.Windows.Forms.ComboBox cmbcodeW;
        private System.Windows.Forms.ComboBox cmbcodeM;
        private System.Windows.Forms.Label lblTHesab;
        private System.Windows.Forms.ComboBox cmbTHesab;
        private System.Windows.Forms.ComboBox cmbTHesabW;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblrem;
        private System.Windows.Forms.Label lblTrem;
        private System.Windows.Forms.Label label3;
    }
}