using Models;
using System.Windows;
using System.Windows.Input;
using Views;

namespace ViewModels
{
    /// <summary>
    /// Модель-Представление окна добавить работника
    /// </summary>
    public class AddWorkerViewModel : BaseClassINPC
    {
        #region Закрытые поля

        ICommand _add;
        ICommand _cancel;

        #endregion

        #region Открытые поля

        /// <summary>
        /// Название окна
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string WorkerName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string WorkerSurname { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public long WorkerAge { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public double WorkerSalary { get; set; }

        /// <summary>
        /// Название должности
        /// </summary>
        public double WorkerJobTitle { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public EmployeePosition WorkerEmployeePosition { get; set; }

        /// <summary>
        /// Команда добавить
        /// </summary>
        public ICommand Add
        {
            get;
        }

        /// <summary>
        /// Команда отмена
        /// </summary>
        public ICommand Cancel
        {
            get;
        }

        #endregion

        #region Закрытые методы

        /// <summary>
        /// Закрывает окно
        /// </summary>
        private void Close()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is WindowAddWorker)
                {
                    window.Close();
                    break;
                }
            }
        }

        #endregion
    }
}
