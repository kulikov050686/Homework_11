using Models;
using Services;
using System.ComponentModel;

namespace Controllers
{
    /// <summary>
    /// Класс Компания
    /// </summary>
    public class Company : Ministry
    {
        #region Закрытые поля       

        BindingList<Worker> _WorkersList;
        string _Path;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор Компании
        /// </summary>
        /// <param name="nameCompany"> Название Компании </param>
        public Company(string nameCompany) : base(nameCompany)
        {
            _Path = NameMinistry + ".json";
            LoadWorkerListFromFile(_Path);
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить генерального директора
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        public new void AddGeneralDirector(string name, string surname, long age)
        {
            base.AddGeneralDirector(name, surname, age);
            SaveListWorkersToFile(_Path);
        }

        /// <summary>
        /// Удалить генерального директора
        /// </summary>
        public new void DeleteGeneralDirector()
        {
            base.DeleteGeneralDirector();
            SaveListWorkersToFile(_Path);
        }

        /// <summary>
        /// Добавить главного бухгалтера
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        public new void AddChiefAccountant(string name, string surname, long age)
        {
            base.AddChiefAccountant(name, surname, age);
            SaveListWorkersToFile(_Path);
        }

        /// <summary>
        /// Удалить главного бухгалтера
        /// </summary>
        public new void DeleteChiefAccountant()
        {
            base.DeleteChiefAccountant();
            SaveListWorkersToFile(_Path);
        }

        /// <summary>
        /// Добавить заместителя директора
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        public new void AddDeputyDirector(string name, string surname, long age)
        {
            base.AddDeputyDirector(name, surname, age);
            SaveListWorkersToFile(_Path);
        }

        /// <summary>
        /// Удалить заместителя генерального директора
        /// </summary>
        public new void DeleteDeputyDirector()
        {
            base.DeleteDeputyDirector();
            SaveListWorkersToFile(_Path);
        }

        /// <summary>
        /// Добавить руководителя депортамента
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="jobTitle"> Название занимаемой должности </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public new bool AddSupervisorDepartment(string name, string surname, long age, string jobTitle, string pathToDepartment)
        {
            if(base.AddSupervisorDepartment(name, surname, age, jobTitle, pathToDepartment))
            {
                SaveListWorkersToFile(_Path);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удалить руководителя департамента
        /// </summary>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public new bool DeleteSupervisorDepartment(string pathToDepartment)
        {
            if(base.DeleteSupervisorDepartment(pathToDepartment))
            {
                SaveListWorkersToFile(_Path);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Добавить интерна в департамент
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> зарплата </param>
        /// <param name="jobTitle"> Название занимаемой должности </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public new bool AddIntern(string name, string surname, long age, double salary, string jobTitle, string pathToDepartment)
        {
            if(base.AddIntern(name, surname, age, salary, jobTitle, pathToDepartment))
            {
                SaveListWorkersToFile(_Path);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удалить интерна из департамента
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> зарплата </param>
        /// <param name="jobTitle"> Название занимаемой должности </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public new bool DeleteIntern(ulong id, string name, string surname, long age, double salary, string jobTitle, string pathToDepartment)
        {
            if(base.DeleteIntern(id, name, surname, age, salary, jobTitle, pathToDepartment))
            {
                SaveListWorkersToFile(_Path);
                return true;                
            }

            return false;
        }

        /// <summary>
        /// Добавить сотрудника в депортамент
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название занимаемой должности</param>
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        public new bool AddEmployee(string name, string surname, long age, double salary, string jobTitle, string pathToDepartment)
        {
            if(base.AddEmployee(name, surname, age, salary, jobTitle, pathToDepartment))
            {
                SaveListWorkersToFile(_Path);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удалить сотрудника из департамента
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название занимаемой должности</param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public new bool DeleteEmployee(ulong id, string name, string surname, long age, double salary, string jobTitle, string pathToDepartment)
        {
            if(base.DeleteEmployee(id, name, surname, age, salary, jobTitle, pathToDepartment))
            {
                SaveListWorkersToFile(_Path);
                return true;
            }

            return false;
        }

        #endregion

        #region Закрытые методы

        /// <summary>
        /// Сохранить лист работников в файл
        /// </summary>
        /// <param name="paht"> Путь </param>
        private void SaveListWorkersToFile(string paht)
        {
            RefreshListOfWorkers();
            FileIOService.SaveAsJSON(paht, _WorkersList); 
        }

        /// <summary>
        /// Загрузить список работников из файла
        /// </summary>
        /// <param name="path"> Путь </param>
        private void LoadWorkerListFromFile(string path)
        {
            _WorkersList = FileIOService.OpenAsJSON(path);
            SetListOfAllWorkers(_WorkersList);            
        }

        /// <summary>
        /// Обновить список работников компании
        /// </summary>
        private void RefreshListOfWorkers()
        {
            _WorkersList = GetListOfAllWorkers();
        }

        #endregion
    }
}
