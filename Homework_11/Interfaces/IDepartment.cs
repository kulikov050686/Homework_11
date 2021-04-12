using System.Collections.ObjectModel;

namespace Interfaces
{
    interface IDepartment
    {
        /// <summary>
        /// Название департамента
        /// </summary>
        public string NameDepartment { get; set; }

        /// <summary>
        /// Идентификатор департамента
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// Полный путь до департамента
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Руководитель депертамента
        /// </summary>
        public IWorker Supervisor { get; set; }

        /// <summary>
        /// Лист сотрудников департамента
        /// </summary>
        public ObservableCollection<IWorker> Workers { get; set; }

        /// <summary>
        /// Лист поддепартаментов
        /// </summary>
        public ObservableCollection<IDepartment> NextDepartments { get; set; }
    }
}
