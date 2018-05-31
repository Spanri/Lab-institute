namespace AntiV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lastScan = new System.Windows.Forms.Label();
            this.scan = new System.Windows.Forms.Label();
            this.scanPath = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.changeScanPath = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.changeSignPath = new System.Windows.Forms.Label();
            this.signPath = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.deleteInfFile = new System.Windows.Forms.Label();
            this.deleteFile = new System.Windows.Forms.Label();
            this.addSign = new System.Windows.Forms.Label();
            this.files = new System.Windows.Forms.Label();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.virusBase = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // Close
            // 
            this.Close.BackColor = System.Drawing.Color.LightBlue;
            this.Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Close.FlatAppearance.BorderSize = 0;
            this.Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightBlue;
            this.Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Close.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close.ForeColor = System.Drawing.Color.Transparent;
            this.Close.Location = new System.Drawing.Point(1320, 0);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(45, 40);
            this.Close.TabIndex = 1;
            this.Close.Text = "Х";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(596, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Antivirus Anin";
            // 
            // lastScan
            // 
            this.lastScan.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lastScan.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastScan.ForeColor = System.Drawing.Color.Crimson;
            this.lastScan.Location = new System.Drawing.Point(738, 64);
            this.lastScan.Name = "lastScan";
            this.lastScan.Size = new System.Drawing.Size(182, 271);
            this.lastScan.TabIndex = 4;
            this.lastScan.Text = "Последнее сканирование:";
            this.lastScan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scan
            // 
            this.scan.BackColor = System.Drawing.Color.Crimson;
            this.scan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.scan.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scan.Location = new System.Drawing.Point(738, 357);
            this.scan.Name = "scan";
            this.scan.Size = new System.Drawing.Size(188, 93);
            this.scan.TabIndex = 7;
            this.scan.Text = "Сканировать!";
            this.scan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scan.Click += new System.EventHandler(this.scan_Click);
            // 
            // scanPath
            // 
            this.scanPath.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scanPath.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scanPath.ForeColor = System.Drawing.Color.Crimson;
            this.scanPath.Location = new System.Drawing.Point(944, 64);
            this.scanPath.Name = "scanPath";
            this.scanPath.Size = new System.Drawing.Size(187, 271);
            this.scanPath.TabIndex = 8;
            this.scanPath.Text = "Путь сканирования:\r\n";
            this.scanPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Crimson;
            this.label6.Location = new System.Drawing.Point(747, 565);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(245, 29);
            this.label6.TabIndex = 9;
            this.label6.Text = "Anin Corporation, 2018";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(25, 565);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(35, 34);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Location = new System.Drawing.Point(129, 565);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 34);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Location = new System.Drawing.Point(77, 565);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 34);
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // changeScanPath
            // 
            this.changeScanPath.BackColor = System.Drawing.Color.Crimson;
            this.changeScanPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeScanPath.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeScanPath.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.changeScanPath.Location = new System.Drawing.Point(941, 357);
            this.changeScanPath.Name = "changeScanPath";
            this.changeScanPath.Size = new System.Drawing.Size(193, 93);
            this.changeScanPath.TabIndex = 14;
            this.changeScanPath.Text = "Изменить путь сканирования\r\n";
            this.changeScanPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.changeScanPath.Click += new System.EventHandler(this.label8_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.LightBlue;
            this.label9.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(735, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 277);
            this.label9.TabIndex = 15;
            this.label9.Text = "\r\n";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.LightBlue;
            this.label10.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.SteelBlue;
            this.label10.Location = new System.Drawing.Point(941, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(193, 277);
            this.label10.TabIndex = 16;
            this.label10.Text = "\r\n";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.SteelBlue;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Myriad Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(33, 105);
            this.listBox1.MinimumSize = new System.Drawing.Size(338, 360);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBox1.Size = new System.Drawing.Size(678, 360);
            this.listBox1.TabIndex = 17;
            // 
            // changeSignPath
            // 
            this.changeSignPath.BackColor = System.Drawing.Color.Crimson;
            this.changeSignPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changeSignPath.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeSignPath.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.changeSignPath.Location = new System.Drawing.Point(1152, 357);
            this.changeSignPath.Name = "changeSignPath";
            this.changeSignPath.Size = new System.Drawing.Size(193, 93);
            this.changeSignPath.TabIndex = 19;
            this.changeSignPath.Text = "Изменить путь к файлу базы вирусов\r\n";
            this.changeSignPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.changeSignPath.Click += new System.EventHandler(this.changeSignPath_Click);
            // 
            // signPath
            // 
            this.signPath.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.signPath.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signPath.ForeColor = System.Drawing.Color.Crimson;
            this.signPath.Location = new System.Drawing.Point(1155, 64);
            this.signPath.Name = "signPath";
            this.signPath.Size = new System.Drawing.Size(187, 271);
            this.signPath.TabIndex = 18;
            this.signPath.Text = "Путь к файлу базы вирусов:\r\n";
            this.signPath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LightBlue;
            this.label11.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.SteelBlue;
            this.label11.Location = new System.Drawing.Point(1152, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 277);
            this.label11.TabIndex = 20;
            this.label11.Text = "\r\n";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deleteInfFile
            // 
            this.deleteInfFile.BackColor = System.Drawing.Color.Salmon;
            this.deleteInfFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteInfFile.Enabled = false;
            this.deleteInfFile.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteInfFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteInfFile.Location = new System.Drawing.Point(1064, 478);
            this.deleteInfFile.Name = "deleteInfFile";
            this.deleteInfFile.Size = new System.Drawing.Size(281, 73);
            this.deleteInfFile.TabIndex = 23;
            this.deleteInfFile.Text = "Удалить зараженный файл";
            this.deleteInfFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteInfFile.Click += new System.EventHandler(this.deleteFile_Click);
            // 
            // deleteFile
            // 
            this.deleteFile.BackColor = System.Drawing.Color.Salmon;
            this.deleteFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteFile.Enabled = false;
            this.deleteFile.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.deleteFile.Location = new System.Drawing.Point(740, 478);
            this.deleteFile.Name = "deleteFile";
            this.deleteFile.Size = new System.Drawing.Size(295, 73);
            this.deleteFile.TabIndex = 24;
            this.deleteFile.Text = "Удалить сигнатуру вируса";
            this.deleteFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deleteFile.Click += new System.EventHandler(this.deleteFile_Click_1);
            // 
            // addSign
            // 
            this.addSign.BackColor = System.Drawing.Color.Salmon;
            this.addSign.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addSign.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSign.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.addSign.Location = new System.Drawing.Point(33, 478);
            this.addSign.Name = "addSign";
            this.addSign.Size = new System.Drawing.Size(325, 73);
            this.addSign.TabIndex = 25;
            this.addSign.Text = "Добавить сигнатуру в базу";
            this.addSign.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addSign.Click += new System.EventHandler(this.addSign_Click);
            // 
            // files
            // 
            this.files.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.files.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.files.ForeColor = System.Drawing.Color.Crimson;
            this.files.Location = new System.Drawing.Point(33, 64);
            this.files.Name = "files";
            this.files.Size = new System.Drawing.Size(678, 27);
            this.files.TabIndex = 26;
            this.files.Text = "Файлы";
            this.files.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // virusBase
            // 
            this.virusBase.BackColor = System.Drawing.Color.Salmon;
            this.virusBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.virusBase.Font = new System.Drawing.Font("Myriad Pro", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.virusBase.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.virusBase.Location = new System.Drawing.Point(387, 478);
            this.virusBase.Name = "virusBase";
            this.virusBase.Size = new System.Drawing.Size(324, 73);
            this.virusBase.TabIndex = 27;
            this.virusBase.Text = "Показать базу вирусов";
            this.virusBase.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.virusBase.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1364, 614);
            this.ControlBox = false;
            this.Controls.Add(this.virusBase);
            this.Controls.Add(this.files);
            this.Controls.Add(this.addSign);
            this.Controls.Add(this.deleteFile);
            this.Controls.Add(this.deleteInfFile);
            this.Controls.Add(this.changeSignPath);
            this.Controls.Add(this.signPath);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.changeScanPath);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.scanPath);
            this.Controls.Add(this.scan);
            this.Controls.Add(this.lastScan);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label scan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label changeScanPath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label changeSignPath;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label deleteInfFile;
        private System.Windows.Forms.Label deleteFile;
        private System.Windows.Forms.Label addSign;
        public System.Windows.Forms.Label lastScan;
        public System.Windows.Forms.Label scanPath;
        public System.Windows.Forms.Label signPath;
        public System.Windows.Forms.Label files;
        public System.Windows.Forms.ListBox listBox1;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.Label virusBase;
    }
}

