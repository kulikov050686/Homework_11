using BaseClasses;
using Controllers;
using Models;
using System.ComponentModel;

namespace ViewModels
{
    public class MainWindowViewModel : BaseClassINPC
    {
        #region Закрытые поля

        Company _Company;
        BindingList<Department> _ListDepartments;
        Department _SelectedDepartment;

        #endregion

        #region Открытые поля

        /// <summary>
        /// Название приложения
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Лист департаментов
        /// </summary>
        public BindingList<Department> ListDepartments
        {
            get => _ListDepartments;
            set => Set(ref _ListDepartments, value);
        }

        /// <summary>
        /// Выбранный департамент
        /// </summary>
        public Department SelectedDepartment
        {
            get => _SelectedDepartment;
            set => Set(ref _SelectedDepartment, value);
        }

        #endregion

        #region Команды
        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindowViewModel()
        {
            Title = "ООО РОГА И КОПЫТА";
            _Company = new Company(Title);

            _ListDepartments = _Company.Departments;
        }

        #region Открытые методы
        #endregion

        #region Закрытые методы
        #endregion
    }
}
