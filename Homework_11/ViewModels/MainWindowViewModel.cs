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
