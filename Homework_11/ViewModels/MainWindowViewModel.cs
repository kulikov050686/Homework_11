using DataModels;

namespace ViewModels
{
    /// <summary>
    /// Класс Модели-Представления главного окна
    /// </summary>
    public class MainWindowViewModel : BaseClassINPC
    {
        #region Закрытые поля        
        #endregion

        #region Открытые поля

        /// <summary>
        /// Название приложения
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Страница отображаемая на главном окне
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Main;
   
        #endregion

        #region Команды
        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindowViewModel()
        {
            Title = "ООО РОГА И КОПЫТА";
        }
        
        #region Открытые методы
        #endregion

        #region Закрытые методы
        #endregion
    }
}
