using Commands;
using Controllers;
using Models;
using Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace ViewModels
{
    public class DepartmentViewModel : BaseClassINPC
    {
        #region Закрытые поля

        Company _company;
        Department _selectedDepartment;
        ObservableCollection<Department> _listDepartments;        
        GeneralDirector _generalDirector;
        ChiefAccountant _chiefAccountant;
        DeputyDirector _deputyDirector;
        Visibility _visibilityDepartmentСomposition;
        Visibility _visibilityGeneralDirector;
        Visibility _visibilityDeputyDirector;
        Visibility _visibilityChiefAccountant;
        ICommand _addDepartament;
        ICommand _addNextDepartament;
        ICommand _addGeneralDirector;
        ICommand _addChiefAccountant;
        ICommand _addDeputyDirector;
        ICommand _deleteGeneralDirector;
        ICommand _deleteDeputyDirector;
        ICommand _deleteChiefAccountant;
        ICommand _deleteDepartment;

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
            get 
            {
                if(_selectedDepartment == null)
                {
                    VisibilityDepartmentСomposition = Visibility.Hidden;
                }
                else
                {
                    VisibilityDepartmentСomposition = Visibility.Visible;
                }

                return _selectedDepartment; 
            }

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
        public GeneralDirector GeneralDirector
        {
            get 
            { 
                if(_generalDirector == null)
                {
                    VisibilityGeneralDirector = Visibility.Hidden;
                }
                else
                {
                    VisibilityGeneralDirector = Visibility.Visible;
                }

                return _generalDirector; 
            }

            set => Set(ref _generalDirector, value);
        }

        /// <summary>
        /// Главный бухгалтер
        /// </summary>
        public ChiefAccountant ChiefAccountant
        {
            get 
            {
                if(_chiefAccountant == null)
                {
                    VisibilityChiefAccountant = Visibility.Hidden;
                }
                else
                {
                    VisibilityChiefAccountant = Visibility.Visible;
                }

                return _chiefAccountant; 
            }

            set => Set(ref _chiefAccountant, value);
        }

        /// <summary>
        /// Заместитель генеральный директора
        /// </summary>
        public DeputyDirector DeputyDirector
        {
            get 
            {
                if(_deputyDirector == null)
                {
                    VisibilityDeputyDirector = Visibility.Hidden;
                }
                else
                {
                    VisibilityDeputyDirector = Visibility.Visible;
                }

                return _deputyDirector; 
            }

            set => Set(ref _deputyDirector, value);
        }

        /// <summary>
        /// Отображение состава департамента
        /// </summary>
        public Visibility VisibilityDepartmentСomposition
        {
            get => _visibilityDepartmentСomposition;
            set => Set(ref _visibilityDepartmentСomposition, value);
        }

        /// <summary>
        /// Отображение генерального директора
        /// </summary>
        public Visibility VisibilityGeneralDirector
        {
            get => _visibilityGeneralDirector;
            set => Set(ref _visibilityGeneralDirector, value);
        }

        /// <summary>
        /// Отображение заместителя генерального директора
        /// </summary>
        public Visibility VisibilityDeputyDirector
        {
            get => _visibilityDeputyDirector;
            set => Set(ref _visibilityDeputyDirector, value);
        }

        /// <summary>
        /// Отображение главного бухгалтера
        /// </summary>
        public Visibility VisibilityChiefAccountant
        {
            get => _visibilityChiefAccountant;
            set => Set(ref _visibilityChiefAccountant, value);
        }

        #endregion

        #region Команды

        /// <summary>
        /// Добавить генерального директора
        /// </summary>
        public ICommand AddGeneralDirector
        {
            get
            {
                return _addGeneralDirector ?? (_addGeneralDirector = new RelayCommand((obj) => 
                {
                    BaseWorker temp = AddChiefDialog.Show();
                    
                    if(temp != null)
                    {
                        
                    }

                }, (obj) => GeneralDirector == null));
            }
        }

        /// <summary>
        /// Удалить генерального директора
        /// </summary>
        public ICommand DeleteGeneralDirector
        {
            get
            {
                return _deleteGeneralDirector ?? (_deleteGeneralDirector = new RelayCommand((obj) =>
                {
                    if(MessageBox.Show("Удалить генерального директора?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        _company.DeleteGeneralDirector();
                        UpdateData();
                    }
                }, (obj) => GeneralDirector != null));
            }
        }

        /// <summary>
        /// Добавить заместителя генерального директора
        /// </summary>
        public ICommand AddDeputyDirector
        {
            get
            {
                return _addDeputyDirector ?? (_addDeputyDirector = new RelayCommand((obj) => 
                {
                    AddChiefDialog.Show();
                }, (obj) => DeputyDirector == null));
            }
        }

        /// <summary>
        /// Удалить генерального директора
        /// </summary>
        public ICommand DeleteDeputyDirector
        {
            get
            {
                return _deleteDeputyDirector ?? (_deleteDeputyDirector = new RelayCommand((obj) =>
                {
                    if(MessageBox.Show("Удалить заместителя генерального директора?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        _company.DeleteDeputyDirector();
                        UpdateData();
                    }
                }, (obj) => DeputyDirector != null));
            }
        }

        /// <summary>
        /// Добавить главного бухгалтера
        /// </summary>
        public ICommand AddChiefAccountant
        {
            get
            {
                return _addChiefAccountant ?? (_addChiefAccountant = new RelayCommand((obj) => 
                {
                    AddChiefDialog.Show();
                }, (obj) => ChiefAccountant == null));
            }
        }

        /// <summary>
        /// Удалить главного бухгалтера
        /// </summary>
        public ICommand DeleteChiefAccountant
        {
            get
            {
                return _deleteChiefAccountant ?? (_deleteChiefAccountant = new RelayCommand((obj) =>
                {
                    if(MessageBox.Show("Удалить главного бухгалтера?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        _company.DeleteChiefAccountant();
                        UpdateData();
                    }
                }, (obj) => ChiefAccountant != null));
            }
        }

        /// <summary>
        /// Добавить департамент
        /// </summary>
        public ICommand AddDepartment
        {
            get
            {
                return _addDepartament ?? (_addDepartament = new RelayCommand((obj) =>
                {
                    string path = "";

                    if (SelectedDepartment != null)
                    {
                        path = AddDepartmentDialog.Show(ShortenPath(SelectedDepartment.Path));                        
                    }
                    else
                    {
                        path = AddDepartmentDialog.Show(path);                        
                    }

                    if (!string.IsNullOrWhiteSpace(path))
                    {
                        _company.AddDepartment(path);
                        ListDepartments = _company.Departments;
                    }

                }, (obj) => (SelectedDepartment != null) || (ListDepartments == null)));
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

                    path = AddDepartmentDialog.Show(path);

                    if (!string.IsNullOrWhiteSpace(path))
                    {
                        _company.AddDepartment(path);
                        ListDepartments = _company.Departments;                        
                    }

                }, (obj) => (SelectedDepartment != null) && (SelectedDepartment.NextDepartments == null)));
            }
        }

        /// <summary>
        /// Удалить департамент
        /// </summary>
        public ICommand DeleteDepartment
        {
            get
            {
                return _deleteDepartment ?? (_deleteDepartment = new RelayCommand((obj) =>
                {
                    if(MessageBox.Show("Удалить департамент?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        _company.DeleteDepartment(SelectedDepartment.Path);
                        UpdateData();                       
                    }
                }, (obj) => SelectedDepartment != null));
            }
        }

        #endregion

        #region Конструкторы

        public DepartmentViewModel()
        {
            Title = "ООО РОГА И КОПЫТА";
            VisibilityDepartmentСomposition = Visibility.Hidden;
            VisibilityGeneralDirector = Visibility.Hidden;
            VisibilityDeputyDirector = Visibility.Hidden;
            VisibilityChiefAccountant = Visibility.Hidden;
            _company = new Company(Title);

            UpdateData();
        }
        
        #endregion

        #region Закрытые методы

        /// <summary>
        /// Обновить данные
        /// </summary>
        public void UpdateData()
        {
            ListDepartments = _company.Departments;
            GeneralDirector = _company.GetGeneralDirector();
            DeputyDirector = _company.GetDeputyDirector();
            ChiefAccountant = _company.GetChiefAccountant();            
        }

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
