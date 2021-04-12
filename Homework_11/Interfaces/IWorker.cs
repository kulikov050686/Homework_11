using Models;

namespace Interfaces
{
    interface IWorker
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public ulong Id { get; set;}

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
        /// Название должности
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
    }
}
