using Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Controllers
{
    /// <summary>
    /// Класс Министерство
    /// </summary>
    public class Ministry : MinistryBase
    {
        #region Закрытые поля
               
        const double _minSalary = 1300;
        double _salaryGeneralDirector;
        double _salaryChiefAccountant;
        double _salaryDeputyDirector;        
        double _totalSalary;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор министерства
        /// </summary>
        /// <param name="nameMinistry"> Название министерства </param>
        public Ministry(string nameMinistry) : base(nameMinistry) 
        {
            _salaryGeneralDirector = 0;
            _salaryChiefAccountant = 0;
            _salaryDeputyDirector = 0;
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить департамент
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public new void AddDepartment(string pathToDepartment)
        {
            PathErrorToDepartment(pathToDepartment);
            base.AddDepartment(pathToDepartment);
        }

        /// <summary>
        /// Удалить департамент
        /// </summary>             
        /// <param name="pathToDepartment"> Путь до родительского департамента </param>
        public new bool DeleteDepartment(string pathToDepartment)
        {
            PathErrorToDepartment(pathToDepartment);

            if (base.DeleteDepartment(pathToDepartment))
            {
                pathToDepartment = CutPathFromEnd(pathToDepartment);
                СalculateSalary(pathToDepartment);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Добавить генерального директора
        /// </summary>
        /// <param name="generalDirector"> Генеральный директор </param>
        public void AddGeneralDirector(GeneralDirector generalDirector)
        {
            GeneralDirector = generalDirector;
            СalculateSalary();
        }

        /// <summary>
        /// Удалить генерального директора
        /// </summary>
        public void DeleteGeneralDirector()
        {
            if(GeneralDirector != null)
            {                
                _salaryGeneralDirector = 0;
                GeneralDirector = null;
            }
        }

        /// <summary>
        /// Добавить главного бухгалтера
        /// </summary>
        /// <param name="chiefAccountant"> Главный бухгалтер </param>
        public void AddChiefAccountant(ChiefAccountant chiefAccountant)
        {
            ChiefAccountant = chiefAccountant;
            СalculateSalary();
        }

        /// <summary>
        /// Удалить главного бухгалтера
        /// </summary>
        public void DeleteChiefAccountant()
        {
            if(ChiefAccountant != null)
            {                
                ChiefAccountant = null;
                СalculateSalary();
            }
        }

        /// <summary>
        /// Добавить заместителя директора
        /// </summary>
        /// <param name="deputyDirector"> Заместитель генерального директора </param>
        public void AddDeputyDirector(DeputyDirector deputyDirector)
        {
            DeputyDirector = deputyDirector;
            СalculateSalary();
        }

        /// <summary>
        /// Удалить заместителя генерального директора
        /// </summary>
        public void DeleteDeputyDirector()
        {
            if(DeputyDirector != null)
            {                
                DeputyDirector = null;
                СalculateSalary();
            }
        }
        
        /// <summary>
        /// Добавить руководителя депортамента
        /// </summary>
        /// <param name="supervisor"> Руководитель департамента </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        public bool AddSupervisorDepartment(Supervisor supervisor, string pathToDepartment)
        {
            PathErrorToDepartment(pathToDepartment);

            if (AddDeleteSupervisor(supervisor, pathToDepartment))
            {
                СalculateSalary(pathToDepartment);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удалить руководителя департамента
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public bool DeleteSupervisorDepartment(string pathToDepartment)
        {
            PathErrorToDepartment(pathToDepartment);

            if (AddDeleteSupervisor(null, pathToDepartment))
            {
                СalculateSalary(pathToDepartment);
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// Добавить работника в департамент
        /// </summary>        
        /// <param name="worker"> Работник </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public new bool AddWorker(BaseWorker worker, string pathToDepartment)
        {
            PathErrorToDepartment(pathToDepartment);

            if (base.AddWorker(worker, pathToDepartment))
            {
                СalculateSalary(pathToDepartment);
                return true;
            }

            return false; 
        }

        /// <summary>
        /// Удалить работника из департамента
        /// </summary>
        /// <param name="worker"> Работник </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public new bool DeleteWorker(BaseWorker worker, string pathToDepartment)
        {
            PathErrorToDepartment(pathToDepartment);

            if (base.DeleteWorker(worker, pathToDepartment))
            {                
                СalculateSalary(pathToDepartment);
                return true;
            }

            return false;
        }
        
        /// <summary>
        /// Получить список всех работников министерства
        /// </summary>        
        public ObservableCollection<BaseWorker> GetListOfAllWorkers()
        {
            List<BaseWorker> workers = new List<BaseWorker>();

            if(GeneralDirector != null)
            {
                workers.Add(GeneralDirector);
            }

            if(ChiefAccountant != null)
            {
                workers.Add(ChiefAccountant);
            }

            if(DeputyDirector != null)
            {
                workers.Add(DeputyDirector);
            }

            if(Departments != null)
            {
                List<BaseWorker> temp;

                for(int i = 0; i < Departments.Count; i++)
                {
                    temp = ListOfAllWorkers(Departments[i], Departments[i].NameDepartment);

                    if (temp.Count != 0)
                    {
                        workers.AddRange(temp);
                    }                                        
                }
            }

            if(workers.Count != 0)
            {
                ObservableCollection<BaseWorker> blworkers = new ObservableCollection<BaseWorker>();

                for(int i = 0; i < workers.Count; i++)
                {
                    blworkers.Add(workers[i]);
                }

                return blworkers;
            }

            return null;
        }

        /// <summary>
        /// Установить список всех работников министерства
        /// </summary>
        /// <param name="workers"> Список работников </param>
        public bool SetListOfAllWorkers(ObservableCollection<BaseWorker> workers)
        {
            if(workers != null)
            {
                for(int i = 0; i < workers.Count; i++)
                {
                    if(string.IsNullOrWhiteSpace(workers[i].PathToDepartment))
                    {
                        if(workers[i].EmployeePosition == EmployeePosition.GeneralDirector)
                        {
                            GeneralDirector = new GeneralDirector(workers[i].Id, workers[i].Name, workers[i].Surname, workers[i].Age, workers[i].Salary, workers[i].JobTitle);                            
                        }

                        if(workers[i].EmployeePosition == EmployeePosition.ChiefAccountant)
                        {
                            ChiefAccountant = new ChiefAccountant(workers[i].Id, workers[i].Name, workers[i].Surname, workers[i].Age, workers[i].Salary, workers[i].JobTitle);                            
                        }

                        if(workers[i].EmployeePosition == EmployeePosition.DeputyDirector)
                        {
                            DeputyDirector = new DeputyDirector(workers[i].Id, workers[i].Name, workers[i].Surname, workers[i].Age, workers[i].Salary, workers[i].JobTitle);                            
                        }
                    }
                    else
                    {
                        string pathToDepartment = workers[i].PathToDepartment;
                        AddDepartment(pathToDepartment);

                        if(workers[i].EmployeePosition == EmployeePosition.Intern)
                        {
                            var intern = new Intern(workers[i].Id, workers[i].Name, workers[i].Surname, workers[i].Age, workers[i].Salary, workers[i].JobTitle, pathToDepartment);
                            AddWorker(intern, pathToDepartment);
                        }

                        if(workers[i].EmployeePosition == EmployeePosition.Employee)
                        {
                            var employee = new Employee(workers[i].Id, workers[i].Name, workers[i].Surname, workers[i].Age, workers[i].Salary, workers[i].JobTitle, pathToDepartment);
                            AddWorker(employee, pathToDepartment);
                        }

                        if(workers[i].EmployeePosition == EmployeePosition.Supervisor)
                        {
                            var supervisor = new Supervisor(workers[i].Id, workers[i].Name, workers[i].Surname, workers[i].Age, workers[i].Salary, workers[i].JobTitle, pathToDepartment);
                            AddDeleteSupervisor(supervisor, pathToDepartment);
                        }
                    }
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Получить список всех работников департамента
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        public ObservableCollection<BaseWorker> GetListOfAllWorkersDepartment(string pathToDepartment)
        {
            PathErrorToDepartment(pathToDepartment);
            return GetWorkersOfDepartment(pathToDepartment);
        }

        /// <summary>
        /// Установить список всех работников департамента
        /// </summary>
        /// <param name="workers"> Список работников </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        public bool SetListOfAllWorkersDepartment(ObservableCollection<BaseWorker> workers, string pathToDepartment)
        {
            PathErrorToDepartment(pathToDepartment);

            if (SetWorkersOfDepartment(workers, pathToDepartment))
            {
                СalculateSalary(pathToDepartment);
                return true;
            }

            return false;
        }
        
        #endregion

        #region Закрытые методы

        /// <summary>
        /// Общая заработная плата всех сотрудников департамента и поддепартаментов
        /// </summary>
        /// <param name="department"> Департамент </param>
        /// <param name="key"> Ключ учитывать ли зарплату руководителя </param>        
        private double TotalSalaryOfAllEmployeesDepartment(Department department, bool key)
        {
            double sum = 0;

            for (int j = 0; j < department.CountWorkers; j++)
            {
                sum += department.Workers[j].Salary;
            }

            if (key && department.Supervisor != null)
            {
                sum += department.Supervisor.Salary;
            }

            for (int i = 0; i < department.CountDepartments; i++)
            {
                sum += TotalSalaryOfAllEmployeesDepartment(department.NextDepartments[i], true);
            }

            return sum;
        }

        /// <summary>
        /// Расчитать зарплату руководителя департамента
        /// </summary>
        /// <param name="pathToDepartment"></param>
        /// <param name="minSalary"> Минимальная зарплата заместителя директора </param>        
        /// <param name="coefficient"> Коэффициент </param>
        private void СalculateSalarySupervisors(string pathToDepartment)
        {
            Department department = GetDepartment(pathToDepartment);

            if(department != null)
            {
                double salarySupervisorDepartment = 0.15 * TotalSalaryOfAllEmployeesDepartment(department, false);
                Supervisor supervisor = GetSupervisorOfDepartment(pathToDepartment);

                if (supervisor != null)
                {                    
                    if (salarySupervisorDepartment > _minSalary)
                    {
                        supervisor.Salary = salarySupervisorDepartment;
                    }
                    else
                    {
                        supervisor.Salary = _minSalary;
                    }
                }

                pathToDepartment = CutPathFromEnd(pathToDepartment);

                if (pathToDepartment.Length != 0)
                {
                    СalculateSalarySupervisors(pathToDepartment);
                }
            }            
        }

        /// <summary>
        /// Расчитать суммарную зарплату всех сотрудников министерства
        /// </summary>
        private void СalculateTotalSalary()
        {
            if (Departments != null)
            {
                _totalSalary = 0;

                for (int i = 0; i < Departments.Count; i++)
                {
                    _totalSalary += TotalSalaryOfAllEmployeesDepartment(Departments[i], true);
                }
            }            
        }

        /// <summary>
        /// Расчёт зарплат руководителей
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        private void СalculateSalary(string pathToDepartment = null)
        {
            if(!string.IsNullOrWhiteSpace(pathToDepartment))
            {
                СalculateSalarySupervisors(pathToDepartment);
            }

            СalculateTotalSalary();

            if(DeputyDirector != null)
            {
                _salaryDeputyDirector = 0.15 * _totalSalary;

                if(_salaryDeputyDirector > _minSalary)
                {
                    DeputyDirector.Salary = _salaryDeputyDirector;
                }
                else
                {
                    DeputyDirector.Salary = _minSalary;
                }
            }
            else
            {
                _salaryDeputyDirector = 0;
            }

            if(ChiefAccountant != null)
            {
                _salaryChiefAccountant = 0.15 * _totalSalary;

                if(_salaryChiefAccountant > _minSalary)
                {
                    ChiefAccountant.Salary = _salaryChiefAccountant;
                }
                else
                {
                    ChiefAccountant.Salary = _minSalary;
                }
            }
            else
            {
                _salaryChiefAccountant = 0;
            }
            
            if(GeneralDirector != null)
            {
                _salaryGeneralDirector = 0.15 * (_salaryChiefAccountant + _salaryDeputyDirector + _totalSalary);

                if(_salaryGeneralDirector > _minSalary)
                {
                    GeneralDirector.Salary = _salaryGeneralDirector;
                }
                else
                {
                    GeneralDirector.Salary = _minSalary;
                }
            }
        }

        /// <summary>
        /// Ошибка пути до департамента
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        private void PathErrorToDepartment(string pathToDepartment)
        {
            if (string.IsNullOrWhiteSpace(pathToDepartment))
            {
                throw new ArgumentNullException("Путь до департамента не может быть пустым!!!");
            }
        }

        /// <summary>
        /// Лист всех работников
        /// </summary>
        /// <param name="department"> Департамент </param>
        /// <param name="nameDepartment"> Имя текущего департамента </param>        
        private List<BaseWorker> ListOfAllWorkers(Department department, string nameDepartment)
        {
            List<BaseWorker> workers = new List<BaseWorker>();

            if (department.NextDepartments != null)
            {
                List<BaseWorker> temp;

                for (int i = 0; i < department.CountDepartments; i++)
                {
                    temp = ListOfAllWorkers(department.NextDepartments[i], nameDepartment + "/" + department.NextDepartments[i].NameDepartment);

                    if (temp.Count != 0)
                    {
                        workers.AddRange(temp);
                    }                    
                }

                if (department.Supervisor != null)
                {
                    workers.Add(department.Supervisor);
                }

                if (department.CountWorkers != 0)
                {
                    for (int j = 0; j < department.CountWorkers; j++)
                    {
                        workers.Add(department.Workers[j]);
                    }
                }
            }
            else
            {
                if (department.Supervisor != null)
                {
                    workers.Add(department.Supervisor);
                }

                if (department.CountWorkers != 0)
                {
                    for (int i = 0; i < department.CountWorkers; i++)
                    {
                        workers.Add(department.Workers[i]);
                    }
                }
            }

            return workers;
        }

        #endregion
    }
}
