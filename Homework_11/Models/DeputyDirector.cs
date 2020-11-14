namespace Models
{
    /// <summary>
    /// Заместитель генерального директора
    /// </summary>
    public class DeputyDirector : BaseWorker
    {
        /// <summary>
        /// Конструктор Заместителя генерального директора
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        public DeputyDirector(string name, string surname, long age, double salary, string jobTitle) : base(name, surname, age, salary, jobTitle)
        {
            EmployeePosition = EmployeePosition.DeputyDirector;
        }

        /// <summary>
        /// Конструктор Заместителя генерального директора
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        public DeputyDirector(ulong id, string name, string surname, long age, double salary, string jobTitle) : base(id, name, surname, age, salary, jobTitle)
        {
            EmployeePosition = EmployeePosition.DeputyDirector;
        }
    }
}
