using System;
using System.Collections.Generic;

namespace Models
{
    /// <summary>
    /// Департамент
    /// </summary>
    public class Department
    {        
        string nameDepartment;        

        /// <summary>
        /// Название департамента
        /// </summary>
        public string NameDepartment
        { 
            get => nameDepartment;
            
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Название департамента не может быть пустым!!!");
                }

                nameDepartment = value;
            }
        }

        /// <summary>
        /// Руководитель депертамента
        /// </summary>
        public Supervisor Supervisor { get; set; }       

        /// <summary>
        /// Лист сотрудников департамента
        /// </summary>
        public List<BaseWorker> Workers { get; set; }

        /// <summary>
        /// Лист поддепартаментов
        /// </summary>
        public List<Department> NextDepartments { get; set; } 
        
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
        /// Конструктор департамента
        /// </summary>
        /// <param name="nameDepartment"> Название департамента </param>
        /// <param name="id"> Идентификатор департамента </param>
        public Department(string nameDepartment)
        {
            NameDepartment = nameDepartment;                     
        }
    }
}
