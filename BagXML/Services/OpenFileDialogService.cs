﻿namespace BagXML.Services
{
    /// <summary>представляет сервис открытия диалогового окна проводника Windows для выбора исходного XML файла</summary>
    public sealed class OpenFileDialogService
    {
        private string _initialDirectory = $"C:\\Users\\{Environment.UserName}\\Documents";
        public string FileName { get; private set; } = string.Empty;

        /// <summary>открывает диалоговое окно проводника Windows</summary>
        /// <param name="fileName">имя файла</param>
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

        /// <summary>настраивает диалоговое окно проводника Windows</summary>
        /// <returns>возвращает настроенное диалоговое окно проводника системы</returns>
        private OpenFileDialog ConfigurationFileDialog()
        {
            if(OperatingSystem.IsWindows())
            {
                var fd = new OpenFileDialog();
                fd.Title = "Выбрать XML file";
                fd.DefaultExt = ".xml";
                fd.Filter = "xml|*.xml";
                fd.FilterIndex = 1;
                fd.InitialDirectory = _initialDirectory;
                return fd;
            }

            return null!;
        }
    }
}
