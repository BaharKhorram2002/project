
namespace project
{
    partial class frminsertbasem
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
            this.txtcodw = new System.Windows.Forms.TextBox();
            this.txttitle = new System.Windows.Forms.TextBox();
            this.rdbhas = new System.Windows.Forms.RadioButton();
            this.rdbdhave = new System.Windows.Forms.RadioButton();
            this.rdbdebtor = new System.Windows.Forms.RadioButton();
            this.rdbcreditor = new System.Windows.Forms.RadioButton();
            this.gpboxmoen = new System.Windows.Forms.GroupBox();
            this.gpboxcd = new System.Windows.Forms.GroupBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.gpboxmoen.SuspendLayout();
            this.gpboxcd.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtcodw
            // 
            this.txtcodw.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.txtcodw.Location = new System.Drawing.Point(399, 90);
            this.txtcodw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtcodw.Name = "txtcodw";
            this.txtcodw.Size = new System.Drawing.Size(95, 39);
            this.txtcodw.TabIndex = 0;
            this.txtcodw.TextChanged += new System.EventHandler(this.txtcodw_TextChanged);
            this.txtcodw.Leave += new System.EventHandler(this.txtcodw_Leave);
            // 
            // txttitle
            // 
            this.txttitle.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold);
            this.txttitle.Location = new System.Drawing.Point(217, 169);
            this.txttitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txttitle.Name = "txttitle";
            this.txttitle.Size = new System.Drawing.Size(279, 39);
            this.txttitle.TabIndex = 1;
            this.txttitle.Enter += new System.EventHandler(this.txttitle_Enter);
            this.txttitle.Leave += new System.EventHandler(this.txttitle_Leave);
            // 
            // rdbhas
            // 
            this.rdbhas.AutoSize = true;
            this.rdbhas.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold);
            this.rdbhas.Location = new System.Drawing.Point(183, 21);
            this.rdbhas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbhas.Name = "rdbhas";
            this.rdbhas.Size = new System.Drawing.Size(61, 34);
            this.rdbhas.TabIndex = 21;
            this.rdbhas.TabStop = true;
            this.rdbhas.Text = "دارد";
            this.rdbhas.UseVisualStyleBackColor = true;
            // 
            // rdbdhave
            // 
            this.rdbdhave.AutoSize = true;
            this.rdbdhave.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold);
            this.rdbdhave.Location = new System.Drawing.Point(35, 21);
            this.rdbdhave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbdhave.Name = "rdbdhave";
            this.rdbdhave.Size = new System.Drawing.Size(67, 34);
            this.rdbdhave.TabIndex = 20;
            this.rdbdhave.TabStop = true;
            this.rdbdhave.Text = "ندارد";
            this.rdbdhave.UseVisualStyleBackColor = true;
            // 
            // rdbdebtor
            // 
            this.rdbdebtor.AutoSize = true;
            this.rdbdebtor.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold);
            this.rdbdebtor.Location = new System.Drawing.Point(169, 18);
            this.rdbdebtor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbdebtor.Name = "rdbdebtor";
            this.rdbdebtor.Size = new System.Drawing.Size(78, 34);
            this.rdbdebtor.TabIndex = 31;
            this.rdbdebtor.TabStop = true;
            this.rdbdebtor.Text = "بدهکار";
            this.rdbdebtor.UseVisualStyleBackColor = true;
            // 
            // rdbcreditor
            // 
            this.rdbcreditor.AutoSize = true;
            this.rdbcreditor.Font = new System.Drawing.Font("B Nazanin", 11F, System.Drawing.FontStyle.Bold);
            this.rdbcreditor.Location = new System.Drawing.Point(16, 18);
            this.rdbcreditor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbcreditor.Name = "rdbcreditor";
            this.rdbcreditor.Size = new System.Drawing.Size(88, 34);
            this.rdbcreditor.TabIndex = 30;
            this.rdbcreditor.TabStop = true;
            this.rdbcreditor.Text = "بستانکار";
            this.rdbcreditor.UseVisualStyleBackColor = true;
            // 
            // gpboxmoen
            // 
            this.gpboxmoen.BackColor = System.Drawing.Color.Transparent;
            this.gpboxmoen.Controls.Add(this.rdbhas);
            this.gpboxmoen.Controls.Add(this.rdbdhave);
            this.gpboxmoen.Location = new System.Drawing.Point(240, 270);
            this.gpboxmoen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpboxmoen.Name = "gpboxmoen";
            this.gpboxmoen.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpboxmoen.Size = new System.Drawing.Size(279, 66);
            this.gpboxmoen.TabIndex = 2;
            this.gpboxmoen.TabStop = false;
            this.gpboxmoen.Enter += new System.EventHandler(this.gpboxmoen_Enter);
            // 
            // gpboxcd
            // 
            this.gpboxcd.BackColor = System.Drawing.Color.Transparent;
            this.gpboxcd.Controls.Add(this.rdbcreditor);
            this.gpboxcd.Controls.Add(this.rdbdebtor);
            this.gpboxcd.Location = new System.Drawing.Point(242, 379);
            this.gpboxcd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpboxcd.Name = "gpboxcd";
            this.gpboxcd.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpboxcd.Size = new System.Drawing.Size(279, 72);
            this.gpboxcd.TabIndex = 3;
            this.gpboxcd.TabStop = false;
            this.gpboxcd.Enter += new System.EventHandler(this.gpboxcd_Enter);
            // 
            // btnadd
            // 
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(90)))));
            this.btnadd.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnadd.Location = new System.Drawing.Point(166, 499);
            this.btnadd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(520, 74);
            this.btnadd.TabIndex = 4;
            this.btnadd.Text = "افزودن";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            this.btnadd.Enter += new System.EventHandler(this.btnadd_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(587, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 38);
            this.label1.TabIndex = 9;
            this.label1.Text = "کد کل";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(550, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 38);
            this.label2.TabIndex = 10;
            this.label2.Text = "وضعیت معین";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(589, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 38);
            this.label3.TabIndex = 10;
            this.label3.Text = "عنوان";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(604, 389);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 38);
            this.label4.TabIndex = 11;
            this.label4.Text = "ماهیت";
            // 
            // frminsertbasem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::project.Properties.Resources.photocollage_202382014591245;
            this.ClientSize = new System.Drawing.Size(1182, 953);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.gpboxcd);
            this.Controls.Add(this.txttitle);
            this.Controls.Add(this.txtcodw);
            this.Controls.Add(this.gpboxmoen);
            this.Font = new System.Drawing.Font("B Nazanin", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frminsertbasem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ورود اطلاعات پایه کل";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gpboxmoen.ResumeLayout(false);
            this.gpboxmoen.PerformLayout();
            this.gpboxcd.ResumeLayout(false);
            this.gpboxcd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtcodw;
        private System.Windows.Forms.TextBox txttitle;
        private System.Windows.Forms.RadioButton rdbhas;
        private System.Windows.Forms.RadioButton rdbdhave;
        private System.Windows.Forms.RadioButton rdbdebtor;
        private System.Windows.Forms.RadioButton rdbcreditor;
        private System.Windows.Forms.GroupBox gpboxmoen;
        private System.Windows.Forms.GroupBox gpboxcd;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}