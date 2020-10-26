namespace Models
{
    /// <summary>
    /// Генеральный директор
    /// </summary>
    public class GeneralDirector : BaseWorker
    {
        /// <summary>
        /// Конструктор генерального директора
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        public GeneralDirector(string name, string surname, long age, double salary, string jobTitle) : base(name, surname, age, salary, jobTitle)
        {
            EmployeePosition = EmployeePosition.GeneralDirector;
        }

        /// <summary>
        /// Конструктор генерального директора
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        public GeneralDirector(int id, string name, string surname, long age, double salary, string jobTitle) : base(id, name, surname, age, salary, jobTitle)
        {
            EmployeePosition = EmployeePosition.GeneralDirector;
        }
    }
}
