using System;
using System.ComponentModel;

namespace Models
{
    /// <summary>
    /// Департамент
    /// </summary>
    public class Department
    {        
        string _nameDepartment;        

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

                _nameDepartment = value;
            }
        }

        /// <summary>
        /// Руководитель депертамента
        /// </summary>
        public Supervisor Supervisor { get; set; }       

        /// <summary>
        /// Лист сотрудников департамента
        /// </summary>
        public BindingList<BaseWorker> Workers { get; set; }

        /// <summary>
        /// Лист поддепартаментов
        /// </summary>
        public BindingList<Department> NextDepartments { get; set; } 
        
        /// <summary>
        /// Количество поддепартаментов в данном департаменте
        /// </summary>
        public int CountDepartments
        {
            get
            {
                if(NextDepartments != null)
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
                if(Workers != null)
                {
                    return Workers.Count;
                }

                return 0;
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
        /// Конструктор департамента
        /// </summary>
        /// <param name="nameDepartment"> Название департамента </param>
        /// <param name="id"> Идентификатор департамента </param>
        public Department(string nameDepartment, string path)
        {
            NameDepartment = nameDepartment;
            Path = path;
        }
    }
}
