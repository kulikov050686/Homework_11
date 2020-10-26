using BaseClasses;
using Controllers;

namespace ViewModels
{
    public class MainWindowViewModel : BaseClassINPC
    {
        #region Закрытые поля

        Company company;

        #endregion

        #region Открытые поля

        /// <summary>
        /// Название приложения
        /// </summary>
        public string Title { get; set; }

        #endregion

        #region Команды
        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindowViewModel()
        {
            Title = "ООО РОГА И КОПЫТА";
            company = new Company(Title);           
        }

        #region Открытые методы
        #endregion

        #region Закрытые методы
        #endregion
    }
}
