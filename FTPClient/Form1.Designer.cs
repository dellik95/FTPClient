namespace FTPClient
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.login_tb = new System.Windows.Forms.TextBox();
            this.pass_tb = new System.Windows.Forms.TextBox();
            this.cnct_btn = new System.Windows.Forms.Button();
            this.upload_btn = new System.Windows.Forms.Button();
            this.download_btn = new System.Windows.Forms.Button();
            this.delete_btn = new System.Windows.Forms.Button();
            this.ftplist_btn = new System.Windows.Forms.Button();
            this.host_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Логин";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Пароль";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 229);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(354, 260);
            this.listBox1.TabIndex = 1;
            this.listBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseClick);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(372, 229);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(348, 260);
            this.listBox2.TabIndex = 2;
            // 
            // login_tb
            // 
            this.login_tb.Location = new System.Drawing.Point(103, 106);
            this.login_tb.Name = "login_tb";
            this.login_tb.Size = new System.Drawing.Size(211, 22);
            this.login_tb.TabIndex = 3;
            // 
            // pass_tb
            // 
            this.pass_tb.Location = new System.Drawing.Point(103, 136);
            this.pass_tb.Name = "pass_tb";
            this.pass_tb.Size = new System.Drawing.Size(211, 22);
            this.pass_tb.TabIndex = 3;
            // 
            // cnct_btn
            // 
            this.cnct_btn.Location = new System.Drawing.Point(103, 161);
            this.cnct_btn.Name = "cnct_btn";
            this.cnct_btn.Size = new System.Drawing.Size(126, 31);
            this.cnct_btn.TabIndex = 4;
            this.cnct_btn.Text = "Конект";
            this.cnct_btn.UseVisualStyleBackColor = true;
            this.cnct_btn.Click += new System.EventHandler(this.cnct_btn_Click);
            // 
            // upload_btn
            // 
            this.upload_btn.Location = new System.Drawing.Point(372, 68);
            this.upload_btn.Name = "upload_btn";
            this.upload_btn.Size = new System.Drawing.Size(142, 41);
            this.upload_btn.TabIndex = 5;
            this.upload_btn.Text = "Загрузить";
            this.upload_btn.UseVisualStyleBackColor = true;
            this.upload_btn.Click += new System.EventHandler(this.upload_btn_Click);
            // 
            // download_btn
            // 
            this.download_btn.Location = new System.Drawing.Point(372, 115);
            this.download_btn.Name = "download_btn";
            this.download_btn.Size = new System.Drawing.Size(142, 40);
            this.download_btn.TabIndex = 5;
            this.download_btn.Text = "Скачать";
            this.download_btn.UseVisualStyleBackColor = true;
            this.download_btn.Click += new System.EventHandler(this.download_btn_Click);
            // 
            // delete_btn
            // 
            this.delete_btn.Location = new System.Drawing.Point(372, 161);
            this.delete_btn.Name = "delete_btn";
            this.delete_btn.Size = new System.Drawing.Size(142, 41);
            this.delete_btn.TabIndex = 5;
            this.delete_btn.Text = "удалить";
            this.delete_btn.UseVisualStyleBackColor = true;
            this.delete_btn.Click += new System.EventHandler(this.delete_btn_Click);
            // 
            // ftplist_btn
            // 
            this.ftplist_btn.Location = new System.Drawing.Point(520, 68);
            this.ftplist_btn.Name = "ftplist_btn";
            this.ftplist_btn.Size = new System.Drawing.Size(200, 41);
            this.ftplist_btn.TabIndex = 5;
            this.ftplist_btn.Text = "Проверить";
            this.ftplist_btn.UseVisualStyleBackColor = true;
            this.ftplist_btn.Click += new System.EventHandler(this.ftplist_btn_Click);
            // 
            // host_tb
            // 
            this.host_tb.Location = new System.Drawing.Point(103, 68);
            this.host_tb.Name = "host_tb";
            this.host_tb.Size = new System.Drawing.Size(211, 22);
            this.host_tb.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Сервер";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 492);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.delete_btn);
            this.Controls.Add(this.download_btn);
            this.Controls.Add(this.ftplist_btn);
            this.Controls.Add(this.upload_btn);
            this.Controls.Add(this.cnct_btn);
            this.Controls.Add(this.host_tb);
            this.Controls.Add(this.pass_tb);
            this.Controls.Add(this.login_tb);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "FTP Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.TextBox login_tb;
        private System.Windows.Forms.TextBox pass_tb;
        private System.Windows.Forms.Button cnct_btn;
        private System.Windows.Forms.Button upload_btn;
        private System.Windows.Forms.Button download_btn;
        private System.Windows.Forms.Button delete_btn;
        private System.Windows.Forms.Button ftplist_btn;
        private System.Windows.Forms.TextBox host_tb;
        private System.Windows.Forms.Label label1;
    }
}

