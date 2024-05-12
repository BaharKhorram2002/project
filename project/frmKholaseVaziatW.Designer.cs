
namespace project
{
    partial class frmKholaseVaziatW
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
            this.btnclear = new System.Windows.Forms.Button();
            this.btnshow = new System.Windows.Forms.Button();
            this.datagridview = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtboxTyear = new System.Windows.Forms.TextBox();
            this.txtboxTmonth = new System.Windows.Forms.TextBox();
            this.txtboxTday = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtboxFyear = new System.Windows.Forms.TextBox();
            this.txtboxFmonth = new System.Windows.Forms.TextBox();
            this.txtboxFday = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btndateClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnclear.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnclear.Location = new System.Drawing.Point(186, 198);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(236, 61);
            this.btnclear.TabIndex = 8;
            this.btnclear.Text = "پاک کردن جدول گزارش";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnshow
            // 
            this.btnshow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnshow.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnshow.Location = new System.Drawing.Point(762, 198);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(286, 61);
            this.btnshow.TabIndex = 7;
            this.btnshow.Text = "نمایش گزارش";
            this.btnshow.UseVisualStyleBackColor = false;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // datagridview
            // 
            this.datagridview.AllowUserToAddRows = false;
            this.datagridview.AllowUserToDeleteRows = false;
            this.datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview.Location = new System.Drawing.Point(84, 317);
            this.datagridview.Name = "datagridview";
            this.datagridview.ReadOnly = true;
            this.datagridview.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datagridview.RowHeadersWidth = 51;
            this.datagridview.RowTemplate.Height = 24;
            this.datagridview.Size = new System.Drawing.Size(964, 329);
            this.datagridview.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(617, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 24);
            this.label8.TabIndex = 62;
            this.label8.Text = "/";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(664, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 24);
            this.label9.TabIndex = 61;
            this.label9.Text = "/";
            // 
            // txtboxTyear
            // 
            this.txtboxTyear.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtboxTyear.Location = new System.Drawing.Point(556, 104);
            this.txtboxTyear.MaxLength = 4;
            this.txtboxTyear.Name = "txtboxTyear";
            this.txtboxTyear.Size = new System.Drawing.Size(55, 36);
            this.txtboxTyear.TabIndex = 6;
            this.txtboxTyear.TextChanged += new System.EventHandler(this.txtboxTyear_TextChanged);
            this.txtboxTyear.Leave += new System.EventHandler(this.txtboxTyear_Leave);
            // 
            // txtboxTmonth
            // 
            this.txtboxTmonth.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtboxTmonth.Location = new System.Drawing.Point(636, 104);
            this.txtboxTmonth.MaxLength = 2;
            this.txtboxTmonth.Name = "txtboxTmonth";
            this.txtboxTmonth.Size = new System.Drawing.Size(24, 36);
            this.txtboxTmonth.TabIndex = 5;
            this.txtboxTmonth.TextChanged += new System.EventHandler(this.txtboxTmonth_TextChanged);
            this.txtboxTmonth.Leave += new System.EventHandler(this.txtboxTmonth_Leave);
            // 
            // txtboxTday
            // 
            this.txtboxTday.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtboxTday.Location = new System.Drawing.Point(680, 104);
            this.txtboxTday.MaxLength = 2;
            this.txtboxTday.Name = "txtboxTday";
            this.txtboxTday.Size = new System.Drawing.Size(24, 36);
            this.txtboxTday.TabIndex = 4;
            this.txtboxTday.TextChanged += new System.EventHandler(this.txtboxTday_TextChanged);
            this.txtboxTday.Leave += new System.EventHandler(this.txtboxTday_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(917, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 24);
            this.label7.TabIndex = 57;
            this.label7.Text = "/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(960, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 24);
            this.label6.TabIndex = 56;
            this.label6.Text = "/";
            // 
            // txtboxFyear
            // 
            this.txtboxFyear.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtboxFyear.Location = new System.Drawing.Point(860, 104);
            this.txtboxFyear.MaxLength = 4;
            this.txtboxFyear.Name = "txtboxFyear";
            this.txtboxFyear.Size = new System.Drawing.Size(55, 36);
            this.txtboxFyear.TabIndex = 3;
            this.txtboxFyear.TextChanged += new System.EventHandler(this.txtboxFyear_TextChanged);
            this.txtboxFyear.Leave += new System.EventHandler(this.txtboxFyear_Leave);
            // 
            // txtboxFmonth
            // 
            this.txtboxFmonth.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtboxFmonth.Location = new System.Drawing.Point(934, 104);
            this.txtboxFmonth.MaxLength = 2;
            this.txtboxFmonth.Name = "txtboxFmonth";
            this.txtboxFmonth.Size = new System.Drawing.Size(24, 36);
            this.txtboxFmonth.TabIndex = 2;
            this.txtboxFmonth.TextChanged += new System.EventHandler(this.txtboxFmonth_TextChanged);
            this.txtboxFmonth.Leave += new System.EventHandler(this.txtboxFmonth_Leave);
            // 
            // txtboxFday
            // 
            this.txtboxFday.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtboxFday.Location = new System.Drawing.Point(977, 104);
            this.txtboxFday.MaxLength = 2;
            this.txtboxFday.Name = "txtboxFday";
            this.txtboxFday.Size = new System.Drawing.Size(24, 36);
            this.txtboxFday.TabIndex = 1;
            this.txtboxFday.TextChanged += new System.EventHandler(this.txtboxFday_TextChanged);
            this.txtboxFday.Leave += new System.EventHandler(this.txtboxFday_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(709, 106);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(35, 38);
            this.label5.TabIndex = 52;
            this.label5.Text = "تا:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(1019, 104);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(36, 38);
            this.label4.TabIndex = 51;
            this.label4.Text = "از:";
            // 
            // btndateClear
            // 
            this.btndateClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btndateClear.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btndateClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btndateClear.Location = new System.Drawing.Point(471, 198);
            this.btndateClear.Name = "btndateClear";
            this.btndateClear.Size = new System.Drawing.Size(253, 61);
            this.btndateClear.TabIndex = 96;
            this.btndateClear.Text = "پاک کردن فیلد تاریخ";
            this.btndateClear.UseVisualStyleBackColor = false;
            this.btndateClear.Click += new System.EventHandler(this.btndateClear_Click);
            // 
            // frmKholaseVaziatW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::project.Properties.Resources.photocollage_202382014591245;
            this.ClientSize = new System.Drawing.Size(1182, 953);
            this.ControlBox = false;
            this.Controls.Add(this.btndateClear);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnshow);
            this.Controls.Add(this.datagridview);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtboxTyear);
            this.Controls.Add(this.txtboxTmonth);
            this.Controls.Add(this.txtboxTday);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtboxFyear);
            this.Controls.Add(this.txtboxFmonth);
            this.Controls.Add(this.txtboxFday);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKholaseVaziatW";
            this.Text = "خلاصه وضعیت کل";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.DataGridView datagridview;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtboxTyear;
        private System.Windows.Forms.TextBox txtboxTmonth;
        private System.Windows.Forms.TextBox txtboxTday;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtboxFyear;
        private System.Windows.Forms.TextBox txtboxFmonth;
        private System.Windows.Forms.TextBox txtboxFday;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btndateClear;
    }
}