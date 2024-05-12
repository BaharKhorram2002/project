
namespace project
{
    partial class frmSoratHesabWM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rdbW = new System.Windows.Forms.RadioButton();
            this.rdbM = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbcode = new System.Windows.Forms.ComboBox();
            this.datagridview = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtboxFday = new System.Windows.Forms.TextBox();
            this.txtboxFmonth = new System.Windows.Forms.TextBox();
            this.txtboxFyear = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtboxTyear = new System.Windows.Forms.TextBox();
            this.txtboxTmonth = new System.Windows.Forms.TextBox();
            this.txtboxTday = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbltitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPRemaining = new System.Windows.Forms.Label();
            this.lblFRemaining = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnshow = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.lblfnature = new System.Windows.Forms.Label();
            this.lblpnature = new System.Windows.Forms.Label();
            this.btndateClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbW
            // 
            this.rdbW.AutoSize = true;
            this.rdbW.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rdbW.Location = new System.Drawing.Point(175, 21);
            this.rdbW.Name = "rdbW";
            this.rdbW.Size = new System.Drawing.Size(53, 34);
            this.rdbW.TabIndex = 2;
            this.rdbW.TabStop = true;
            this.rdbW.Text = "کل";
            this.rdbW.UseVisualStyleBackColor = true;
            // 
            // rdbM
            // 
            this.rdbM.AutoSize = true;
            this.rdbM.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.rdbM.Location = new System.Drawing.Point(47, 21);
            this.rdbM.Name = "rdbM";
            this.rdbM.Size = new System.Drawing.Size(68, 34);
            this.rdbM.TabIndex = 3;
            this.rdbM.TabStop = true;
            this.rdbM.Text = "معین";
            this.rdbM.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(869, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "نوع صورت حساب";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(996, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "کد";
            // 
            // cmbcode
            // 
            this.cmbcode.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.cmbcode.FormattingEnabled = true;
            this.cmbcode.Location = new System.Drawing.Point(562, 162);
            this.cmbcode.Name = "cmbcode";
            this.cmbcode.Size = new System.Drawing.Size(293, 40);
            this.cmbcode.TabIndex = 4;
            this.cmbcode.TextUpdate += new System.EventHandler(this.cmbcode_TextUpdate);
            this.cmbcode.SelectedValueChanged += new System.EventHandler(this.cmbcode_SelectedValueChanged);
            this.cmbcode.Enter += new System.EventHandler(this.cmbcode_Enter);
            this.cmbcode.Leave += new System.EventHandler(this.cmbcode_Leave);
            // 
            // datagridview
            // 
            this.datagridview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.datagridview.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview.Location = new System.Drawing.Point(110, 378);
            this.datagridview.Name = "datagridview";
            this.datagridview.ReadOnly = true;
            this.datagridview.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.datagridview.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Purple;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Navy;
            this.datagridview.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.datagridview.RowTemplate.Height = 24;
            this.datagridview.Size = new System.Drawing.Size(926, 368);
            this.datagridview.TabIndex = 94;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rdbM);
            this.groupBox1.Controls.Add(this.rdbW);
            this.groupBox1.Location = new System.Drawing.Point(562, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(996, 236);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(36, 38);
            this.label4.TabIndex = 8;
            this.label4.Text = "از:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.Location = new System.Drawing.Point(762, 238);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(35, 38);
            this.label5.TabIndex = 9;
            this.label5.Text = "تا:";
            // 
            // txtboxFday
            // 
            this.txtboxFday.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtboxFday.Location = new System.Drawing.Point(954, 236);
            this.txtboxFday.MaxLength = 2;
            this.txtboxFday.Name = "txtboxFday";
            this.txtboxFday.Size = new System.Drawing.Size(24, 36);
            this.txtboxFday.TabIndex = 5;
            this.txtboxFday.TextChanged += new System.EventHandler(this.txtboxFday_TextChanged);
            this.txtboxFday.Leave += new System.EventHandler(this.txtboxFday_Leave);
            // 
            // txtboxFmonth
            // 
            this.txtboxFmonth.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtboxFmonth.Location = new System.Drawing.Point(911, 236);
            this.txtboxFmonth.MaxLength = 2;
            this.txtboxFmonth.Name = "txtboxFmonth";
            this.txtboxFmonth.Size = new System.Drawing.Size(24, 36);
            this.txtboxFmonth.TabIndex = 6;
            this.txtboxFmonth.TextChanged += new System.EventHandler(this.txtboxFmonth_TextChanged);
            this.txtboxFmonth.Leave += new System.EventHandler(this.txtboxFmonth_Leave);
            // 
            // txtboxFyear
            // 
            this.txtboxFyear.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtboxFyear.Location = new System.Drawing.Point(837, 236);
            this.txtboxFyear.MaxLength = 4;
            this.txtboxFyear.Name = "txtboxFyear";
            this.txtboxFyear.Size = new System.Drawing.Size(55, 36);
            this.txtboxFyear.TabIndex = 7;
            this.txtboxFyear.TextChanged += new System.EventHandler(this.txtboxFyear_TextChanged);
            this.txtboxFyear.Leave += new System.EventHandler(this.txtboxFyear_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(937, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 24);
            this.label6.TabIndex = 17;
            this.label6.Text = "/";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(894, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 24);
            this.label7.TabIndex = 18;
            this.label7.Text = "/";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(670, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 24);
            this.label8.TabIndex = 23;
            this.label8.Text = "/";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(717, 244);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 24);
            this.label9.TabIndex = 22;
            this.label9.Text = "/";
            // 
            // txtboxTyear
            // 
            this.txtboxTyear.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtboxTyear.Location = new System.Drawing.Point(609, 236);
            this.txtboxTyear.MaxLength = 4;
            this.txtboxTyear.Name = "txtboxTyear";
            this.txtboxTyear.Size = new System.Drawing.Size(55, 36);
            this.txtboxTyear.TabIndex = 91;
            this.txtboxTyear.TextChanged += new System.EventHandler(this.txtboxTyear_TextChanged);
            this.txtboxTyear.Leave += new System.EventHandler(this.txtboxTyear_Leave);
            // 
            // txtboxTmonth
            // 
            this.txtboxTmonth.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtboxTmonth.Location = new System.Drawing.Point(689, 236);
            this.txtboxTmonth.MaxLength = 2;
            this.txtboxTmonth.Name = "txtboxTmonth";
            this.txtboxTmonth.Size = new System.Drawing.Size(24, 36);
            this.txtboxTmonth.TabIndex = 9;
            this.txtboxTmonth.TextChanged += new System.EventHandler(this.txtboxTmonth_TextChanged);
            this.txtboxTmonth.Leave += new System.EventHandler(this.txtboxTmonth_Leave);
            // 
            // txtboxTday
            // 
            this.txtboxTday.Font = new System.Drawing.Font("B Nazanin", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtboxTday.Location = new System.Drawing.Point(733, 236);
            this.txtboxTday.MaxLength = 2;
            this.txtboxTday.Name = "txtboxTday";
            this.txtboxTday.Size = new System.Drawing.Size(24, 36);
            this.txtboxTday.TabIndex = 8;
            this.txtboxTday.TextChanged += new System.EventHandler(this.txtboxTday_TextChanged);
            this.txtboxTday.Leave += new System.EventHandler(this.txtboxTday_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(377, 165);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(72, 38);
            this.label10.TabIndex = 24;
            this.label10.Text = "عنوان:";
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.BackColor = System.Drawing.Color.Transparent;
            this.lbltitle.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbltitle.Location = new System.Drawing.Point(177, 165);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbltitle.Size = new System.Drawing.Size(53, 38);
            this.lbltitle.TabIndex = 25;
            this.lbltitle.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.Location = new System.Drawing.Point(370, 241);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(107, 38);
            this.label3.TabIndex = 26;
            this.label3.Text = "مانده قبلی:";
            // 
            // lblPRemaining
            // 
            this.lblPRemaining.AutoSize = true;
            this.lblPRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblPRemaining.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblPRemaining.Location = new System.Drawing.Point(258, 241);
            this.lblPRemaining.Name = "lblPRemaining";
            this.lblPRemaining.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPRemaining.Size = new System.Drawing.Size(77, 38);
            this.lblPRemaining.TabIndex = 27;
            this.lblPRemaining.Text = "-----";
            // 
            // lblFRemaining
            // 
            this.lblFRemaining.AutoSize = true;
            this.lblFRemaining.BackColor = System.Drawing.Color.Transparent;
            this.lblFRemaining.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblFRemaining.Location = new System.Drawing.Point(602, 767);
            this.lblFRemaining.Name = "lblFRemaining";
            this.lblFRemaining.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFRemaining.Size = new System.Drawing.Size(77, 38);
            this.lblFRemaining.TabIndex = 29;
            this.lblFRemaining.Text = "-----";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.Location = new System.Drawing.Point(709, 767);
            this.label12.Name = "label12";
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(68, 38);
            this.label12.TabIndex = 28;
            this.label12.Text = "مانده :";
            // 
            // btnshow
            // 
            this.btnshow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnshow.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnshow.Location = new System.Drawing.Point(778, 299);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(258, 61);
            this.btnshow.TabIndex = 92;
            this.btnshow.Text = "نمایش گزارش";
            this.btnshow.UseVisualStyleBackColor = false;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btnclear.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnclear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnclear.Location = new System.Drawing.Point(138, 299);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(236, 61);
            this.btnclear.TabIndex = 93;
            this.btnclear.Text = "پاک کردن جدول گزارش";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // lblfnature
            // 
            this.lblfnature.AutoSize = true;
            this.lblfnature.BackColor = System.Drawing.Color.Transparent;
            this.lblfnature.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblfnature.Location = new System.Drawing.Point(470, 767);
            this.lblfnature.Name = "lblfnature";
            this.lblfnature.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblfnature.Size = new System.Drawing.Size(77, 38);
            this.lblfnature.TabIndex = 32;
            this.lblfnature.Text = "-----";
            // 
            // lblpnature
            // 
            this.lblpnature.AutoSize = true;
            this.lblpnature.BackColor = System.Drawing.Color.Transparent;
            this.lblpnature.Font = new System.Drawing.Font("B Nazanin", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblpnature.Location = new System.Drawing.Point(110, 243);
            this.lblpnature.Name = "lblpnature";
            this.lblpnature.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblpnature.Size = new System.Drawing.Size(77, 38);
            this.lblpnature.TabIndex = 33;
            this.lblpnature.Text = "-----";
            // 
            // btndateClear
            // 
            this.btndateClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(180)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.btndateClear.Font = new System.Drawing.Font("B Nazanin", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btndateClear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btndateClear.Location = new System.Drawing.Point(440, 299);
            this.btndateClear.Name = "btndateClear";
            this.btndateClear.Size = new System.Drawing.Size(292, 61);
            this.btndateClear.TabIndex = 95;
            this.btndateClear.Text = "پاک کردن فیلد تاریخ";
            this.btndateClear.UseVisualStyleBackColor = false;
            this.btndateClear.Click += new System.EventHandler(this.btndateClear_Click);
            // 
            // frmSoratHesabWM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::project.Properties.Resources.photocollage_202382014591245;
            this.ClientSize = new System.Drawing.Size(1182, 953);
            this.ControlBox = false;
            this.Controls.Add(this.btndateClear);
            this.Controls.Add(this.lblpnature);
            this.Controls.Add(this.lblfnature);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnshow);
            this.Controls.Add(this.lblFRemaining);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblPRemaining);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.label10);
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
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.datagridview);
            this.Controls.Add(this.cmbcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmSoratHesabWM";
            this.Text = "صورت حساب";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbW;
        private System.Windows.Forms.RadioButton rdbM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbcode;
        private System.Windows.Forms.DataGridView datagridview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtboxFday;
        private System.Windows.Forms.TextBox txtboxFmonth;
        private System.Windows.Forms.TextBox txtboxFyear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtboxTyear;
        private System.Windows.Forms.TextBox txtboxTmonth;
        private System.Windows.Forms.TextBox txtboxTday;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPRemaining;
        private System.Windows.Forms.Label lblFRemaining;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Label lblfnature;
        private System.Windows.Forms.Label lblpnature;
        private System.Windows.Forms.Button btndateClear;
    }
}