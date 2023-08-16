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
            listGunluk = new ListBox();
            txtIcerik = new RichTextBox();
            txtBaslik = new TextBox();
            btnKaydet = new Button();
            btnReset = new Button();
            SuspendLayout();
            // 
            // listGunluk
            // 
            listGunluk.FormattingEnabled = true;
            listGunluk.ItemHeight = 15;
            listGunluk.Location = new Point(12, 12);
            listGunluk.Name = "listGunluk";
            listGunluk.Size = new Size(167, 424);
            listGunluk.TabIndex = 0;
            listGunluk.MouseDoubleClick += listGunluk_MouseDoubleClick;
            // 
            // txtIcerik
            // 
            txtIcerik.Location = new Point(197, 12);
            txtIcerik.Name = "txtIcerik";
            txtIcerik.Size = new Size(591, 371);
            txtIcerik.TabIndex = 1;
            txtIcerik.Text = "";
            // 
            // txtBaslik
            // 
            txtBaslik.Location = new Point(270, 389);
            txtBaslik.Name = "txtBaslik";
            txtBaslik.PlaceholderText = "Başlığı Girin";
            txtBaslik.Size = new Size(110, 23);
            txtBaslik.TabIndex = 2;
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(270, 413);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(110, 23);
            btnKaydet.TabIndex = 3;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(197, 389);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(67, 47);
            btnReset.TabIndex = 4;
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
            Controls.Add(btnKaydet);
            Controls.Add(txtBaslik);
            Controls.Add(txtIcerik);
            Controls.Add(listGunluk);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listGunluk;
        private RichTextBox txtIcerik;
        private TextBox txtBaslik;
        private Button btnKaydet;
        private Button btnReset;
    }
}