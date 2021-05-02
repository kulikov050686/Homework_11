using Commands;
using Controllers;
using System.Windows;
using System.Windows.Input;

namespace ViewModels
{
    /// <summary>
    /// Модель-представление окна выбора департамента
    /// </summary>
    public class LocationSelectionViewModel : BaseClassViewModelINPC
    {
        #region Открытые поля

        /// <summary>
        /// Название окна
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Нажатая кнопка Select = true, Cancel = false
        /// </summary>
        public bool SelectCancel { get; private set; } = false;

        /// <summary>
        /// Путь до выбранного департамента
        /// </summary>
        public string PathToDepartment { get; private set; } = "";

        #endregion

        #region Команда Выбрать

        private ICommand _select;
        public ICommand Select
        {
            get
            {
                return _select ?? (_select = new RelayCommand((obj) =>
                {
                    PathToDepartment = _departmentViewModel.SelectedDepartmentVM.Path;
                    SelectCancel = true;                    
                }, (obj) => _departmentViewModel.SelectedDepartmentVM != null));
            }
        }

        #endregion

        #region Команда Отменить

        private ICommand _cancel;
        public ICommand Cancel
        {
            get
            {
                return _cancel ?? (_cancel = new RelayCommand((obj) =>
                {
                    SelectCancel = false;                    
                }));
            }
        }

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
        public LocationSelectionViewModel(Ministry ministry)
        {            
            _departmentViewModel = new DepartmentViewModel(ministry);
            _departmentViewModel.VisibilityContextMenu = Visibility.Collapsed;
        }
    }
}
