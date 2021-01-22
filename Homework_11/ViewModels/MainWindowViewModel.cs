using Controllers;

namespace ViewModels
{
    /// <summary>
    /// Класс Модели-Представления главного окна
    /// </summary>
    public class MainWindowViewModel : BaseClassViewModelINPC
    {
        #region Закрытые поля

        private Ministry _ministry;        

        #endregion

        #region Открытые поля

        /// <summary>
        /// Название приложения
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Модель-представление контрола отображения департаментов

        private DepartmentViewModel _departmentViewModel;        
        public DepartmentViewModel DepartmentViewModel
        {
            get => _departmentViewModel;
            set => Set(ref _departmentViewModel, value);
        }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindowViewModel()
        {
            Title = "ООО РОГА И КОПЫТА";
            _ministry = new Ministry(Title);

            _departmentViewModel = new DepartmentViewModel(_ministry);
        }       
    }
}
