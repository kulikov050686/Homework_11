using Models;
using System.ComponentModel;

namespace ViewModels
{
    public class DepartmentViewModel : BaseClassINPC
    {
        #region Закрытые поля

        Department _selectedDepartment;
        BindingList<Department> _listDepartments;
        WorkersViewModel _workersViewModel;

        #endregion

        #region Открытые свойства

        /// <summary>
        /// Выбранный департамент
        /// </summary>
        public Department SelectedDepartment
        {
            get => _selectedDepartment;
            set => Set(ref _selectedDepartment, value);
        }

        /// <summary>
        /// Лист департаментов
        /// </summary>
        public BindingList<Department> ListDepartments
        {
            get => _listDepartments;
            set => Set(ref _listDepartments, value);
        }
        
        #endregion

        #region Конструкторы

        public DepartmentViewModel()
        {
            _workersViewModel = new WorkersViewModel();            
        }

        #endregion
    }
}
