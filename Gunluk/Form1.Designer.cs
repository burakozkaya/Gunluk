namespace Gunluk
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxGunluk = new ListBox();
            txtIcerik = new RichTextBox();
            txtBaslik = new TextBox();
            btnKaydet = new Button();
            btnDuzenle = new Button();
            btnReset = new Button();
            SuspendLayout();
            // 
            // listBoxGunluk
            // 
            listBoxGunluk.FormattingEnabled = true;
            listBoxGunluk.ItemHeight = 15;
            listBoxGunluk.Location = new Point(12, 12);
            listBoxGunluk.Name = "listBoxGunluk";
            listBoxGunluk.Size = new Size(163, 424);
            listBoxGunluk.TabIndex = 0;
            listBoxGunluk.TabStop = false;
            listBoxGunluk.MouseDoubleClick += listGunluk_MouseDoubleClick;
            // 
            // txtIcerik
            // 
            txtIcerik.Location = new Point(181, 12);
            txtIcerik.Name = "txtIcerik";
            txtIcerik.Size = new Size(607, 371);
            txtIcerik.TabIndex = 1;
            txtIcerik.Text = "";
            // 
            // txtBaslik
            // 
            txtBaslik.Location = new Point(406, 389);
            txtBaslik.Name = "txtBaslik";
            txtBaslik.PlaceholderText = "Başlığı Girin";
            txtBaslik.Size = new Size(110, 23);
            txtBaslik.TabIndex = 2;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(406, 413);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(110, 23);
            btnKaydet.TabIndex = 3;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnDuzenle
            // 
            btnDuzenle.Location = new Point(522, 389);
            btnDuzenle.Name = "btnDuzenle";
            btnDuzenle.Size = new Size(67, 47);
            btnDuzenle.TabIndex = 5;
            btnDuzenle.Text = "Düzenle";
            btnDuzenle.UseVisualStyleBackColor = true;
            btnDuzenle.Click += btnDuzenle_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(333, 389);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(67, 47);
            btnReset.TabIndex = 6;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnReset);
            Controls.Add(btnDuzenle);
            Controls.Add(btnKaydet);
            Controls.Add(txtBaslik);
            Controls.Add(txtIcerik);
            Controls.Add(listBoxGunluk);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxGunluk;
        private RichTextBox txtIcerik;
        private TextBox txtBaslik;
        private Button btnKaydet;
        private Button btnDuzenle;
        private Button btnReset;
    }
}