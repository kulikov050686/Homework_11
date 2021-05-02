using System;
using System.Collections.ObjectModel;

namespace Models
{
    /// <summary>
    /// Департамент
    /// </summary>
    public class Department : BaseClassModelINPC
    {
        private string _nameDepartment;
        private ObservableCollection<Department> _nextDepartments;
        private ObservableCollection<BaseWorker> _workers;
        private Supervisor _supervisor;

        /// <summary>
        /// Название департамента
        /// </summary>
        public string NameDepartment
        {
            get => _nameDepartment;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Название департамента не может быть пустым!!!");
                }

                Set(ref _nameDepartment, value);
            }
        }

        /// <summary>
        /// Руководитель депертамента
        /// </summary>
        public Supervisor Supervisor
        {
            get => _supervisor;
            set => Set(ref _supervisor, value);
        }

        /// <summary>
        /// Лист сотрудников департамента
        /// </summary>
        public ObservableCollection<BaseWorker> Workers
        {
            get => _workers;
            set => Set(ref _workers, value);
        }

        /// <summary>
        /// Лист поддепартаментов
        /// </summary>
        public ObservableCollection<Department> NextDepartments
        {
            get => _nextDepartments;
            set => Set(ref _nextDepartments, value);
        }

        /// <summary>
        /// Количество поддепартаментов в данном департаменте
        /// </summary>
        public int CountDepartments
        {
            get
            {
                if (NextDepartments != null)
                {
                    return NextDepartments.Count;
                }

                return 0;
            }
        }

        /// <summary>
        /// Количество работников в данном департаменте
        /// </summary>
        public int CountWorkers
        {
            get
            {
                if (Workers != null)
                {
                    return Workers.Count;
                }

                return 0;
            }
        }

        /// <summary>
        /// Всего человек в департаменте
        /// </summary>
        public int TotalMan
        {
            get
            {
                int temp = CountWorkers;

                if (Supervisor != null)
                {
                    temp++;
                }

                return temp;
            }
        }

        /// <summary>
        /// Полный путь до департамента
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Идентификатор департамента
        /// </summary>
        public ulong Id { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="nameDepartment"> Название департамента </param>
        public Department(string nameDepartment)
        {
            NameDepartment = nameDepartment;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="nameDepartment"> Название департамента </param>
        /// <param name="path"> Полный путь до департамента </param>
        public Department(string nameDepartment, string path)
        {
            NameDepartment = nameDepartment;
            Path = path;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор департамента </param>
        /// <param name="nameDepartment"> Имя департамента</param>
        /// <param name="path"> Полный путь до департамента </param>
        public Department(ulong id, string nameDepartment, string path)
        {
            Id = id;
            NameDepartment = nameDepartment;
            Path = path;
        }
    }
}
