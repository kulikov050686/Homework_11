namespace ViewModels
{
    /// <summary>
    /// Класс Модели-Представления главной страницы
    /// </summary>
    public class MainPageViewModel : BaseClassINPC
    {        
        DepartmentViewModel _departmentViewModel;        

        /// <summary>
        /// Название страницы
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DepartmentViewModel DepartmentViewModel
        {
            get => _departmentViewModel;
            set => Set(ref _departmentViewModel, value);
        }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        public MainPageViewModel()
        {            
            DepartmentViewModel = new DepartmentViewModel();            
        }        
    }
}
