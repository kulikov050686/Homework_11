namespace Models
{
    /// <summary>
    /// Руководитель
    /// </summary>
    public class Supervisor : BaseWorker
    {
        /// <summary>
        /// Конструктор руководителя
        /// </summary>        
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        public Supervisor(string name, string surname, long age, double salary, string jobTitle, string pathToDepartment) : base(name, surname, age, salary, jobTitle, pathToDepartment)
        {
            EmployeePosition = EmployeePosition.Supervisor;
        }

        /// <summary>
        /// Конструктор руководителя
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        public Supervisor(ulong id, string name, string surname, long age, double salary, string jobTitle, string pathToDepartment) : base(id, name, surname, age, salary, jobTitle, pathToDepartment)
        {
            EmployeePosition = EmployeePosition.Supervisor;
        }
    }
}
