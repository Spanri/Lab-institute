namespace WindowsFormsApp12
{
    partial class Form2Output
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
            this.date = new System.Windows.Forms.TextBox();
            this.numTr = new System.Windows.Forms.TextBox();
            this.dest = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // date
            // 
            this.date.Location = new System.Drawing.Point(101, 66);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(131, 22);
            this.date.TabIndex = 13;
            // 
            // numTr
            // 
            this.numTr.Location = new System.Drawing.Point(101, 94);
            this.numTr.Name = "numTr";
            this.numTr.Size = new System.Drawing.Size(131, 22);
            this.numTr.TabIndex = 12;
            // 
            // dest
            // 
            this.dest.Location = new System.Drawing.Point(101, 38);
            this.dest.Name = "dest";
            this.dest.Size = new System.Drawing.Size(131, 22);
            this.dest.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "dest";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "numTr";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "date";
            // 
            // Form2Output
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 191);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date);
            this.Controls.Add(this.numTr);
            this.Controls.Add(this.dest);
            this.Controls.Add(this.button1);
            this.Name = "Form2Output";
            this.Text = "Form2Output";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox date;
        private System.Windows.Forms.TextBox numTr;
        private System.Windows.Forms.TextBox dest;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}