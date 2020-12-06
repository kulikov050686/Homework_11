using Commands;
using Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels
{
    public enum ArgumentActions
    {
        ADD = 0,
        DELETE = 1
    }        

    public class DepartmentViewModel : BaseClassINPC
    {
        #region Закрытые поля
                
        Department _selectedDepartment;
        ObservableCollection<Department> _listDepartments;
        ICommand _addDepartament;
        ICommand _addNextDepartament;

        #endregion

        #region Событие

        public delegate void MyDelegate(string path, ArgumentActions e);
        public event MyDelegate Notify;

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
        public ObservableCollection<Department> ListDepartments
        {
            get => _listDepartments;
            set => Set(ref _listDepartments, value);
        }
               
        #endregion

        #region Команды        

        /// <summary>
        /// Добавить департамент
        /// </summary>
        public ICommand AddDepartment
        {
            get
            {
                return _addDepartament ?? (_addDepartament = new RelayCommand((obj) => 
                {
                    string path = ShortenPath(SelectedDepartment.Path);

                    if(path.Length == 0)
                    {
                        path = "Департамент_6";
                    }
                    else
                    {
                        path += "/Департамент_5";
                    }

                    Notify?.Invoke(path, ArgumentActions.ADD);
                }, (obj) => (SelectedDepartment != null)));
            }
        }

        /// <summary>
        /// Добавить поддепартамент
        /// </summary>
        public ICommand AddNextDepartment
        {
            get
            {
                return _addNextDepartament ?? (_addNextDepartament = new RelayCommand((obj) => 
                {
                    string path = SelectedDepartment.Path;

                    if(path == SelectedDepartment.NameDepartment)
                    {
                        path += "/Departament_1";
                    }
                    else
                    {
                        path += "/Departament_2";
                    }

                    Notify?.Invoke(path, ArgumentActions.ADD);
                }, (obj) => (SelectedDepartment != null) && (SelectedDepartment.NextDepartments == null)));
            }
        }

        #endregion

        #region Конструкторы

        public DepartmentViewModel()
        {}

        #endregion

        #region Закрытые методы

        /// <summary>
        /// Сократить путь с конца
        /// </summary>
        /// <param name="path"> Путь к родителю </param>
        private string ShortenPath(string path)
        {
            if (path[path.Length - 1] == '/')
            {
                path = path.Substring(0, path.Length - 1);
            }

            int temp = 0;

            for (int i = path.Length - 1; i >= 0; i--)
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

            if (temp == path.Length)
            {
                return "";
            }

            return path.Substring(0, path.Length - (++temp));
        }

        #endregion
    }
}
