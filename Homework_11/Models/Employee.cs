namespace Models
{
    /// <summary>
    /// Штатный сотрудник
    /// </summary>
    public class Employee : BaseWorker
    {
        /// <summary>
        /// Конструктор штатного сотрудника
        /// </summary>        
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public Employee(string name, string surname, long age, double salary, string jobTitle, string pathToDepartment) : base(name, surname, age, salary, jobTitle, pathToDepartment)
        {
            EmployeePosition = EmployeePosition.Employee;
        }

        /// <summary>
        /// Конструктор штатного сотрудника
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public Employee(ulong id, string name, string surname, long age, double salary, string jobTitle, string pathToDepartment) : base(id, name, surname, age, salary, jobTitle, pathToDepartment)
        {
            EmployeePosition = EmployeePosition.Employee;
        }
    }
}
