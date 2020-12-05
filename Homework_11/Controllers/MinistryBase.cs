using System;
using System.ComponentModel;
using Models;

namespace Controllers
{
    /// <summary>
    /// Базовый класс Министерство
    /// </summary>
    public abstract class MinistryBase
    {
        #region Закрытые поля

        private string _nameMinistry;        
        
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
        public BindingList<Department> Departments { get; private set; }

        /// <summary>
        /// Генеральный директор
        /// </summary>
        protected GeneralDirector GeneralDirector { get; set; }

        /// <summary>
        /// Главный бухгалтер
        /// </summary>
        protected ChiefAccountant ChiefAccountant { get; set; }

        /// <summary>
        /// Заместитель генерального директора
        /// </summary>
        protected DeputyDirector DeputyDirector { get; set; }

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
                    Departments = new BindingList<Department>();                    
                    Departments.Add(new Department(ParentDepartment, Path));
                    return;                    
                }
                else
                {
                    Departments = new BindingList<Department>();
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
        /// Добавить или удалить руководителя в департамент
        /// </summary>
        /// <param name="supervisor"> Руководитель департамента </param>
        /// <param name="pathToDepartment"> Путь до депортамента </param>
        protected bool AddDeleteSupervisor(Supervisor supervisor, string pathToDepartment)
        {
            string NameDepartment = NameOfCurrentDepartment(pathToDepartment);
            int numberDepartments = SearchNumber(NameDepartment);

            if (numberDepartments > -1)
            {
                if (CutPathFromBeginning(pathToDepartment).Length == 0)
                {
                    Departments[numberDepartments].Supervisor = supervisor;
                    return true;
                }
                else
                {
                    if (DepartmentSearchAndAddingDeleteSupervisor(pathToDepartment, supervisor, Departments[numberDepartments]))
                    {
                        return true;
                    }
                }
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
                string NameDepartment = NameOfCurrentDepartment(pathToDepartment);
                int numberDepartments = SearchNumber(NameDepartment);

                if (numberDepartments > -1) 
                {
                    if (CutPathFromBeginning(pathToDepartment).Length == 0)
                    {
                        if (Departments[numberDepartments].Workers == null)
                        {
                            Departments[numberDepartments].Workers = new BindingList<BaseWorker>();
                        }

                        Departments[numberDepartments].Workers.Add(worker);
                        return true;
                    }
                    else
                    {
                        if (DepartmentSearchAndAddingWorker(pathToDepartment, worker, Departments[numberDepartments]))
                        {
                            return true;
                        }
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
                string NameDepartment = NameOfCurrentDepartment(pathToDepartment);
                int numberDepartments = SearchNumber(NameDepartment);

                if(numberDepartments > -1)
                {
                    if (CutPathFromBeginning(pathToDepartment).Length == 0)
                    {
                        if (Departments[numberDepartments].Workers != null)
                        {
                            int numberWorker = -1;

                            for (int i = 0; i < Departments[numberDepartments].Workers.Count; i++)
                            {
                                if(Equals(Departments[numberDepartments].Workers[i], worker))
                                {
                                    numberWorker = i;
                                }
                            }

                            if(numberWorker > -1)
                            {
                                Departments[numberDepartments].Workers.RemoveAt(numberWorker);
                                return true;
                            }                            
                        }
                    }
                    else
                    {
                        if (DepartmentSearchAndDeleteWorker(pathToDepartment, worker, Departments[numberDepartments]))
                        {
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
                    BaseWorker baseWorker;

                    for(int i = 0; i < Departments.Count; i++)
                    {
                        baseWorker = WorkerSearchByIdAndGetData(Departments[i], id);

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
        /// Получить данные дапартамента
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
        /// Получить данные руководителя департамента
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        protected Supervisor GetSupervisorOfDepartment(string pathToDepartment)
        {
            string NameDepartment = NameOfCurrentDepartment(pathToDepartment);
            int numberDepartments = SearchNumber(NameDepartment);

            if (numberDepartments > -1)
            {
                if (CutPathFromBeginning(pathToDepartment).Length == 0)
                {
                    return Departments[numberDepartments].Supervisor;
                }
                else
                {
                    return DepartmentSearchAndGetSupervisor(pathToDepartment, Departments[numberDepartments]);
                }
            }

            return null;
        }

        /// <summary>
        /// Получить лист с данными работников департамента
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        protected BindingList<BaseWorker> GetWorkersOfDepartment(string pathToDepartment)
        {
            string NameDepartment = NameOfCurrentDepartment(pathToDepartment);
            int numberDepartments = SearchNumber(NameDepartment);

            if (numberDepartments > -1)
            {
                if (CutPathFromBeginning(pathToDepartment).Length == 0)
                {
                    return Departments[numberDepartments].Workers;
                }
                else
                {
                    return DepartmentSearchAndGetWorkers(pathToDepartment, Departments[numberDepartments]);
                }
            }

            return null;            
        }

        /// <summary>
        /// Обрезать путь с начала
        /// </summary>
        /// <param name="path"> Путь </param>
        protected string CutPathFromBeginning(string path)
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
        protected string CutPathFromEnd(string path)
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

        /// <summary>
        /// Определяет равны ли объекты друг другу
        /// </summary>
        /// <param name="worker_1"> Первый объект </param>
        /// <param name="worker_2"> Второй объект </param>
        public bool Equals(BaseWorker worker_1, BaseWorker worker_2)
        {
            if(worker_1 != null && worker_2 != null)
            {
                return (worker_1.Id == worker_2.Id) && 
                       (worker_1.Name == worker_2.Name) &&
                       (worker_1.Surname == worker_2.Surname) &&
                       (worker_1.Age == worker_2.Age) &&
                       (worker_1.Salary == worker_2.Salary) &&
                       (worker_1.JobTitle == worker_2.JobTitle) &&
                       (worker_1.EmployeePosition == worker_2.EmployeePosition);
            }

            return false;
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
                    department.NextDepartments = new BindingList<Department>();
                    department.NextDepartments.Add(new Department(ParentDepartment, path));
                }
                else
                {
                    department.NextDepartments = new BindingList<Department>();
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
                            return true;
                        }
                    }
                }                
            }

            return false;
        }

        /// <summary>
        /// Поиск департамента и добавление руководителя
        /// </summary>
        /// <param name="pathTotDepartment"> Путь до департамента </param>        
        /// <param name="supervisor"> Руководитель </param>        
        /// <param name="department"> Текущий департамент </param>        
        private bool DepartmentSearchAndAddingDeleteSupervisor(string pathToDepartment, Supervisor supervisor, Department department)
        {
            string NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);
            pathToDepartment = CutPathFromBeginning(pathToDepartment);

            if (department.NameDepartment == NameParentDepartment && pathToDepartment.Length == 0)
            {
                department.Supervisor = supervisor;
                return true;
            }

            NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);            
            int numberDepartments = SearchNumber(NameParentDepartment, department);
            
            if (numberDepartments > -1)
            {
                return DepartmentSearchAndAddingDeleteSupervisor(pathToDepartment, supervisor, department.NextDepartments[numberDepartments]);
            }

            return false;
        }
                
        /// <summary>
        /// Поиск департамента и добавление интерна
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        /// <param name="intern"> Интерн </param>
        /// <param name="department"> Текущий департамент </param>        
        private bool DepartmentSearchAndAddingWorker(string pathToDepartment, BaseWorker worker, Department department)
        {
            string NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);
            pathToDepartment = CutPathFromBeginning(pathToDepartment);

            if (department.NameDepartment == NameParentDepartment && pathToDepartment.Length == 0)
            {
                if(department.Workers == null)
                {
                    department.Workers = new BindingList<BaseWorker>();
                }

                department.Workers.Add(worker);
                return true;
            }

            NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);            
            int numberDepartments = SearchNumber(NameParentDepartment, department);

            if (numberDepartments > -1)
            {
                return DepartmentSearchAndAddingWorker(pathToDepartment, worker, department.NextDepartments[numberDepartments]);
            }

            return false;
        }

        /// <summary>
        /// Поиск департамента и удаление работника
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        /// <param name="worker"> Работник </param>
        /// <param name="department"> Текущий департамент </param>
        private bool DepartmentSearchAndDeleteWorker(string pathToDepartment, BaseWorker worker, Department department)
        {            
            string NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);
            pathToDepartment = CutPathFromBeginning(pathToDepartment);

            if (department.NameDepartment == NameParentDepartment && pathToDepartment.Length == 0)
            {
                if (department.Workers != null)
                {
                    int k = -1;                   

                    for(int i = 0; i < department.Workers.Count; i++)
                    {
                        if(Equals(department.Workers[i], worker))
                        {
                            k = i;                           
                            break;
                        }
                    }

                    if(k > -1)
                    {
                        department.Workers.RemoveAt(k);
                        return true;
                    }                    
                }

                return false;
            }

            NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);
            int numberDepartments = SearchNumber(NameParentDepartment, department);

            if (numberDepartments > -1)
            {
                return DepartmentSearchAndDeleteWorker(pathToDepartment, worker, department.NextDepartments[numberDepartments]);
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
        /// Поиск департамента и получение данных о руководителе
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        /// <param name="department"> Текущий департамент </param>        
        private Supervisor DepartmentSearchAndGetSupervisor(string pathToDepartment, Department department)
        {
            string NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);
            pathToDepartment = CutPathFromBeginning(pathToDepartment);

            if (department.NameDepartment == NameParentDepartment && pathToDepartment.Length == 0)
            {                
                return department.Supervisor;
            }

            NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);
            int numberDepartments = SearchNumber(NameParentDepartment, department);

            if (numberDepartments > -1)
            {
                return DepartmentSearchAndGetSupervisor(pathToDepartment, department.NextDepartments[numberDepartments]);
            }
            
            return null;
        }

        /// <summary>
        /// Поиск департамента и получение данных о работниках
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        /// <param name="department"> Текущий департамент </param>        
        private BindingList<BaseWorker> DepartmentSearchAndGetWorkers(string pathToDepartment, Department department)
        {
            string NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);
            pathToDepartment = CutPathFromBeginning(pathToDepartment);

            if (department.NameDepartment == NameParentDepartment && pathToDepartment.Length == 0)
            {
                return department.Workers;
            }

            NameParentDepartment = NameOfCurrentDepartment(pathToDepartment);
            int numberDepartments = SearchNumber(NameParentDepartment, department);
            
            if (numberDepartments > -1)
            {
                return DepartmentSearchAndGetWorkers(pathToDepartment, department.NextDepartments[numberDepartments]);
            }

            return null;
        }

        /// <summary>
        /// Поиск работника по идентификатору и получение данных 
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
