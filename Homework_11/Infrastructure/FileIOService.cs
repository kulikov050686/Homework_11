using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace Infrastructure
{
    /// <summary>
    /// Класс загрузки и выгрузки данных из файла
    /// </summary>
    public static class FileIOService<T>
    {
        /// <summary>
        /// Сохранить лист в файл формата JSON
        /// </summary>
        /// <param name="PathFile"> Путь к файлу </param>
        /// <param name="listSave"> Сохраняемый лист </param>
        public static void SaveAsJSON(string PathFile, ObservableCollection<T> listSave)
        {
            using (StreamWriter writer = new StreamWriter(PathFile, false))
            {
                string output = JsonConvert.SerializeObject(listSave, Formatting.Indented);
                writer.Write(output);
            }
        }

        /// <summary>
        /// Загрузить данные в лист из файла формата JSON
        /// </summary>
        /// <param name="PathFile"> Путь к файлу </param>        
        public static ObservableCollection<T> OpenAsJSON(string PathFile)
        {
            var fileExists = File.Exists(PathFile);

            if (!fileExists)
            {
                File.CreateText(PathFile).Dispose();
                return new ObservableCollection<T>();
            }

            using (var reader = File.OpenText(PathFile))
            {
                var fileTaxt = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<ObservableCollection<T>>(fileTaxt);
            }
        }        
    }
}
