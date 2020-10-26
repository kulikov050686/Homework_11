using Models;
using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;

namespace Services
{
    /// <summary>
    /// Класс загрузки и выгрузки данных из файла
    /// </summary>
    public static class FileIOService
    {
        /// <summary>
        /// Сохранить лист в файл формата JSON
        /// </summary>
        /// <param name="PathFile"> Путь к файлу </param>
        /// <param name="listSave"> Сохраняемый лист </param>
        public static void SaveAsJSON(string PathFile, BindingList<Worker> listSave)
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
        public static BindingList<Worker> OpenAsJSON(string PathFile)
        {
            var fileExists = File.Exists(PathFile);

            if (!fileExists)
            {
                File.CreateText(PathFile).Dispose();
                return new BindingList<Worker>();
            }

            using (var reader = File.OpenText(PathFile))
            {
                var fileTaxt = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<Worker>>(fileTaxt);
            }
        }        
    }
}
