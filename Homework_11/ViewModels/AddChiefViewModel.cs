using Commands;
using Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Views;

namespace ViewModels
{
    /// <summary>    
    /// Модель-Представление окна добавить руководителя
    /// </summary>    
    public class AddChiefViewModel : BaseClassINPC
    {
        #region Закрытые поля

        ICommand _add;
        ICommand _cancel;

        #endregion

        #region Открыте свойства

        /// <summary>
        /// Название окна
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string ChiefName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string ChiefSurname { get; set; }

        /// <summary>
        /// Возраст
        /// </summary>
        public long ChiefAge { get; set; }

        /// <summary>
        /// Зарплата
        /// </summary>
        public double ChiefSalary { get; set; }

        /// <summary>
        /// Название должности
        /// </summary>
        public string ChiefJobTitle { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public EmployeePosition ChiefEmployeePosition { get; set; }

        /// <summary>
        /// Нажатая кнопка
        /// </summary>
        public bool YesNo { get; set; }

        /// <summary>
        /// Команда добавить
        /// </summary>
        public ICommand Add
        {
            get => _add ?? (_add = new RelayCommand((obj) =>
            {
                if(!string.IsNullOrWhiteSpace(ChiefName) && 
                   !string.IsNullOrWhiteSpace(ChiefSurname) && 
                   (18 <= ChiefAge && ChiefAge < 99) && 
                   (0 < ChiefSalary))
                {
                    switch(ChiefSelected)
                    {
                        case 0:
                            ChiefEmployeePosition = EmployeePosition.GeneralDirector;
                            ChiefJobTitle = "Генеральный директор";
                            break;
                        case 1:
                            ChiefEmployeePosition = EmployeePosition.DeputyDirector;
                            ChiefJobTitle = "Заместитель генерального директора";
                            break;
                        case 2:
                            ChiefEmployeePosition = EmployeePosition.ChiefAccountant;
                            ChiefJobTitle = "Главный бухгалтер";
                            break;
                        case 3:
                            ChiefEmployeePosition = EmployeePosition.Supervisor;
                            ChiefJobTitle = "Руководитель департамента";
                            break;
                    }

                    YesNo = true;
                    Close();
                }
                else 
                {
                    MessageBox.Show("Ошибка ввода данных!!!");
                }
            }));            
        }

        /// <summary>
        /// Команда отмена
        /// </summary>
        public ICommand Cancel
        {
            get => _cancel ?? (_cancel = new RelayCommand((obj) =>
            {
                YesNo = false;
                Close();
            }));
        }

        /// <summary>
        /// Список руководителей
        /// </summary>
        public List<string> ChiefCollection { get; set; }

        /// <summary>
        /// Номер выбранного руководителя
        /// </summary>
        public int ChiefSelected { get; set; }

        #endregion

        #region Конструктор

        public AddChiefViewModel()
        {
            YesNo = false;            
            ChiefAge = 18;
            ChiefSalary = 1300;

            ChiefCollection = new List<string>()
            {
                "Генеральный директор",
                "Заместитель генерального директора",
                "Главный бухгалтер",
                "Руководитель департамента"
            };

            ChiefSelected = 3;
            ChiefEmployeePosition = EmployeePosition.Supervisor;
        }

        #endregion

        #region Закрытые методы

        /// <summary>
        /// Закрывает окно
        /// </summary>
        private void Close()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is WindowAddChief)
                {
                    window.Close();
                    break;
                }
            }
        }

        #endregion
    }
}
