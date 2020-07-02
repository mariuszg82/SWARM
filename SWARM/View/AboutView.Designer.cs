namespace SWARM.View
{
    partial class AboutView
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.appName = new System.Windows.Forms.Label();
            this.authorLabel = new System.Windows.Forms.Label();
            this.author = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.version = new System.Windows.Forms.Label();
            this.logoGfx = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoGfx)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(167, 103);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "Zamknij";
            this.closeBtn.UseVisualStyleBackColor = true;
            // 
            // appName
            // 
            this.appName.AutoSize = true;
            this.appName.Location = new System.Drawing.Point(82, 9);
            this.appName.Name = "appName";
            this.appName.Size = new System.Drawing.Size(53, 13);
            this.appName.TabIndex = 1;
            this.appName.Text = "appName";
            // 
            // authorLabel
            // 
            this.authorLabel.AutoSize = true;
            this.authorLabel.Location = new System.Drawing.Point(82, 56);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(35, 13);
            this.authorLabel.TabIndex = 2;
            this.authorLabel.Text = "Autor:";
            // 
            // author
            // 
            this.author.AutoSize = true;
            this.author.Location = new System.Drawing.Point(131, 56);
            this.author.Name = "author";
            this.author.Size = new System.Drawing.Size(21, 13);
            this.author.TabIndex = 3;
            this.author.Text = "mg";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(82, 33);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(43, 13);
            this.versionLabel.TabIndex = 4;
            this.versionLabel.Text = "Wersja:";
            // 
            // version
            // 
            this.version.AutoSize = true;
            this.version.Location = new System.Drawing.Point(131, 33);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(13, 13);
            this.version.TabIndex = 5;
            this.version.Text = "0";
            // 
            // logoGfx
            // 
            this.logoGfx.Image = global::SWARM.Properties.Resources.atom_641;
            this.logoGfx.Location = new System.Drawing.Point(12, 9);
            this.logoGfx.Name = "logoGfx";
            this.logoGfx.Size = new System.Drawing.Size(64, 64);
            this.logoGfx.TabIndex = 6;
            this.logoGfx.TabStop = false;
            // 
            // AboutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(250, 134);
            this.ControlBox = false;
            this.Controls.Add(this.logoGfx);
            this.Controls.Add(this.version);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.author);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.appName);
            this.Controls.Add(this.closeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AboutView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "O programie";
            ((System.ComponentModel.ISupportInitialize)(this.logoGfx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label appName;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.Label author;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.PictureBox logoGfx;
    }
}