using Newtonsoft.Json;

namespace Models
{
    /// <summary>
    /// Работник
    /// </summary>
    public class Worker
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public long Age { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public double Salary { get; set; }

        /// <summary>
        /// Название занимаемой должности
        /// </summary>
        public string JobTitle { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public EmployeePosition EmployeePosition { get; set; }

        /// <summary>
        /// Путь до департамента
        /// </summary>
        public string PathToDepartment { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="worker"> Работник </param>        
        /// <param name="pathDepartment"> Путь до департамента работника </param>
        public Worker(BaseWorker worker, string pathToDepartment)
        {
            Id = worker.Id;
            Name = worker.Name;
            Surname = worker.Surname;
            Age = worker.Age;
            Salary = worker.Salary;
            JobTitle = worker.JobTitle;
            EmployeePosition = worker.EmployeePosition;
            PathToDepartment = pathToDepartment;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название занимаемой должности </param>
        /// <param name="employeePosition"> Статус </param>
        /// <param name="pathToDepartment"> Путь до департамента работника </param>
        public Worker(string name, string surname, long age, double salary, string jobTitle, EmployeePosition employeePosition, string pathToDepartment)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            JobTitle = jobTitle;
            EmployeePosition = employeePosition;
            PathToDepartment = pathToDepartment;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название занимаемой должности </param>
        /// <param name="employeePosition"> Статус </param>
        /// <param name="pathToDepartment"> Путь до департамента работника </param>
        [JsonConstructor]
        public Worker(int id, string name, string surname, long age, double salary, string jobTitle, EmployeePosition employeePosition, string pathToDepartment) 
        {            
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            JobTitle = jobTitle;
            EmployeePosition = employeePosition;
            PathToDepartment = pathToDepartment;
        }

        /// <summary>
        /// Определяет равны ли объекты друг другу
        /// </summary>
        public bool Equals(Worker worker)
        {
            if(worker != null)
            {
                return (worker.Id == Id) &&
                       (worker.Name == Name) &&
                       (worker.Surname == Surname) &&
                       (worker.Age == Age) &&
                       (worker.Salary == Salary) &&
                       (worker.JobTitle == JobTitle) &&
                       (worker.EmployeePosition == EmployeePosition) && 
                       (worker.PathToDepartment == PathToDepartment);
            }

            return false;
        }
    }
}
