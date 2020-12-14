using Commands;
using Models;
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

        #endregion

        #region Конструктор

        public AddChiefViewModel()
        {
            YesNo = false;
            ChiefEmployeePosition = EmployeePosition.Supervisor;
            ChiefAge = 18;
            ChiefSalary = 1300;
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
