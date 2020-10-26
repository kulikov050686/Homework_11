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
        public Supervisor(string name, string surname, long age, double salary, string jobTitle) : base(name, surname, age, salary, jobTitle)
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
        public Supervisor(int id, string name, string surname, long age, double salary, string jobTitle) : base(id, name, surname, age, salary, jobTitle)
        {
            EmployeePosition = EmployeePosition.Supervisor;
        }
    }
}
