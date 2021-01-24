using Commands;
using Controllers;
using Models;
using Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ViewModels
{
    /// <summary>
    /// Класс Модели-Представления Департаментов
    /// </summary>
    public class DepartmentViewModel : BaseClassViewModelINPC
    {
        #region Закрытые поля

        WorkerViewModel _workerViewModel;
        Ministry _ministry;
        Department _selectedDepartment;
        ObservableCollection<Department> _departments;

        #endregion

        #region Открытые поля

        /// <summary>
        /// Модель-представление списка работников 
        /// </summary>
        public WorkerViewModel WorkerViewModel
        {
            get => _workerViewModel;
            set => Set(ref _workerViewModel, value);
        }

        /// <summary>
        /// Список департаментов
        /// </summary>
        public ObservableCollection<Department> DepartmentsVM
        {
            get => _departments;
            set => Set(ref _departments, value);
        }

        /// <summary>
        /// Выбранный департамент
        /// </summary>
        public Department SelectedDepartmentVM
        {
            get => _selectedDepartment;

            set 
            { 
                Set(ref _selectedDepartment, value);
                _workerViewModel.DepartmentVM = _selectedDepartment;
            }
        }

        #endregion

        #region Команда Добавить департамент

        private ICommand _addDepartament;
        public ICommand AddDepartmentVM
        {
            get
            {
                return _addDepartament ?? (_addDepartament = new RelayCommand((obj) =>
                {
                    string path = "";

                    if (SelectedDepartmentVM != null)
                    {
                        path = AddDepartmentDialog.Show(_ministry.CutPathFromEnd(SelectedDepartmentVM.Path));
                    }
                    else
                    {
                        path = AddDepartmentDialog.Show(path);
                    }

                    if (!string.IsNullOrWhiteSpace(path))
                    {
                        _ministry.AddDepartment(path);
                        DepartmentsVM = _ministry.Departments;
                    }
                }, (obj) => (SelectedDepartmentVM != null) || (DepartmentsVM == null)));
            }
        }

        #endregion

        #region Команда Добавить поддепартамент

        private ICommand _addNextDepartament;
        public ICommand AddNextDepartmentVM
        {
            get
            {
                return _addNextDepartament ?? (_addNextDepartament = new RelayCommand((obj) =>
                {
                    string path = SelectedDepartmentVM.Path;

                    path = AddDepartmentDialog.Show(path);

                    if (!string.IsNullOrWhiteSpace(path))
                    {
                        _ministry.AddDepartment(path);
                        DepartmentsVM = _ministry.Departments;
                    }

                }, (obj) => (SelectedDepartmentVM != null) && (SelectedDepartmentVM.NextDepartments == null)));
            }
        }

        #endregion

        #region Команда Удалить департамент

        private ICommand _deleteDepartment;        
        public ICommand DeleteDepartmentVM
        {
            get
            {
                return _deleteDepartment ?? (_deleteDepartment = new RelayCommand((obj) =>
                {
                    if (MessageBox.Show("Удалить департамент?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        _ministry.DeleteDepartment(SelectedDepartmentVM.Path);
                        DepartmentsVM = _ministry.Departments;
                    }
                }, (obj) => SelectedDepartmentVM != null));
            }
        }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>        
        public DepartmentViewModel(Ministry ministry)
        {
            _ministry = ministry;
            _workerViewModel = new WorkerViewModel(ministry);
        }
    }
}
