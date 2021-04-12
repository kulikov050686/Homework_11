using Commands;
using Controllers;
using Models;
using Services;
using System.Windows;
using System.Windows.Input;

namespace ViewModels
{
    /// <summary>
    /// Модель-Представление сотрудников департамента
    /// </summary>
    public class WorkerViewModel : BaseClassViewModelINPC
    {
        #region Закрытые поля

        Ministry _ministry;
        BaseWorker _selectedWorker;        
        Department _department;
        Supervisor _supervisor;
        Visibility _visibilitySupervisorVM = Visibility.Collapsed;

        #endregion

        #region Открытые Свойства

        /// <summary>
        /// Выбранный работник
        /// </summary>
        public BaseWorker SelectedWorkerVM
        {
            get => _selectedWorker;
            set => Set(ref _selectedWorker, value);
        }

        /// <summary>
        /// Департамент
        /// </summary>
        public Department DepartmentVM
        {
            get => _department;
            set 
            {
                Set(ref _department, value);
                SupervisorVM = _department.Supervisor;
            }            
        }

        /// <summary>
        /// Руководитель департамента
        /// </summary>
        public Supervisor SupervisorVM
        {
            get => _supervisor;
            set => Set(ref _supervisor, value);
        }

        /// <summary>
        /// Видимость поля руководителя департамента
        /// </summary>
        public Visibility VisibilitySupervisorVM
        {
            get => _visibilitySupervisorVM;
            set => Set(ref _visibilitySupervisorVM, value);
        }

        #endregion

        #region Команда Добавить работника

        private ICommand _addWorker;
        public ICommand AddWorkerVM
        {
            get => _addWorker ?? (_addWorker = new RelayCommand((obj) =>
            {
                BaseWorker tempWorker = AddWorkerDialog.Show(DepartmentVM.Path);
                string path = DepartmentVM.Path;

                if(tempWorker != null)
                {
                    _ministry.AddWorker(tempWorker, path);                    
                }                
            }, (obj) => DepartmentVM != null));
        }

        #endregion

        #region Команда Удалить работника
        
        private ICommand _deleteWorker;
        public ICommand DeleteWorkerVM
        {
            get => _deleteWorker ?? (_deleteWorker = new RelayCommand((obj) =>
            {
                if (MessageBox.Show("Удалить работника?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    string path = DepartmentVM.Path;
                    _ministry.DeleteWorker(SelectedWorkerVM, path);
                }                
            }, (obj) => DepartmentVM != null && SelectedWorkerVM != null));
        }

        #endregion

        #region Команда Редактировать данные работника

        private ICommand _editDataWorker;
        public ICommand EditDataWorkerVM
        {
            get
            {
                return _editDataWorker ?? (_editDataWorker = new RelayCommand((obj) => 
                {
                    if (MessageBox.Show("Редактировать данные работника?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        BaseWorker tempWorker = EditDataWorkerDialog.Show(SelectedWorkerVM);

                        if(!tempWorker.Equals(SelectedWorkerVM))
                        {
                            if(_ministry.DeleteWorker(SelectedWorkerVM, DepartmentVM.Path))
                            {
                                _ministry.AddWorker(tempWorker, DepartmentVM.Path);
                            }
                        }
                    }
                }, (obj) => DepartmentVM != null && SelectedWorkerVM != null));
            }
        }

        #endregion

        #region Команда Переместить работника

        private ICommand _relocateWorker;
        public ICommand RelocateWorkerVM
        {
            get
            {
                return _relocateWorker ?? (_relocateWorker = new RelayCommand((obj) => 
                {
                    if (MessageBox.Show("Переместить работника?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        string newPath = DepartmentSelectionDialog.Show(_ministry);

                        if(newPath != null)
                        {
                            BaseWorker worker = SelectedWorkerVM;
                            
                            if(_ministry.AddWorker(SelectedWorkerVM, newPath))
                            {
                                _ministry.DeleteWorker(worker, DepartmentVM.Path);
                            }
                        }
                    }
                }, (obj) => DepartmentVM != null && SelectedWorkerVM != null));
            }
        }

        #endregion

        #region Команда Добавить руководителя

        private ICommand _addSupervisor;
        public ICommand AddSupervisorVM
        {
            get => _addSupervisor ?? (_addSupervisor = new RelayCommand((obj) =>
            {
                Supervisor supervisor = (Supervisor)AddSupervisorDialog.Show(EmployeePosition.Supervisor, DepartmentVM.Path);

                if(supervisor != null)
                {
                    _ministry.AddSupervisorDepartment(supervisor, DepartmentVM.Path);
                    SupervisorVM = DepartmentVM.Supervisor;
                    VisibilitySupervisorVM = Visibility.Visible;
                }
            }, (obj) => DepartmentVM != null && SupervisorVM == null));
        }

        #endregion

        #region Команда Удалить руководителя

        private ICommand _deleteSupervisor;
        public ICommand DeleteSupervisorVM
        {
            get => _deleteSupervisor ?? (_deleteSupervisor = new RelayCommand((obj) =>
            {
                _ministry.DeleteSupervisorDepartment(DepartmentVM.Path);
                SupervisorVM = DepartmentVM.Supervisor;
                VisibilitySupervisorVM = Visibility.Collapsed;
            }, (obj) => SupervisorVM != null));
        }

        #endregion

        #region Команда Редактировать данные руководителя

        private ICommand _editDataSupervisor;
        public ICommand EditDataSupervisorVM
        {
            get => _editDataSupervisor ?? (_editDataSupervisor = new RelayCommand((obj) =>
            {
                if (MessageBox.Show("Редактировать данные руководителя?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Supervisor tempSupervisor = EditDataSupervisorDialog.Show(SupervisorVM);

                    if(!tempSupervisor.Equals(SupervisorVM))
                    {
                        if(_ministry.DeleteSupervisorDepartment(SupervisorVM.PathToDepartment))
                        {
                            _ministry.AddSupervisorDepartment(tempSupervisor, DepartmentVM.Path);
                        }
                    }
                }
            }, (obj) => SupervisorVM != null));
        }

        #endregion

        #region Команда Переместить руководителя

        private ICommand _relocateSupervisor;
        public ICommand RelocateSupervisorVM
        {
            get => _relocateSupervisor ?? (_relocateSupervisor = new RelayCommand((obj) =>
            {
                ///
            }, (obj) => SupervisorVM != null));
        }

        #endregion
        
        /// <summary>
        /// Конструктор
        /// </summary>
        public WorkerViewModel(Ministry ministry)
        {
            _ministry = ministry;            
        }
    }
}
