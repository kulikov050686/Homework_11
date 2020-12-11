using Commands;
using Controllers;
using Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels
{
    public class DepartmentViewModel : BaseClassINPC
    {
        #region Закрытые поля

        Company _company;
        Department _selectedDepartment;
        ObservableCollection<Department> _listDepartments;
        ICommand _addDepartament;
        ICommand _addNextDepartament;

        #endregion
        
        #region Открытые свойства

        /// <summary>
        /// Название компании
        /// </summary>
        public string Title { get; set; }

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

        /// <summary>
        /// Генеральный директор
        /// </summary>
        public GeneralDirector GeneralDirector { get; set; }

        /// <summary>
        /// Главный бухгалтер
        /// </summary>
        public ChiefAccountant ChiefAccountant { get; set; }

        /// <summary>
        /// Заместитель генеральный директора
        /// </summary>
        public DeputyDirector DeputyDirector { get; set; }
               
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

                    if (path.Length == 0)
                    {
                        path = "Департамент_6";
                    }
                    else
                    {
                        path += "/Департамент_5";
                    }
                    
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
                    
                }, (obj) => (SelectedDepartment != null) && (SelectedDepartment.NextDepartments == null)));
            }
        }

        #endregion

        #region Конструкторы

        public DepartmentViewModel()
        {
            Title = "ООО РОГА И КОПЫТА";
            _company = new Company(Title);
            ListDepartments = _company.Departments;
        }

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
