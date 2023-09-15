namespace AyCanRestorant
{
    partial class YemekMalzemeTablosu
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
            this.comboBoxYemekler = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxMalzemeler = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // comboBoxYemekler
            // 
            this.comboBoxYemekler.FormattingEnabled = true;
            this.comboBoxYemekler.Location = new System.Drawing.Point(323, 106);
            this.comboBoxYemekler.Name = "comboBoxYemekler";
            this.comboBoxYemekler.Size = new System.Drawing.Size(184, 24);
            this.comboBoxYemekler.TabIndex = 0;
            this.comboBoxYemekler.SelectedIndexChanged += new System.EventHandler(this.comboBoxYemekler_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(0)))), ((int)(((byte)(36)))));
            this.button1.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(627, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 69);
            this.button1.TabIndex = 2;
            this.button1.Text = "Kaydet";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            this.label1.Location = new System.Drawing.Point(302, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Yemek-Ham Madde";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(152, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Yemekler";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(152, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 27);
            this.label3.TabIndex = 5;
            this.label3.Text = "Malzemeler";
            // 
            // listBoxMalzemeler
            // 
            this.listBoxMalzemeler.FormattingEnabled = true;
            this.listBoxMalzemeler.ItemHeight = 16;
            this.listBoxMalzemeler.Location = new System.Drawing.Point(308, 172);
            this.listBoxMalzemeler.Name = "listBoxMalzemeler";
            this.listBoxMalzemeler.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxMalzemeler.Size = new System.Drawing.Size(271, 260);
            this.listBoxMalzemeler.TabIndex = 6;
            // 
            // YemekMalzemeTablosu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(89)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBoxMalzemeler);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxYemekler);
            this.Name = "YemekMalzemeTablosu";
            this.Text = "YemekMalzemeTablosu";
            this.Load += new System.EventHandler(this.YemekMalzemeTablosu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxYemekler;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxMalzemeler;
    }
}