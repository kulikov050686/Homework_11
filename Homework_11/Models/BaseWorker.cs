using System;
using System.Text.Json.Serialization;
using Interfaces;

namespace Models
{
    /// <summary>
    /// Базовый класс работник
    /// </summary>
    public class BaseWorker :  BaseClassModelINPC, IWorker
    {
        ulong _id;
        string _name;
        string _surname;
        long _age;
        double _salary;
        string _jobTitle;
        EmployeePosition _employeePosition;
        string _pathToDepartment;

        /// <summary>
        /// Идентификатор
        /// </summary>
        public ulong Id
        {
            get => _id;
            set => Set(ref _id, value);
        }        

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        {
            get => _name;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Имя не может быть пустым!!!");
                }

                Set(ref _name, value);
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string Surname
        {
            get => _surname;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Фамилия не может быть пустой!!!");
                }

                Set(ref _surname, value);
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public long Age
        {
            get => _age;

            set
            {
                if (value < 18 && value > 99)
                {
                    throw new ArgumentException("Невозможный возраст!!!");
                }

                Set(ref _age, value);
            }
        }

        /// <summary>
        /// Зарплата
        /// </summary>
        public double Salary
        {
            get => _salary;

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Невозможная зарплата!!!");
                }

                Set(ref _salary, value);
            }
        }

        /// <summary>
        /// Название должности
        /// </summary>
        public string JobTitle
        {
            get => _jobTitle;

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Название должности не может быть пустым!!!");
                }

                Set(ref _jobTitle, value);
            }
        }

        /// <summary>
        /// Статус
        /// </summary>
        public EmployeePosition EmployeePosition
        {
            get => _employeePosition;
            set => Set(ref _employeePosition, value); 
        }

        /// <summary>
        /// Путь до департамента
        /// </summary>
        public string PathToDepartment
        {
            get => _pathToDepartment;
            set => Set(ref _pathToDepartment, value);
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseWorker()
        {}

        /// <summary>
        /// Конструктор 
        /// </summary>        
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public BaseWorker(string name, string surname, long age, double salary, string jobTitle, string pathToDepartment)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            JobTitle = jobTitle;
            PathToDepartment = pathToDepartment;
        }

        /// <summary>
        /// Конструктор 
        /// </summary>        
        /// <param name="name"> Имя </param>
        /// <param name="surname"> Фамилия </param>
        /// <param name="age"> Возраст </param>
        /// <param name="salary"> Зарплата </param>
        /// <param name="jobTitle"> Название должности </param>
        /// <param name="employeePosition"> Статус работника </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public BaseWorker(string name, string surname, long age, double salary, string jobTitle, EmployeePosition employeePosition, string pathToDepartment)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            JobTitle = jobTitle;
            EmployeePosition = employeePosition;
            PathToDepartment = pathToDepartment;
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
        /// <param name="pathToDepartment"> Путь до департамента </param>
        public BaseWorker(ulong id, string name, string surname, long age, double salary, string jobTitle, string pathToDepartment)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            JobTitle = jobTitle;
            PathToDepartment = pathToDepartment;
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
        /// <param name="employeePosition"> Статус работника </param>
        /// <param name="pathToDepartment"> Путь до департамента </param>
        [JsonConstructor]
        public BaseWorker(ulong id, string name, string surname, long age, double salary, string jobTitle, EmployeePosition employeePosition, string pathToDepartment)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            JobTitle = jobTitle;
            EmployeePosition = employeePosition;
            PathToDepartment = pathToDepartment;
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
                       (worker.EmployeePosition == EmployeePosition) &&
                       (worker.PathToDepartment == PathToDepartment);
            }

            return false;
        }
    }
}
