﻿using Commands;
using Controllers;
using Models;
using Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Collections.Specialized;

namespace ViewModels
{
    /// <summary>
    /// Класс Модели-Представления Департаментов
    /// </summary>
    public class DepartmentViewModel : BaseClassViewModelINPC
    {
        #region Закрытые поля

        Ministry _ministry;
        Department _selectedDepartment;
        ObservableCollection<Department> _departments;

        #endregion

        #region Модель-представление списка работников 
                
        WorkerViewModel _workerViewModel;
        public WorkerViewModel WorkerViewModel
        {
            get => _workerViewModel;
            set => Set(ref _workerViewModel, value);
        }

        #endregion
        
        #region Открытые поля

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

        /// <summary>
        /// Отображение контекстного меню
        /// </summary>
        public Visibility VisibilityContextMenu { get; set; } = Visibility.Visible;

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
                    }
                }, (obj) => (SelectedDepartmentVM != null) || (DepartmentsVM.Count == 0)));
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
                    if(SelectedDepartmentVM.CountDepartments == 0)
                    {
                        if(SelectedDepartmentVM.TotalMan == 0)
                        {
                            if (MessageBox.Show("Удалить департамент?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            {
                                _ministry.DeleteDepartment(SelectedDepartmentVM.Path);                                
                            }
                        }
                        else
                        {
                            MessageBox.Show("Удалить департамент невозможно, так как в департаменте есть сотрудники!", "Внимание!!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Удалить департамент невозможно, так как существуют поддепартаменты!", "Внимание!!!");
                    }                    
                }, (obj) => SelectedDepartmentVM != null));
            }
        }

        #endregion

        #region Команда Переименовать департамент

        private ICommand _renameDepartment;
        public ICommand RenameDepartmentVM
        {
            get
            {
                return _renameDepartment ?? (_renameDepartment = new RelayCommand((obj) => 
                {
                    if (MessageBox.Show("Переименовать департамент?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        string newNameDepartment = RenameDepartmentDialog.Show(SelectedDepartmentVM.NameDepartment);

                        if(!_ministry.RenameDepartment(SelectedDepartmentVM.Path, newNameDepartment))
                        {
                            MessageBox.Show("Департамент переименовать невозможно!!!", "Внимание!!!");
                        }
                    }
                }, (obj) => SelectedDepartmentVM != null));
            }
        }

        #endregion

        #region Команда Переместить департамент

        private ICommand _relocateDepartment;
        public ICommand RelocateDepartment
        {
            get
            {
                return _relocateDepartment ?? (_relocateDepartment = new RelayCommand((obj) =>
                {
                    if (MessageBox.Show("Переместить департамент?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        /// Реализовать функцию перемещения департамента
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
            DepartmentsVM = _ministry.Departments;
            _workerViewModel = new WorkerViewModel(_ministry);
            _ministry.Departments.CollectionChanged += Departments_CollectionChanged;
        }
                
        private void Departments_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {            
            DepartmentsVM = _ministry.Departments;
        }
    }
}
