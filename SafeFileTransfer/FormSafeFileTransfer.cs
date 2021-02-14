using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SafeFileTransferBackAndForth
{
    public partial class FormSafeFileTransfer : Form
    {
        public FormSafeFileTransfer()
        {
            InitializeComponent();
        }

        private void FormSafeFileTransfer_Load(object sender, EventArgs e)
        {
            this.textBoxCryptoKey.MaxLength = CryptoHelper.lengthOfInitializationVector + CryptoHelper.lengthOfKey;
        }

        private void ButtonEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                DisableEligibleButtons();
                DisableEligibleTextBoxes();

                if (this.openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = this.openFileDialog.FileName;
                    byte[] fileBytes = File.ReadAllBytes(fileName);

                    FileEntry fileEntry = new FileEntry
                    {
                        FileName = Path.GetFileName(this.openFileDialog.FileName),
                        FileSize = fileBytes.LongLength,
                        FileContent = fileBytes
                    };

                    IFormatter formatter = new BinaryFormatter();
                    using MemoryStream streamSerialization = new MemoryStream();

                    formatter.Serialize(streamSerialization, fileEntry);
                    byte[] compressedData = ZipHelper.ZipUp(streamSerialization, this.textBoxCryptoKey.Text);
                    streamSerialization.Close();

                    byte[] encryptedData = CryptoHelper.Encrypt(compressedData, this.textBoxCryptoKey.Text.Substring(0, CryptoHelper.lengthOfInitializationVector), this.textBoxCryptoKey.Text[CryptoHelper.lengthOfInitializationVector..]);

                    this.textBoxEncryptedFileContent.Text = EncodingHelper.Encode(encryptedData);
                }
            }
            finally
            {
                EnableEligibleButtons();
                EnableEligibleTextBoxes();
            }
        }

        private void ButtonDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                DisableEligibleButtons();
                DisableEligibleTextBoxes();

                byte[] encrodedData = EncodingHelper.Decode(this.textBoxEncryptedFileContent.Text);

                var zippedData = CryptoHelper.Decrypt(encrodedData, this.textBoxCryptoKey.Text.Substring(0, CryptoHelper.lengthOfInitializationVector), this.textBoxCryptoKey.Text[CryptoHelper.lengthOfInitializationVector..]);

                var serializedData = ZipHelper.UnZip(new MemoryStream(zippedData), this.textBoxCryptoKey.Text);

                IFormatter formatter = new BinaryFormatter();
                using MemoryStream streamSerialization = new MemoryStream(serializedData);

                FileEntry fileEntry = formatter.Deserialize(streamSerialization) as FileEntry;

                if (fileEntry.FileSize != fileEntry.FileContent.LongLength)
                {
                    MessageBox.Show($"Error for file {fileEntry.FileName}: sizes do not match - expected={fileEntry.FileSize}, actual={fileEntry.FileContent.LongLength}");
                }
                else if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileNameSaved = this.folderBrowserDialog.SelectedPath + Path.DirectorySeparatorChar + fileEntry.FileName;
                    File.WriteAllBytes(fileNameSaved, fileEntry.FileContent);
                    MessageBox.Show($"File saved: {fileNameSaved}");
                }
            }
            finally
            {
                EnableEligibleButtons();
                EnableEligibleTextBoxes();
            }
        }

        private void TextBoxesCryptoKeys_TextChanged(object sender, EventArgs e) =>
            EnableEligibleButtons();

        private void EnableEligibleButtons()
        {
            bool enabled = this.textBoxCryptoKey.Text.Length == this.textBoxCryptoKey.MaxLength;

            this.buttonEncrypt.Enabled = enabled;
            this.buttonDecrypt.Enabled = enabled && !string.IsNullOrWhiteSpace(this.textBoxEncryptedFileContent.Text);
        }

        private void DisableEligibleButtons()
        {
            this.buttonEncrypt.Enabled = false;
            this.buttonDecrypt.Enabled = false;
        }

        private void EnableEligibleTextBoxes()
        {
            this.textBoxCryptoKey.Enabled = true;
            this.textBoxEncryptedFileContent.Enabled = true;
        }

        private void DisableEligibleTextBoxes()
        {
            this.textBoxCryptoKey.Enabled = false;
            this.textBoxEncryptedFileContent.Enabled = false;
        }
    }
}
