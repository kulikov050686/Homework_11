using Controllers;
using Models;
using System;
using System.ComponentModel;

namespace ViewModels
{
    public class MainWindowViewModel : BaseClassINPC
    {
        #region Закрытые поля

        Company _company;
        DepartmentViewModel _departmentViewModel;
        WorkersViewModel _workersViewModel;

        #endregion

        #region Открытые поля

        /// <summary>
        /// Название приложения
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
        /// 
        /// </summary>
        public WorkersViewModel WorkersViewModel
        { 
            get => _workersViewModel; 
            set => Set(ref _workersViewModel, value); 
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
            _company = new Company(Title);

            DepartmentViewModel = new DepartmentViewModel();            
            DepartmentViewModel.ListDepartments = _company.Departments;
            
            WorkersViewModel = new WorkersViewModel();
        }
                
        #region Открытые методы
        #endregion

        #region Закрытые методы
        #endregion
    }
}
