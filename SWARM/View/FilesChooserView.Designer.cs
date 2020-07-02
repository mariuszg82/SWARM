namespace SWARM.View
{
    partial class FilesChooserView
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
            this.directoryL = new System.Windows.Forms.Label();
            this.directoryTB = new System.Windows.Forms.TextBox();
            this.dirBtn = new System.Windows.Forms.Button();
            this.selectAllBtn = new System.Windows.Forms.Button();
            this.unselectAllBtn = new System.Windows.Forms.Button();
            this.invertSelectionBtn = new System.Windows.Forms.Button();
            this.filesBox = new System.Windows.Forms.CheckedListBox();
            this.acceptBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // directoryL
            // 
            this.directoryL.AutoSize = true;
            this.directoryL.Location = new System.Drawing.Point(12, 9);
            this.directoryL.Name = "directoryL";
            this.directoryL.Size = new System.Drawing.Size(86, 13);
            this.directoryL.TabIndex = 0;
            this.directoryL.Text = "Katalog roboczy:";
            // 
            // directoryTB
            // 
            this.directoryTB.Location = new System.Drawing.Point(104, 6);
            this.directoryTB.Name = "directoryTB";
            this.directoryTB.ReadOnly = true;
            this.directoryTB.Size = new System.Drawing.Size(212, 20);
            this.directoryTB.TabIndex = 1;
            // 
            // dirBtn
            // 
            this.dirBtn.Location = new System.Drawing.Point(322, 4);
            this.dirBtn.Name = "dirBtn";
            this.dirBtn.Size = new System.Drawing.Size(124, 23);
            this.dirBtn.TabIndex = 2;
            this.dirBtn.Text = "Wybierz katalog";
            this.dirBtn.UseVisualStyleBackColor = true;
            // 
            // selectAllBtn
            // 
            this.selectAllBtn.Location = new System.Drawing.Point(12, 38);
            this.selectAllBtn.Name = "selectAllBtn";
            this.selectAllBtn.Size = new System.Drawing.Size(124, 23);
            this.selectAllBtn.TabIndex = 3;
            this.selectAllBtn.Text = "Zaznacz wszystko";
            this.selectAllBtn.UseVisualStyleBackColor = true;
            // 
            // unselectAllBtn
            // 
            this.unselectAllBtn.Location = new System.Drawing.Point(168, 38);
            this.unselectAllBtn.Name = "unselectAllBtn";
            this.unselectAllBtn.Size = new System.Drawing.Size(124, 23);
            this.unselectAllBtn.TabIndex = 4;
            this.unselectAllBtn.Text = "Odznacz wszystko";
            this.unselectAllBtn.UseVisualStyleBackColor = true;
            // 
            // invertSelectionBtn
            // 
            this.invertSelectionBtn.Location = new System.Drawing.Point(322, 38);
            this.invertSelectionBtn.Name = "invertSelectionBtn";
            this.invertSelectionBtn.Size = new System.Drawing.Size(124, 23);
            this.invertSelectionBtn.TabIndex = 5;
            this.invertSelectionBtn.Text = "Odwróć zaznaczenie";
            this.invertSelectionBtn.UseVisualStyleBackColor = true;
            // 
            // filesBox
            // 
            this.filesBox.CheckOnClick = true;
            this.filesBox.FormattingEnabled = true;
            this.filesBox.Location = new System.Drawing.Point(12, 67);
            this.filesBox.Name = "filesBox";
            this.filesBox.Size = new System.Drawing.Size(434, 214);
            this.filesBox.TabIndex = 6;
            // 
            // acceptBtn
            // 
            this.acceptBtn.Location = new System.Drawing.Point(12, 287);
            this.acceptBtn.Name = "acceptBtn";
            this.acceptBtn.Size = new System.Drawing.Size(75, 23);
            this.acceptBtn.TabIndex = 7;
            this.acceptBtn.Text = "OK";
            this.acceptBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(372, 287);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 8;
            this.cancelBtn.Text = "Anuluj";
            this.cancelBtn.UseVisualStyleBackColor = true;
            // 
            // FilesChooserView
            // 
            this.AcceptButton = this.acceptBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(459, 317);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.acceptBtn);
            this.Controls.Add(this.filesBox);
            this.Controls.Add(this.invertSelectionBtn);
            this.Controls.Add(this.unselectAllBtn);
            this.Controls.Add(this.selectAllBtn);
            this.Controls.Add(this.dirBtn);
            this.Controls.Add(this.directoryTB);
            this.Controls.Add(this.directoryL);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilesChooserView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Wybierz pliki";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label directoryL;
        private System.Windows.Forms.TextBox directoryTB;
        private System.Windows.Forms.Button dirBtn;
        private System.Windows.Forms.Button selectAllBtn;
        private System.Windows.Forms.Button unselectAllBtn;
        private System.Windows.Forms.Button invertSelectionBtn;
        private System.Windows.Forms.CheckedListBox filesBox;
        private System.Windows.Forms.Button acceptBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}