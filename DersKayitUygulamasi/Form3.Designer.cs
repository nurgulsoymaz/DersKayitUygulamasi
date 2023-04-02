namespace DersKayitUygulamasi
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.btnForm2 = new System.Windows.Forms.Button();
            this.btnForm4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnForm2
            // 
            this.btnForm2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnForm2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnForm2.Location = new System.Drawing.Point(281, 122);
            this.btnForm2.Name = "btnForm2";
            this.btnForm2.Size = new System.Drawing.Size(170, 93);
            this.btnForm2.TabIndex = 0;
            this.btnForm2.Text = "ÖĞRENCİ GİRİŞİ";
            this.btnForm2.UseVisualStyleBackColor = false;
            this.btnForm2.Click += new System.EventHandler(this.btnForm2_Click);
            // 
            // btnForm4
            // 
            this.btnForm4.BackColor = System.Drawing.Color.OliveDrab;
            this.btnForm4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnForm4.Location = new System.Drawing.Point(281, 268);
            this.btnForm4.Name = "btnForm4";
            this.btnForm4.Size = new System.Drawing.Size(170, 93);
            this.btnForm4.TabIndex = 1;
            this.btnForm4.Text = "AKADEMİ GİRİŞİ";
            this.btnForm4.UseVisualStyleBackColor = false;
            this.btnForm4.Click += new System.EventHandler(this.btnForm4_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(715, 401);
            this.Controls.Add(this.btnForm4);
            this.Controls.Add(this.btnForm2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnForm2;
        private Button btnForm4;
    }
}