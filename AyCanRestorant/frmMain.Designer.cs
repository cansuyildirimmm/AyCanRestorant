namespace AyCanRestorant
{
    partial class frmMain
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
            this.btnMalzemeler = new System.Windows.Forms.Button();
            this.btnYemekler = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMalzemeler
            // 
            this.btnMalzemeler.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMalzemeler.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMalzemeler.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnMalzemeler.Location = new System.Drawing.Point(147, 113);
            this.btnMalzemeler.Name = "btnMalzemeler";
            this.btnMalzemeler.Size = new System.Drawing.Size(208, 84);
            this.btnMalzemeler.TabIndex = 0;
            this.btnMalzemeler.Text = "Malzemeler";
            this.btnMalzemeler.UseVisualStyleBackColor = false;
            this.btnMalzemeler.Click += new System.EventHandler(this.btnMalzemeler_Click);
            // 
            // btnYemekler
            // 
            this.btnYemekler.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnYemekler.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYemekler.Location = new System.Drawing.Point(436, 113);
            this.btnYemekler.Name = "btnYemekler";
            this.btnYemekler.Size = new System.Drawing.Size(208, 84);
            this.btnYemekler.TabIndex = 1;
            this.btnYemekler.Text = "Yemekler";
            this.btnYemekler.UseVisualStyleBackColor = false;
            this.btnYemekler.Click += new System.EventHandler(this.btnYemekler_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(303, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "HOŞ GELDİNİZ";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSalmon;
            this.button1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(288, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(217, 87);
            this.button1.TabIndex = 3;
            this.button1.Text = "Yemek-Malzeme";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnYemekler);
            this.Controls.Add(this.btnMalzemeler);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMalzemeler;
        private System.Windows.Forms.Button btnYemekler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}