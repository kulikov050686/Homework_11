using Models;
using Services;
using System.Collections.ObjectModel;

namespace Controllers
{
    /// <summary>
    /// Класс Компания
    /// </summary>
    public class Company : Ministry
    {
        #region Закрытые поля       

        ObservableCollection<Worker> _workersList;
        string _path;

        #endregion

        #region Конструктор

        /// <summary>
        /// Конструктор Компании
        /// </summary>
        /// <param name="nameCompany"> Название Компании </param>
        public Company(string nameCompany) : base(nameCompany)
        {
            _path = NameMinistry + ".json";
            LoadWorkerListFromFile(_path);
        }

        #endregion

        #region Открытые методы

        /// <summary>
        /// Добавить генерального директора
        /// </summary>
        /// <param name="generalDirector"> Генеральный директор </param>
        public new void AddGeneralDirector(GeneralDirector generalDirector)
        {
            base.AddGeneralDirector(generalDirector);
            SaveListWorkersToFile(_path);
        }

        /// <summary>
        /// Удалить генерального директора
        /// </summary>
        public new void DeleteGeneralDirector()
        {
            base.DeleteGeneralDirector();
            SaveListWorkersToFile(_path);
        }

        /// <summary>
        /// Добавить главного бухгалтера
        /// </summary>
        /// <param name="chiefAccountant"> Главный бухгалтер </param>
        public new void AddChiefAccountant(ChiefAccountant chiefAccountant)
        {
            base.AddChiefAccountant(chiefAccountant);
            SaveListWorkersToFile(_path);
        }

        /// <summary>
        /// Удалить главного бухгалтера
        /// </summary>
        public new void DeleteChiefAccountant()
        {
            base.DeleteChiefAccountant();
            SaveListWorkersToFile(_path);
        }

        /// <summary>
        /// Добавить заместителя директора
        /// </summary>        
        /// <param name="deputyDirector"> Заместитель генерального директора </param>
        public new void AddDeputyDirector(DeputyDirector deputyDirector)
        {
            base.AddDeputyDirector(deputyDirector);
            SaveListWorkersToFile(_path);
        }

        /// <summary>
        /// Удалить заместителя генерального директора
        /// </summary>
        public new void DeleteDeputyDirector()
        {
            base.DeleteDeputyDirector();
            SaveListWorkersToFile(_path);
        }

        /// <summary>
        /// Добавить руководителя депортамента
        /// </summary>
        /// <param name="supervisor"> Руководитель департамента </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        public new bool AddSupervisorDepartment(Supervisor supervisor, string pathToDepartment)
        {
            if(base.AddSupervisorDepartment(supervisor, pathToDepartment))
            {
                SaveListWorkersToFile(_path);
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
                SaveListWorkersToFile(_path);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Добавить интерна в департамент
        /// </summary>
        /// <param name="intern"> Интерн </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public new bool AddIntern(Intern intern, string pathToDepartment)
        {
            if(base.AddIntern(intern, pathToDepartment))
            {
                SaveListWorkersToFile(_path);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удалить интерна из департамента
        /// </summary>
        /// <param name="intern"> Интерн </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public new bool DeleteIntern(Intern intern, string pathToDepartment)
        {
            if(base.DeleteIntern(intern, pathToDepartment))
            {
                SaveListWorkersToFile(_path);
                return true;                
            }

            return false;
        }

        /// <summary>
        /// Добавить сотрудника в депортамент
        /// </summary>
        /// <param name="employee"> Сотрудник </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>        
        public new bool AddEmployee(Employee employee, string pathToDepartment)
        {
            if(base.AddEmployee(employee, pathToDepartment))
            {
                SaveListWorkersToFile(_path);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Удалить сотрудника из департамента
        /// </summary>
        /// <param name="employee"> Сотрудник </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public new bool DeleteEmployee(Employee employee, string pathToDepartment)
        {
            if(base.DeleteEmployee(employee, pathToDepartment))
            {
                SaveListWorkersToFile(_path);
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
            FileIOService.SaveAsJSON(paht, _workersList); 
        }

        /// <summary>
        /// Загрузить список работников из файла
        /// </summary>
        /// <param name="path"> Путь </param>
        private void LoadWorkerListFromFile(string path)
        {
            _workersList = FileIOService.OpenAsJSON(path);
            SetListOfAllWorkers(_workersList);            
        }

        /// <summary>
        /// Обновить список работников компании
        /// </summary>
        private void RefreshListOfWorkers()
        {
            _workersList = GetListOfAllWorkers();
        }

        #endregion
    }
}
