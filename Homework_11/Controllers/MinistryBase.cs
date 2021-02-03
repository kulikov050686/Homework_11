using System;
using System.Collections.ObjectModel;
using Models;

namespace Controllers
{
    /// <summary>
    /// Базовый класс Министерство
    /// </summary>
    public abstract class MinistryBase : BaseClassModelINPC
    {
        #region Закрытые поля

        private string _nameMinistry;
        private ObservableCollection<Department> _departments;
        private GeneralDirector _generalDirector;
        private ChiefAccountant _chiefAccountant;
        private DeputyDirector _deputyDirector;

        #endregion

        #region Открытые поля

        /// <summary>
        /// Название министерства
        /// </summary>
        public string NameMinistry
        {
            get => _nameMinistry;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Название министерства не может быть пустым!!!");
                }

                _nameMinistry = value;
            }
        }

        /// <summary>
        /// Список департаментов первого уровня
        /// </summary>
        public ObservableCollection<Department> Departments
        {
            get => _departments;
            set => Set(ref _departments, value); 
        }

        /// <summary>
        /// Генеральный директор
        /// </summary>
        public GeneralDirector GeneralDirector
        {
            get => _generalDirector;
            protected set => Set(ref _generalDirector, value);
        }

        /// <summary>
        /// Главный бухгалтер
        /// </summary>
        public ChiefAccountant ChiefAccountant
        {
            get => _chiefAccountant;
            protected set => Set(ref _chiefAccountant, value);
        }

        /// <summary>
        /// Заместитель генерального директора
        /// </summary>
        public DeputyDirector DeputyDirector
        {
            get => _deputyDirector;
            protected set => Set(ref _deputyDirector, value);
        }

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор министерства
        /// </summary>
        /// <param name="nameMinistry"> Название министерства </param>
        public MinistryBase(string nameMinistry)
        {
            NameMinistry = nameMinistry;           
        }

        #endregion

        #region Открытые методы
        
        /// <summary>
        /// Добавить департамент
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        protected void AddDepartment(string pathToDepartment)
        {
            string ParentDepartment = NameOfCurrentDepartment(pathToDepartment);
            string Path = ParentDepartment;
            pathToDepartment = CutPathFromBeginning(pathToDepartment);

            if (Departments == null)
            {
                if(pathToDepartment.Length == 0)
                {
                    Departments = new ObservableCollection<Department>();                    
                    Departments.Add(new Department(ParentDepartment, Path));
                    return;                    
                }
                else
                {
                    Departments = new ObservableCollection<Department>();
                    Departments.Add(new Department(ParentDepartment, Path));
                }                
            }
            else
            {
                if(pathToDepartment.Length == 0)
                {
                    if (SearchNumber(ParentDepartment) == -1)
                    {
                        Departments.Add(new Department(ParentDepartment, Path));
                        return;                        
                    }

                    return;
                }
                else
                {
                    if (SearchNumber(ParentDepartment) == -1)
                    {
                        Departments.Add(new Department(ParentDepartment, Path));                        
                    }
                }                 
            }

            DepartmentSearchAndAdding(pathToDepartment, Departments[SearchNumber(ParentDepartment)], Path);
        }

        /// <summary>
        /// Добавить департамент
        /// </summary>
        /// <param name="department"> Добавляемый департамент </param>
        /// <param name="pathToParentDepartment"> Путь до родительского департамента </param>        
        protected bool AddDepartment(Department department, string pathToParentDepartment = null)
        {
            if(department != null)
            {
                if (!string.IsNullOrWhiteSpace(pathToParentDepartment))
                {
                    department.Path = pathToParentDepartment + '/' + department.NameDepartment;
                }

                string Path = CutPathFromEnd(department.Path);

                if(Path.Length == 0)
                {
                    if(Departments == null)
                    {
                        Departments = new ObservableCollection<Department>();
                        department.Path = department.NameDepartment;
                        Departments.Add(department);
                        return true;
                    }
                    else
                    {
                        if (SearchNumber(department.NameDepartment) == -1)
                        {
                            department.Path = department.NameDepartment;
                            Departments.Add(department);
                            return true;
                        }                        
                    }
                }
                else
                {
                    Department ParentDepartment = GetDepartment(Path);

                    if (ParentDepartment == null)
                    {
                        AddDepartment(Path);
                        ParentDepartment = GetDepartment(Path);
                        ParentDepartment.NextDepartments = new ObservableCollection<Department>();
                        ParentDepartment.NextDepartments.Add(department);
                        return true;
                    }
                    else
                    {
                        if(ParentDepartment.NextDepartments == null)
                        {
                            ParentDepartment.NextDepartments = new ObservableCollection<Department>();
                            ParentDepartment.NextDepartments.Add(department);
                            return true;
                        }
                        else
                        {
                            if(SearchNumber(department.NameDepartment, ParentDepartment) == -1)
                            {
                                ParentDepartment.NextDepartments.Add(department);
                                return true;
                            }
                        }
                    }
                }               
            }           

            return false;
        }

        /// <summary>
        /// Удалить департамент
        /// </summary>             
        /// <param name="pathToDepartment"> Путь до родительского департамента </param>
        protected bool DeleteDepartment(string pathToDepartment)
        {
            if (Departments != null)
            {
                string ParentDepartment = NameOfCurrentDepartment(pathToDepartment);
                pathToDepartment = CutPathFromBeginning(pathToDepartment);
                int numberDepartments = SearchNumber(ParentDepartment);

                if (pathToDepartment.Length == 0)
                {
                    if (numberDepartments > -1)
                    {                        
                        Departments.RemoveAt(numberDepartments);

                        if(Departments.Count == 0)
                        {
                            Departments = null;
                        }

                        return true;
                    }
                }
                else 
                {
                    if(numberDepartments > -1)
                    {                        
                        return DepartmentSearchAndDelete(pathToDepartment, Departments[numberDepartments]);
                    }
                }
            }            

            return false;
        }

        /// <summary>
        /// Получить дапартамент
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        protected Department GetDepartment(string pathToDepartment)
        {
            string NameDepartment = NameOfCurrentDepartment(pathToDepartment);
            int numberDepartments = SearchNumber(NameDepartment);

            if (numberDepartments > -1)
            {
                if (CutPathFromBeginning(pathToDepartment).Length == 0)
                {
                    return Departments[numberDepartments];
                }
                else
                {
                    return DepartmentSearchAndGet(pathToDepartment, Departments[numberDepartments]);
                }
            }

            return null;
        }

        /// <summary>
        /// Переименовать департамент
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        /// <param name="newNameDepartment"> Новое имя департамента </param>
        protected bool RenameDepartment(string pathToDepartment, string newNameDepartment)
        {
            Department department = GetDepartment(pathToDepartment);

            if (department == null)
            {
                throw new ArgumentNullException("Такого департамента не существует!!!");
            }

            pathToDepartment = CutPathFromEnd(pathToDepartment);

            if(pathToDepartment.Length == 0)
            {
                if(SearchNumber(newNameDepartment) == -1)
                {
                    department.NameDepartment = newNameDepartment;
                    department.Path = newNameDepartment;
                    return true;
                }
            }
            else
            {
                if(SearchNumber(newNameDepartment, GetDepartment(pathToDepartment)) == -1)
                {
                    department.NameDepartment = newNameDepartment;
                    department.Path = pathToDepartment + '/' + newNameDepartment;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Добавить руководителя в департамент
        /// </summary>
        /// <param name="supervisor"> Руководитель департамента </param>
        /// <param name="pathToDepartment"> Путь до депортамента </param>
        protected bool AddSupervisor(Supervisor supervisor, string pathToDepartment)
        {
            if(supervisor != null)
            {
                Department department = GetDepartment(pathToDepartment);

                if (department != null)
                {
                    department.Supervisor = supervisor;
                    return true;
                }
            }           

            return false;
        }

        /// <summary>
        /// Удалить руководителя департамента
        /// </summary>
        /// <param name="pathToDepartment"> Путь до депортамента </param>
        protected bool DeleteSupervisor(string pathToDepartment)
        {
            Department department = GetDepartment(pathToDepartment);

            if (department != null)
            {
                department.Supervisor = null;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Добавить работника в департамент
        /// </summary>
        /// <param name="pathToDepartment"> Путь до депортамента </param>
        /// <param name="worker"> Работник </param>      
        protected bool AddWorker(BaseWorker worker, string pathToDepartment)
        {            
            if (worker != null)
            {
                Department department = GetDepartment(pathToDepartment);

                if(department != null)
                {
                    if (department.Workers == null)
                    {
                        department.Workers = new ObservableCollection<BaseWorker>();
                        department.Workers.Add(worker);
                        return true;
                    }
                    else
                    {
                        department.Workers.Add(worker);
                        return true;
                    }
                }                                               
            }

            return false;
        }

        /// <summary>
        /// Удалить работника из департамента
        /// </summary>
        /// <param name="pathToDepartment"> Путь до депортамента </param>
        /// <param name="worker"> Работник </param>        
        protected bool DeleteWorker(BaseWorker worker, string pathToDepartment)
        {
            if (worker != null)
            {
                Department department = GetDepartment(pathToDepartment);

                if(department != null)
                {
                    if(department.Workers != null)
                    {
                        int numberWorker = -1;

                        for(int i = 0; i < department.CountWorkers; i++)
                        {
                            if(department.Workers[i].Equals(worker))
                            {
                                numberWorker = i;
                            }
                        }

                        if(numberWorker > -1)
                        {
                            department.Workers.RemoveAt(numberWorker);

                            if(department.CountWorkers == 0)
                            {
                                department.Workers = null;
                            }

                            return true;
                        }
                    }
                }                               
            }

            return false;
        }

        /// <summary>
        /// Получить работника по идентификатору
        /// </summary>
        /// <param name="id"> Идентификатор </param>        
        protected BaseWorker GetWorkerById(ulong id)
        {
            if(id > 0)
            {
                if(GeneralDirector != null)
                {
                    if(GeneralDirector.Id == id)
                    {
                        return GeneralDirector;
                    }
                }

                if(ChiefAccountant != null)
                {
                    if(ChiefAccountant.Id == id)
                    {
                        return ChiefAccountant;
                    }
                }

                if(DeputyDirector != null)
                {
                    if(DeputyDirector.Id == id)
                    {
                        return DeputyDirector;
                    }
                }

                if(Departments != null)
                {
                    for(int i = 0; i < Departments.Count; i++)
                    {
                        BaseWorker baseWorker = WorkerSearchByIdAndGetData(Departments[i], id);

                        if(baseWorker != null)
                        {
                            return baseWorker;
                        }
                    }
                }
            }

            return null;
        }
        
        /// <summary>
        /// Получить данные руководителя департамента
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        protected Supervisor GetSupervisorOfDepartment(string pathToDepartment)
        {
            Department department = GetDepartment(pathToDepartment);

            if (department == null)
            {
                throw new ArgumentNullException("Такого департамента не существует!!!");
            }
                        
            return department.Supervisor;
        }

        /// <summary>
        /// Получить список всех работников департамента
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        protected ObservableCollection<BaseWorker> GetWorkersOfDepartment(string pathToDepartment)
        {
            Department department = GetDepartment(pathToDepartment);

            if (department == null)
            {
                throw new ArgumentNullException("Такого департамента не существует!!!");
            }

            return department.Workers;
        }

        /// <summary>
        /// Установить список всех работников департамента
        /// </summary>
        /// <param name="workers"> Лист работников </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        protected bool SetWorkersOfDepartment(ObservableCollection<BaseWorker> workers, string pathToDepartment)
        {
            Department department = GetDepartment(pathToDepartment);

            if (department == null)
            {
                throw new ArgumentNullException("Такого департамента не существует!!!");
            }

            if (workers != null)
            {
                if (department.Workers != null)
                {
                    for (int i = 0; i < workers.Count; i++)
                    {
                        department.Workers.Add(workers[i]);
                    }
                    return true;
                }
                else
                {
                    department.Workers = workers;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Обрезать путь с начала
        /// </summary>
        /// <param name="path"> Путь </param>
        public string CutPathFromBeginning(string path)
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

            if (temp == path.Length)
            {
                return "";
            }

            return path.Substring(++temp);
        }

        /// <summary>
        /// Обрезать путь с конца
        /// </summary>
        /// <param name="path"> Путь </param>        
        public string CutPathFromEnd(string path)
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

        #region Закрытые методы

        /// <summary>
        /// Поиск родительского департамента и добавление поддепартамента
        /// </summary>
        /// <param name="pathToParentDepartment"> Путь до родительского департамента </param>
        /// <param name="nameDepartment"> Название добавляемого поддепартамента </param>
        /// <param name="department"> Родительский департамент </param>        
        private void DepartmentSearchAndAdding(string pathToDepartment, Department department, string path)
        {
            string ParentDepartment = NameOfCurrentDepartment(pathToDepartment);
            path += "/" + ParentDepartment;
            pathToDepartment = CutPathFromBeginning(pathToDepartment);

            if (department.NextDepartments == null)
            {
                if (pathToDepartment.Length == 0)
                {
                    department.NextDepartments = new ObservableCollection<Department>();
                    department.NextDepartments.Add(new Department(ParentDepartment, path));
                }
                else
                {
                    department.NextDepartments = new ObservableCollection<Department>();
                    department.NextDepartments.Add(new Department(ParentDepartment, path));
                    DepartmentSearchAndAdding(pathToDepartment, department.NextDepartments[0], path);
                }
            }
            else
            {
                int numberDepartments = SearchNumber(ParentDepartment, department);

                if (pathToDepartment.Length == 0)
                {
                    if (numberDepartments == -1)
                    {
                        department.NextDepartments.Add(new Department(ParentDepartment, path));
                    }
                }
                else
                {
                    if (numberDepartments == -1)
                    {
                        department.NextDepartments.Add(new Department(ParentDepartment, path));
                        numberDepartments = SearchNumber(ParentDepartment, department);
                        DepartmentSearchAndAdding(pathToDepartment, department.NextDepartments[numberDepartments], path);
                    }
                    else
                    {
                        DepartmentSearchAndAdding(pathToDepartment, department.NextDepartments[numberDepartments], path);
                    }
                }
            }            
        }

        /// <summary>
        /// Поиск родительского департамента и удаление поддепартамента
        /// </summary>
        /// <param name="pathToParentDepartment"> Путь до родительского департамента </param>
        /// <param name="nameDepartment"> Название удаляемого поддепартамента </param>
        /// <param name="department"> Родительский департамент </param>
        private bool DepartmentSearchAndDelete(string pathToDepartment, Department department)
        {
            string NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);
            int numberDepartments = SearchNumber(NameParentDepartment, department);
            pathToDepartment = CutPathFromBeginning(pathToDepartment);

            if (numberDepartments > -1)
            {
                if(pathToDepartment.Length != 0)
                {
                    return DepartmentSearchAndDelete(pathToDepartment, department.NextDepartments[numberDepartments]);
                }
                else
                {
                    if (department.NextDepartments != null)
                    {
                        if (numberDepartments > -1)
                        {
                            department.NextDepartments.RemoveAt(numberDepartments);

                            if(department.NextDepartments.Count == 0)
                            {
                                department.NextDepartments = null;
                            }

                            return true;
                        }
                    }
                }                
            }

            return false;
        }
        
        /// <summary>
        /// Поиск департамента и получение данных о нём
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        /// <param name="department"> Текущий департамент </param>
        private Department DepartmentSearchAndGet(string pathToDepartment, Department department)
        {
            string NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);
            pathToDepartment = CutPathFromBeginning(pathToDepartment);

            if (department.NameDepartment == NameParentDepartment && pathToDepartment.Length == 0)
            {
                return department;
            }

            NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);            
            int numberDepartments = SearchNumber(NameParentDepartment, department);

            if (numberDepartments > -1)
            {
                return DepartmentSearchAndGet(pathToDepartment, department.NextDepartments[numberDepartments]);
            }

            return null;
        }
        
        /// <summary>
        /// Поиск работника по идентификатору
        /// </summary>
        /// <param name="department"></param>
        /// <param name="id"></param>        
        private BaseWorker WorkerSearchByIdAndGetData(Department department, ulong id)
        {
            if (department.NextDepartments == null)
            {
                if(department.Supervisor != null)
                {
                    if(department.Supervisor.Id == id)
                    {
                        return department.Supervisor;
                    }
                }

                for(int i = 0; i < department.CountWorkers; i++)
                {
                    if(department.Workers[i].Id == id)
                    {
                        return department.Workers[i];
                    }
                }
            }
            else 
            {
                for(int i = 0; i < department.CountDepartments; i++)
                {
                    BaseWorker baseWorker = WorkerSearchByIdAndGetData(department.NextDepartments[i], id);

                    if (baseWorker != null)
                    {
                        return baseWorker;
                    }
                }
            }

            return null;
        }
        
        /// <summary>
        /// Название текущего департамента
        /// </summary>
        /// <param name="pathDepartment"> Путь до департамента </param>        
        private string NameOfCurrentDepartment(string pathToParentDepartment)
        {
            string temp = "";

            for (int i = 0; i < pathToParentDepartment.Length; i++)
            {
                if (pathToParentDepartment[i] != '/')
                {
                    temp += pathToParentDepartment[i];
                }
                else
                {
                    break;
                }
            }

            return temp;
        }
        
        /// <summary>
        /// Поиск номера вхождения департамента в основной список
        /// </summary>
        /// <param name="nameDepartment"> Название департамента </param>        
        private int SearchNumber(string nameDepartment)
        {
            for (int i = 0; i < Departments.Count; i++)
            {
                if (Departments[i].NameDepartment == nameDepartment)
                {
                    return i;                   
                }
            }

            return -1;
        }

        /// <summary>
        /// Поиск номера вхождения поддепартамента в департамент
        /// </summary>
        /// <param name="nameDepartment"> Название поддепартамента </param>
        /// <param name="department"> Департамент </param>        
        private int SearchNumber(string nameDepartment, Department department)
        {
            for (int i = 0; i < department.NextDepartments.Count; i++)
            {
                if (department.NextDepartments[i].NameDepartment == nameDepartment)
                {
                    return i;
                }
            }

            return -1;
        }
        
        #endregion
    }
}
