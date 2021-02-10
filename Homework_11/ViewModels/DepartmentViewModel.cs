using Commands;
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

                        if(newNameDepartment != null  && !_ministry.RenameDepartment(SelectedDepartmentVM.Path, newNameDepartment))
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
        public ICommand RelocateDepartmentVM
        {
            get
            {
                return _relocateDepartment ?? (_relocateDepartment = new RelayCommand((obj) =>
                {
                    if (MessageBox.Show("Переместить департамент?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        string newPath = DepartmentSelectionDialog.Show(_ministry);
                        string oldPath = SelectedDepartmentVM.Path;

                        if (newPath != null)
                        {
                            if (PathAnalysis(newPath, oldPath))
                            {
                                if(_ministry.AddDepartment(SelectedDepartmentVM, newPath))
                                {
                                    _ministry.DeleteDepartment(oldPath);
                                }                                
                            }
                            else
                            {
                                MessageBox.Show("Перемещать НЕЛЬЗЯ!!!");
                            }
                        }
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

        #region Закрытые методы

        /// <summary>
        /// Обработчик события при изменении списка департаментов
        /// </summary>        
        private void Departments_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {            
            DepartmentsVM = _ministry.Departments;
        }

        /// <summary>
        /// Анализ путей
        /// </summary>
        /// <param name="newPath"> Новый путь </param>
        /// <param name="oldPath"> Старый путь </param>        
        private bool PathAnalysis(string newPath, string oldPath)
        {
            if(TrimTail(newPath) != TrimTail(oldPath))
            {
                return true;
            }
            else
            {
                if (newPath != oldPath)
                {
                    newPath = TrimHead(newPath);
                    oldPath = TrimHead(oldPath);

                    if(oldPath.Length == 0 && newPath.Length != 0)
                    {
                        return false;
                    }

                    if(newPath.Length == 0 && oldPath.Length != 0)
                    {
                        return true;
                    }

                    return PathAnalysis(newPath, oldPath);
                }
            }           

            return false;
        }

        /// <summary>
        /// Обрезает путь с хвоста
        /// </summary>
        /// <param name="path"> Путь </param>        
        private string TrimTail(string path)
        {
            if (!string.IsNullOrWhiteSpace(path))
            {
                int temp = 0;

                for (int i = 0; i < path.Length; i++)
                {
                    if (path[i] != '/')
                    {
                        temp++;
                    }
                    else
                    {
                        break;
                    }
                }

                return path.Substring(0, temp);
            }

            return "";
        }

        /// <summary>
        /// Обрезать путь с головы
        /// </summary>
        /// <param name="path"> Путь </param>        
        private string TrimHead(string path)
        {
            if(!string.IsNullOrWhiteSpace(path))
            {
                int k = TrimTail(path).Length + 1;

                if(k <= path.Length)
                {
                    return path.Substring(k, path.Length - k);
                }                
            }

            return "";
        }

        #endregion
    }
}
