using Controllers;

namespace ViewModels
{
    public class MainWindowViewModel : BaseClassINPC
    {
        #region Закрытые поля

        Company _company;
        DepartmentViewModel _departmentViewModel;

        #endregion

        #region Открытые поля

        /// <summary>
        /// Название приложения
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Команды
        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindowViewModel()
        {
            Title = "ООО РОГА И КОПЫТА";
            _company = new Company(Title);

            _departmentViewModel = new DepartmentViewModel();
            _departmentViewModel.ListDepartments = _company.Departments;
        }

        #region Открытые методы
        #endregion

        #region Закрытые методы
        #endregion
    }
}
