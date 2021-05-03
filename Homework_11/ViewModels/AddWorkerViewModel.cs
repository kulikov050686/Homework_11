using Commands;
using Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace ViewModels
{
    /// <summary>
    /// Модель-Представление окна добавить работника
    /// </summary>
    public class AddWorkerViewModel : BaseClassViewModelINPC
    {
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
        public long WorkerAge { get; set; } = 18;

        /// <summary>
        /// Зарплата
        /// </summary>
        public double WorkerSalary { get; set; } = 500.0;

        /// <summary>
        /// Название должности
        /// </summary>
        public string WorkerJobTitle { get; set; }

        /// <summary>
        /// Нажатая кнопка Add = true, Cancel = false
        /// </summary>
        public bool AddCancel { get; private set; } = false;

        /// <summary>
        /// Статус
        /// </summary>
        public EmployeePosition WorkerEmployeePosition { get; set; } = EmployeePosition.Intern;
        
        /// <summary>
        /// Название статуса
        /// </summary>
        public List<string> StatusWorker { get; set; } = new List<string> { "Интерн", "Штатный сотрудник" };

        #endregion

        #region Команда добавить

        private ICommand _add;
        public ICommand Add
        {
            get => _add ?? (_add = new RelayCommand((obj) =>
            {
                AddCancel = true;                
            }));
        }

        #endregion

        #region Команда отмена

        private ICommand _cancel;
        public ICommand Cancel
        {
            get => _cancel ?? (_cancel = new RelayCommand((obj) =>
            {
                AddCancel = false;                
            }));
        }

        #endregion

        #region Конструктор

        public AddWorkerViewModel()
        {
            AddCancel = false;                    
        }

        #endregion       
    }
}
