namespace SafeFileTransferBackAndForth
{
    partial class FormSafeFileTransfer
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
            this.textBoxEncryptedFileContent = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonEncrypt = new System.Windows.Forms.Button();
            this.buttonDecrypt = new System.Windows.Forms.Button();
            this.textBoxCryptoKey = new System.Windows.Forms.TextBox();
            this.labelCryptoKey = new System.Windows.Forms.Label();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // textBoxEncryptedFileContent
            // 
            this.textBoxEncryptedFileContent.Location = new System.Drawing.Point(25, 92);
            this.textBoxEncryptedFileContent.Multiline = true;
            this.textBoxEncryptedFileContent.Name = "textBoxEncryptedFileContent";
            this.textBoxEncryptedFileContent.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxEncryptedFileContent.Size = new System.Drawing.Size(750, 334);
            this.textBoxEncryptedFileContent.TabIndex = 2;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // buttonEncrypt
            // 
            this.buttonEncrypt.Enabled = false;
            this.buttonEncrypt.Location = new System.Drawing.Point(25, 25);
            this.buttonEncrypt.Name = "buttonEncrypt";
            this.buttonEncrypt.Size = new System.Drawing.Size(108, 35);
            this.buttonEncrypt.TabIndex = 3;
            this.buttonEncrypt.Text = "Encrypt";
            this.buttonEncrypt.UseVisualStyleBackColor = true;
            this.buttonEncrypt.Click += new System.EventHandler(this.ButtonEncrypt_Click);
            // 
            // buttonDecrypt
            // 
            this.buttonDecrypt.Enabled = false;
            this.buttonDecrypt.Location = new System.Drawing.Point(151, 25);
            this.buttonDecrypt.Name = "buttonDecrypt";
            this.buttonDecrypt.Size = new System.Drawing.Size(118, 35);
            this.buttonDecrypt.TabIndex = 4;
            this.buttonDecrypt.Text = "Decrypt";
            this.buttonDecrypt.UseVisualStyleBackColor = true;
            this.buttonDecrypt.Click += new System.EventHandler(this.ButtonDecrypt_Click);
            // 
            // textBoxCryptoKey
            // 
            this.textBoxCryptoKey.Location = new System.Drawing.Point(503, 38);
            this.textBoxCryptoKey.Name = "textBoxCryptoKey";
            this.textBoxCryptoKey.Size = new System.Drawing.Size(272, 23);
            this.textBoxCryptoKey.TabIndex = 5;
            this.textBoxCryptoKey.TextChanged += new System.EventHandler(this.TextBoxesCryptoKeys_TextChanged);
            // 
            // labelCryptoKey
            // 
            this.labelCryptoKey.AutoSize = true;
            this.labelCryptoKey.Location = new System.Drawing.Point(432, 35);
            this.labelCryptoKey.Name = "labelCryptoKey";
            this.labelCryptoKey.Size = new System.Drawing.Size(65, 15);
            this.labelCryptoKey.TabIndex = 6;
            this.labelCryptoKey.Text = "Crypto Key";
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.UserProfile;
            // 
            // FormSafeFileTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelCryptoKey);
            this.Controls.Add(this.textBoxCryptoKey);
            this.Controls.Add(this.buttonDecrypt);
            this.Controls.Add(this.buttonEncrypt);
            this.Controls.Add(this.textBoxEncryptedFileContent);
            this.Name = "FormSafeFileTransfer";
            this.Text = "Safe File Transfer";
            this.Load += new System.EventHandler(this.FormSafeFileTransfer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxEncryptedFileContent;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button buttonEncrypt;
        private System.Windows.Forms.Button buttonDecrypt;
        private System.Windows.Forms.TextBox textBoxCryptoKey;
        private System.Windows.Forms.Label labelCryptoKey;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    }
}

