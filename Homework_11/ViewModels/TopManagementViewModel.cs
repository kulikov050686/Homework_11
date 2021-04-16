using Controllers;
using Models;

namespace ViewModels
{
    /// <summary>
    /// Модель-Представление том менеджмента
    /// </summary>
    public class TopManagementViewModel : BaseClassViewModelINPC
    {
        #region Закрытые поля

        Ministry _ministry;

        #endregion

        #region Генеральный директор

        private GeneralDirector _generalDirector;
        public GeneralDirector GeneralDirector
        {
            get => _generalDirector;
            set => Set(ref _generalDirector, value);
        }

        #endregion

        #region Главный бухгалтер

        private ChiefAccountant _chiefAccountant;
        public ChiefAccountant ChiefAccountant
        {
            get => _chiefAccountant;
            set => Set(ref _chiefAccountant, value);
        }

        #endregion

        #region Заместитель генерального директора

        private DeputyDirector _deputyDirector;
        public DeputyDirector DeputyDirector
        {
            get => _deputyDirector;
            set => Set(ref _deputyDirector, value);
        }

        #endregion

        #region Конструктор

        public TopManagementViewModel(Ministry ministry)
        {
            _ministry = ministry;
            _generalDirector = ministry.GeneralDirector;
            _deputyDirector = ministry.DeputyDirector;
            _chiefAccountant = ministry.ChiefAccountant;
        }

        #endregion
    }
}
