namespace MertTestUygulama
{
    partial class Word
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
            this.lst_docs = new System.Windows.Forms.ListBox();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_savepath = new System.Windows.Forms.Button();
            this.btn_write = new System.Windows.Forms.Button();
            this.check_accept = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lst_docs
            // 
            this.lst_docs.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lst_docs.FormattingEnabled = true;
            this.lst_docs.Location = new System.Drawing.Point(12, 67);
            this.lst_docs.Name = "lst_docs";
            this.lst_docs.Size = new System.Drawing.Size(85, 329);
            this.lst_docs.TabIndex = 0;
            this.lst_docs.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(12, 12);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(364, 20);
            this.txt_path.TabIndex = 1;
            // 
            // btn_savepath
            // 
            this.btn_savepath.Location = new System.Drawing.Point(12, 38);
            this.btn_savepath.Name = "btn_savepath";
            this.btn_savepath.Size = new System.Drawing.Size(122, 23);
            this.btn_savepath.TabIndex = 2;
            this.btn_savepath.Text = "Kayıt yeri belirle";
            this.btn_savepath.UseVisualStyleBackColor = true;
            this.btn_savepath.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_write
            // 
            this.btn_write.Enabled = false;
            this.btn_write.Location = new System.Drawing.Point(12, 441);
            this.btn_write.Name = "btn_write";
            this.btn_write.Size = new System.Drawing.Size(274, 23);
            this.btn_write.TabIndex = 3;
            this.btn_write.Text = "Eminim yeni dosyayı yaz.";
            this.btn_write.UseVisualStyleBackColor = true;
            this.btn_write.Click += new System.EventHandler(this.button2_Click);
            // 
            // check_accept
            // 
            this.check_accept.AutoSize = true;
            this.check_accept.Location = new System.Drawing.Point(12, 418);
            this.check_accept.Name = "check_accept";
            this.check_accept.Size = new System.Drawing.Size(274, 17);
            this.check_accept.TabIndex = 4;
            this.check_accept.Text = "Tüm bilgileri doğru ve eksiksiz doldurduğuma eminim.";
            this.check_accept.UseVisualStyleBackColor = true;
            this.check_accept.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Word
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 606);
            this.Controls.Add(this.check_accept);
            this.Controls.Add(this.btn_write);
            this.Controls.Add(this.btn_savepath);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.lst_docs);
            this.Name = "Word";
            this.Text = "Form4";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form4_FormClosed);
            this.Load += new System.EventHandler(this.Word_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_docs;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_savepath;
        private System.Windows.Forms.Button btn_write;
        private System.Windows.Forms.CheckBox check_accept;
    }
}