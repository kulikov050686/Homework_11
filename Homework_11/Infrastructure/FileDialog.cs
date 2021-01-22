using System;
using Microsoft.Win32;
using System.IO;
using System.Collections.ObjectModel;

namespace Infrastructure
{
    /// <summary>
    /// Диалоговые окона для открытия и сохранения файла
    /// </summary>
    public static class FileDialog<T>
    {
        /// <summary>
        /// Путь к файлу
        /// </summary>
        private static string PathFile;

        /// <summary>
        /// Открывает диалоговое окно для сохранения в файл
        /// </summary>
        public static void SaveFileDialog(ObservableCollection<T> listSave)
        {
            SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();

            saveFileDialog.Title = "Сохранить файл";
            saveFileDialog.Filter = "files (*.json)|*.json";
            saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (saveFileDialog.ShowDialog() == true)
            {
                PathFile = saveFileDialog.FileName;   
                
                if (Path.GetExtension(PathFile) == ".json")
                {
                    FileIOService<T>.SaveAsJSON(PathFile, listSave);                    
                }                
            }
        }

        /// <summary>
        /// Открывает диалоговое окно для чтения из файла
        /// </summary>        
        public static ObservableCollection<T> OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();            

            openFileDialog.Title = "Открыть файл";
            openFileDialog.Filter = "files (*.json)|*.json";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (openFileDialog.ShowDialog() == true)
            {
                PathFile = openFileDialog.FileName;

                if (Path.GetExtension(PathFile) == ".json")
                {                    
                    return FileIOService<T>.OpenAsJSON(PathFile);
                }                
            }

            return null;
        }
    }
}
