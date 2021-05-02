using Commands;
using System.Windows.Input;

namespace ViewModels
{
    /// <summary>
    /// Модель-Представление окна добавить руководителя
    /// </summary>
    public class AddSupervisorViewModel : BaseClassViewModelINPC
    {
        #region Открытые поля

        /// <summary>
        /// Название окна
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string SupervisorName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string SupervisorSurname { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public long SupervisorAge { get; set; } = 18;

        /// <summary>
        /// Зарплата
        /// </summary>
        public double SupervisorSalary { get; set; } = 1300.0;

        /// <summary>
        /// Название должности
        /// </summary>
        public string SupervisorJobTitle { get; set; }

        /// <summary>
        /// Нажатая кнопка Add = true, Cancel = false
        /// </summary>
        public bool AddCancel { get; private set; } = false;

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

        public AddSupervisorViewModel()
        {
            AddCancel = false;
        }

        #endregion        
    }
}
