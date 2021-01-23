using Commands;
using Models;
using Services;
using System.Collections.ObjectModel;
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
                
        BaseWorker _selectedWorker;
        int _selectedIndex;
        Department _department;
        
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
        /// Номер выбранного работника
        /// </summary>
        public int SelectedIndexVM
        {
            get => _selectedIndex;
            set => Set(ref _selectedIndex, value);
        }

        /// <summary>
        /// Департамент
        /// </summary>
        public Department DepartmentVM
        {
            get => _department;
            set => Set(ref _department, value);            
        }

        #endregion

        #region Команда добавить работника

        private ICommand _addWorker;
        public ICommand AddWorkerVM
        {
            get => _addWorker ?? (_addWorker = new RelayCommand((obj) =>
            {
                BaseWorker tempWorker = AddWorkerDialog.Show();

                if(DepartmentVM.Workers == null && tempWorker != null)
                {
                    DepartmentVM.Workers = new ObservableCollection<BaseWorker>();
                    DepartmentVM.Workers.Add(tempWorker);
                }
                else if(DepartmentVM.Workers != null && tempWorker != null)
                {
                    DepartmentVM.Workers.Add(tempWorker);
                }
            }, (obj) => DepartmentVM != null));
        }

        #endregion

        #region Команда удалить работника
        
        private ICommand _deleteWorker;
        public ICommand DeleteWorkerVM
        {
            get => _deleteWorker ?? (_deleteWorker = new RelayCommand((obj) =>
            {
                if(DepartmentVM.Workers != null)
                {
                    if (MessageBox.Show("Удалить работника?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        DepartmentVM.Workers.RemoveAt(SelectedIndexVM);

                        if (DepartmentVM.CountWorkers == 0)
                        {
                            DepartmentVM.Workers = null;
                        }
                    }
                }
            }, (obj) => DepartmentVM != null));
        }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        public WorkerViewModel()
        {
        }
    }
}
