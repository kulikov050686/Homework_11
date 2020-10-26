namespace Models
{
    /// <summary>
    /// Главный бухгалтер
    /// </summary>
    public class ChiefAccountant : BaseWorker
    {
        /// <summary>
        /// Конструктор Главного бухгалтера
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        public ChiefAccountant(string name, string surname, long age, double salary, string jobTitle) : base(name, surname, age, salary, jobTitle)
        {
            EmployeePosition = EmployeePosition.ChiefAccountant;
        }

        /// <summary>
        /// Конструктор Главного бухгалтера
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        public ChiefAccountant(int id, string name, string surname, long age, double salary, string jobTitle) : base(id, name, surname, age, salary, jobTitle)
        {
            EmployeePosition = EmployeePosition.ChiefAccountant;
        }
    }
}
