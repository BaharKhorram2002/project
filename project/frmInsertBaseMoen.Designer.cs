
namespace project
{
    partial class frmInsertBaseMoen
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
            this.lbltitleMoen = new System.Windows.Forms.Label();
            this.lblcodew = new System.Windows.Forms.Label();
            this.btnadd = new System.Windows.Forms.Button();
            this.txttitlem = new System.Windows.Forms.TextBox();
            this.txtcodemoen = new System.Windows.Forms.TextBox();
            this.lblcodem = new System.Windows.Forms.Label();
            this.cmbcode = new System.Windows.Forms.ComboBox();
            this.lbltitlew = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbltitleMoen
            // 
            this.lbltitleMoen.AutoSize = true;
            this.lbltitleMoen.BackColor = System.Drawing.Color.Transparent;
            this.lbltitleMoen.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbltitleMoen.Location = new System.Drawing.Point(701, 357);
            this.lbltitleMoen.Name = "lbltitleMoen";
            this.lbltitleMoen.Size = new System.Drawing.Size(113, 38);
            this.lbltitleMoen.TabIndex = 18;
            this.lbltitleMoen.Text = "عنوان معین";
            // 
            // lblcodew
            // 
            this.lblcodew.AutoSize = true;
            this.lblcodew.BackColor = System.Drawing.Color.Transparent;
            this.lblcodew.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblcodew.Location = new System.Drawing.Point(745, 141);
            this.lblcodew.Name = "lblcodew";
            this.lblcodew.Size = new System.Drawing.Size(69, 38);
            this.lblcodew.TabIndex = 17;
            this.lblcodew.Text = "کد کل";
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(90)))));
            this.btnadd.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnadd.Location = new System.Drawing.Point(294, 508);
            this.btnadd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(520, 74);
            this.btnadd.TabIndex = 4;
            this.btnadd.Text = "افزودن";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            this.btnadd.Enter += new System.EventHandler(this.btnadd_Enter);
            // 
            // txttitlem
            // 
            this.txttitlem.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.txttitlem.Location = new System.Drawing.Point(384, 357);
            this.txttitlem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttitlem.Name = "txttitlem";
            this.txttitlem.Size = new System.Drawing.Size(279, 39);
            this.txttitlem.TabIndex = 3;
            this.txttitlem.TextChanged += new System.EventHandler(this.txttitlem_TextChanged);
            this.txttitlem.Enter += new System.EventHandler(this.txttitlem_Enter);
            this.txttitlem.Leave += new System.EventHandler(this.txttitlem_Leave);
            // 
            // txtcodemoen
            // 
            this.txtcodemoen.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.txtcodemoen.Location = new System.Drawing.Point(485, 247);
            this.txtcodemoen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcodemoen.Name = "txtcodemoen";
            this.txtcodemoen.Size = new System.Drawing.Size(177, 39);
            this.txtcodemoen.TabIndex = 2;
            this.txtcodemoen.TextChanged += new System.EventHandler(this.txtcodemoen_TextChanged);
            this.txtcodemoen.Enter += new System.EventHandler(this.txtcodemoen_Enter);
            this.txtcodemoen.Leave += new System.EventHandler(this.txtcodemoen_Leave);
            // 
            // lblcodem
            // 
            this.lblcodem.AutoSize = true;
            this.lblcodem.BackColor = System.Drawing.Color.Transparent;
            this.lblcodem.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblcodem.Location = new System.Drawing.Point(729, 249);
            this.lblcodem.Name = "lblcodem";
            this.lblcodem.Size = new System.Drawing.Size(85, 38);
            this.lblcodem.TabIndex = 2;
            this.lblcodem.Text = "کد معین";
            // 
            // cmbcode
            // 
            this.cmbcode.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbcode.FormattingEnabled = true;
            this.cmbcode.Location = new System.Drawing.Point(537, 147);
            this.cmbcode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbcode.MaxLength = 2;
            this.cmbcode.Name = "cmbcode";
            this.cmbcode.Size = new System.Drawing.Size(125, 37);
            this.cmbcode.TabIndex = 1;
            this.cmbcode.SelectedIndexChanged += new System.EventHandler(this.cmbcode_SelectedIndexChanged);
            this.cmbcode.TextUpdate += new System.EventHandler(this.cmbcode_TextUpdate);
            this.cmbcode.Enter += new System.EventHandler(this.cmbcode_Enter);
            this.cmbcode.Leave += new System.EventHandler(this.cmbcode_Leave);
            // 
            // lbltitlew
            // 
            this.lbltitlew.AutoSize = true;
            this.lbltitlew.BackColor = System.Drawing.Color.Transparent;
            this.lbltitlew.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbltitlew.Location = new System.Drawing.Point(337, 135);
            this.lbltitlew.Name = "lbltitlew";
            this.lbltitlew.Size = new System.Drawing.Size(27, 38);
            this.lbltitlew.TabIndex = 20;
            this.lbltitlew.Text = "..";
            // 
            // frmInsertBaseMoen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::project.Properties.Resources.photocollage_202382014591245;
            this.ClientSize = new System.Drawing.Size(1182, 953);
            this.ControlBox = false;
            this.Controls.Add(this.lbltitlew);
            this.Controls.Add(this.cmbcode);
            this.Controls.Add(this.lblcodem);
            this.Controls.Add(this.txtcodemoen);
            this.Controls.Add(this.lbltitleMoen);
            this.Controls.Add(this.lblcodew);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txttitlem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInsertBaseMoen";
            this.Text = "ورود اطلاعات پایه معین";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbltitleMoen;
        private System.Windows.Forms.Label lblcodew;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.TextBox txttitlem;
        private System.Windows.Forms.TextBox txtcodemoen;
        private System.Windows.Forms.Label lblcodem;
        private System.Windows.Forms.ComboBox cmbcode;
        private System.Windows.Forms.Label lbltitlew;
    }
}