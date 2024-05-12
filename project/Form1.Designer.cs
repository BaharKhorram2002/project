
namespace project
{
    partial class Form1
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
            this.btnInsertBW = new System.Windows.Forms.Button();
            this.btnInsertBM = new System.Windows.Forms.Button();
            this.btnInsertSW = new System.Windows.Forms.Button();
            this.btsInsertSM = new System.Windows.Forms.Button();
            this.btnsoratHesab = new System.Windows.Forms.Button();
            this.btnKholaseM = new System.Windows.Forms.Button();
            this.btnKholaseW = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInsertBW
            // 
            this.btnInsertBW.Location = new System.Drawing.Point(77, 76);
            this.btnInsertBW.Name = "btnInsertBW";
            this.btnInsertBW.Size = new System.Drawing.Size(214, 48);
            this.btnInsertBW.TabIndex = 1;
            this.btnInsertBW.Text = "ورود اطلاعات پایه کل";
            this.btnInsertBW.UseVisualStyleBackColor = true;
            this.btnInsertBW.Click += new System.EventHandler(this.btnInsertBW_Click);
            // 
            // btnInsertBM
            // 
            this.btnInsertBM.Location = new System.Drawing.Point(77, 130);
            this.btnInsertBM.Name = "btnInsertBM";
            this.btnInsertBM.Size = new System.Drawing.Size(214, 48);
            this.btnInsertBM.TabIndex = 2;
            this.btnInsertBM.Text = "ورود اطلاعات پایه معین";
            this.btnInsertBM.UseVisualStyleBackColor = true;
            this.btnInsertBM.Click += new System.EventHandler(this.btnInsertBM_Click);
            // 
            // btnInsertSW
            // 
            this.btnInsertSW.Location = new System.Drawing.Point(77, 184);
            this.btnInsertSW.Name = "btnInsertSW";
            this.btnInsertSW.Size = new System.Drawing.Size(214, 48);
            this.btnInsertSW.TabIndex = 3;
            this.btnInsertSW.Text = "ثبت سند کل";
            this.btnInsertSW.UseVisualStyleBackColor = true;
            this.btnInsertSW.Click += new System.EventHandler(this.btnInsertSW_Click);
            // 
            // btsInsertSM
            // 
            this.btsInsertSM.Location = new System.Drawing.Point(77, 238);
            this.btsInsertSM.Name = "btsInsertSM";
            this.btsInsertSM.Size = new System.Drawing.Size(214, 56);
            this.btsInsertSM.TabIndex = 4;
            this.btsInsertSM.Text = "ثبت سند معین";
            this.btsInsertSM.UseVisualStyleBackColor = true;
            this.btsInsertSM.Click += new System.EventHandler(this.btsInsertSM_Click);
            // 
            // btnsoratHesab
            // 
            this.btnsoratHesab.Location = new System.Drawing.Point(373, 76);
            this.btnsoratHesab.Name = "btnsoratHesab";
            this.btnsoratHesab.Size = new System.Drawing.Size(214, 48);
            this.btnsoratHesab.TabIndex = 5;
            this.btnsoratHesab.Text = "گزارش صورتحساب";
            this.btnsoratHesab.UseVisualStyleBackColor = true;
            this.btnsoratHesab.Click += new System.EventHandler(this.btnsoratHesab_Click);
            // 
            // btnKholaseM
            // 
            this.btnKholaseM.Location = new System.Drawing.Point(373, 130);
            this.btnKholaseM.Name = "btnKholaseM";
            this.btnKholaseM.Size = new System.Drawing.Size(214, 48);
            this.btnKholaseM.TabIndex = 6;
            this.btnKholaseM.Text = "گزارش خلاصه وضعیت معین";
            this.btnKholaseM.UseVisualStyleBackColor = true;
            this.btnKholaseM.Click += new System.EventHandler(this.btnKholaseM_Click);
            // 
            // btnKholaseW
            // 
            this.btnKholaseW.Location = new System.Drawing.Point(373, 194);
            this.btnKholaseW.Name = "btnKholaseW";
            this.btnKholaseW.Size = new System.Drawing.Size(214, 48);
            this.btnKholaseW.TabIndex = 7;
            this.btnKholaseW.Text = "گزارش خلاصه وضعیت کل";
            this.btnKholaseW.UseVisualStyleBackColor = true;
            this.btnKholaseW.Click += new System.EventHandler(this.btnKholaseW_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::project.Properties.Resources.photocollage_202382014591245;
            this.ClientSize = new System.Drawing.Size(683, 450);
            this.Controls.Add(this.btnKholaseW);
            this.Controls.Add(this.btnKholaseM);
            this.Controls.Add(this.btnsoratHesab);
            this.Controls.Add(this.btsInsertSM);
            this.Controls.Add(this.btnInsertSW);
            this.Controls.Add(this.btnInsertBM);
            this.Controls.Add(this.btnInsertBW);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInsertBW;
        private System.Windows.Forms.Button btnInsertBM;
        private System.Windows.Forms.Button btnInsertSW;
        private System.Windows.Forms.Button btsInsertSM;
        private System.Windows.Forms.Button btnsoratHesab;
        private System.Windows.Forms.Button btnKholaseM;
        private System.Windows.Forms.Button btnKholaseW;
    }
}

