using System;
using System.Windows.Forms;

namespace PunchClub_Encryption
{
    public partial class Application : Form
    {
        private const string EncryptFilter = "Encrypt Files (.dat)|*.dat|All Files (*.*)|*.*";
        private const string DecryptFilter = "Decrypt Files (.txt)|*.txt|All Files (*.*)|*.*";

        public Application()
        {
            InitializeComponent();
        }

        private void buttonDecrypt_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var saveFileDialog = new SaveFileDialog();

            openFileDialog.Filter = EncryptFilter;
            openFileDialog.FilterIndex = 1;
            saveFileDialog.Filter = DecryptFilter;
            saveFileDialog.FilterIndex = 1;

            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() != DialogResult.OK || saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            PunchCubSaveGame.Decrypt(openFileDialog.FileName, saveFileDialog.FileName);
        }

        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var saveFileDialog = new SaveFileDialog();

            openFileDialog.Filter = DecryptFilter;
            openFileDialog.FilterIndex = 1;
            saveFileDialog.Filter = EncryptFilter;
            saveFileDialog.FilterIndex = 1;

            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() != DialogResult.OK || saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            PunchCubSaveGame.Encrypt(openFileDialog.FileName, saveFileDialog.FileName);
        }
    }
}
