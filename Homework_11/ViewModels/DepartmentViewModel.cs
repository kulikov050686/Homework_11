using Commands;
using Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ViewModels
{
    public class DepartmentViewModel : BaseClassINPC
    {
        #region Закрытые поля
                
        Department _selectedDepartment;
        BindingList<Department> _listDepartments;        
        ICommand _addNextDepartament;

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

        #region Команды        

        /// <summary>
        /// Добавить поддепартамент
        /// </summary>
        public ICommand AddNextDepartment
        {
            get
            {
                return _addNextDepartament ?? (_addNextDepartament = new RelayCommand((obj) => 
                {
                    MessageBox.Show($"{SelectedDepartment.NameDepartment}");
                }, (obj) => (SelectedDepartment != null)));
            }
        }

        #endregion

        #region Конструкторы

        public DepartmentViewModel()
        {}

        #endregion
    }
}
