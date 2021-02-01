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
            set => Set(ref _department, value);            
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
        public ICommand editDataWorker
        {
            get
            {
                return _editDataWorker ?? (_editDataWorker = new RelayCommand((obj) => 
                {
                    if (MessageBox.Show("Редактировать данные работника?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        /// реализовать редактирование данных работника
                    }
                }, (obj) => DepartmentVM != null && SelectedWorkerVM != null));
            }
        }

        #endregion

        #region Команда Переместить работника

        private ICommand _relocateWorker;
        public ICommand RelocateWorker
        {
            get
            {
                return _relocateWorker ?? (_relocateWorker = new RelayCommand((obj) => 
                {
                    if (MessageBox.Show("Переместить работника?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        /// реализовать перемещение работника в другой департамент
                    }
                }, (obj) => DepartmentVM != null && SelectedWorkerVM != null));
            }
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
