namespace BagXML.Services
{
    public sealed class OpenFileDialogService
    {
        private string _initialDirectory = $"C:\\Users\\{Environment.UserName}\\Documents";
        public string FileName { get; private set; } = string.Empty;

        public void OpenFileDialog(out string fileName)
        {
            using var openFileDialog = ConfigurationFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                return;
            }

            fileName = string.Empty;
        }

        private OpenFileDialog ConfigurationFileDialog()
        {
            var fd = new OpenFileDialog();
            fd.Title = "SorceXML";
            fd.DefaultExt = "source.xml";
            fd.Filter = "xml|*.xml";
            fd.FilterIndex = 1;
            fd.InitialDirectory = _initialDirectory;
            return fd;
        }
    }
}
