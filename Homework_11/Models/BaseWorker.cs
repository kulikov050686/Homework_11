using System;

namespace Models
{
    /// <summary>
    /// Базовый класс работник
    /// </summary>
    public abstract class BaseWorker
    {
        int id;
        string name;
        string surname;
        long age;
        double salary;
        string jobTitle;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id
        { 
            get => id;

            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Невозможный идентификатор!!!");
                }

                id = value;
            } 
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get => name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Имя не может быть пустым!!!");
                }

                name = value;
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname
        {
            get => surname;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Фамилия не может быть пустой!!!");
                }

                surname = value;
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public long Age
        {
            get => age;

            set
            {
                if (value < 18 && value > 99)
                {
                    throw new ArgumentException("Невозможный возраст!!!");
                }

                age = value;
            }
        }

        /// <summary>
        /// Зарплата
        /// </summary>
        public double Salary
        {
            get => salary;

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Невозможная зарплата!!!");
                }

                salary = value;
            }
        }

        /// <summary>
        /// Название должности
        /// </summary>
        public string JobTitle
        {
            get => jobTitle;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Название должности не может быть пустым!!!");
                }

                jobTitle = value;
            }
        }

        /// <summary>
        /// Статус
        /// </summary>
        public EmployeePosition EmployeePosition { get; set; }

        /// <summary>
        /// Конструктор 
        /// </summary>        
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        public BaseWorker(string name, string surname, long age, double salary, string jobTitle)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            JobTitle = jobTitle;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"> Идентификатор </param>
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        public BaseWorker(int id, string name, string surname, long age, double salary, string jobTitle)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            JobTitle = jobTitle;
        }

        /// <summary>
        /// Определяет равны ли объекты друг другу
        /// </summary>        
        public bool Equals(BaseWorker worker)
        {
            if(worker != null)
            {
                return (worker.Id == Id) &&
                       (worker.Name == Name) &&
                       (worker.Surname == Surname) &&
                       (worker.Age == Age) &&
                       (worker.Salary == Salary) &&
                       (worker.JobTitle == JobTitle) &&
                       (worker.EmployeePosition == EmployeePosition);
            }

            return false;
        }
    }
}
