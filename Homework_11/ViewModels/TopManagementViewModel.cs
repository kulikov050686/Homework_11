using Commands;
using Controllers;
using Models;
using System.Windows;
using System.Windows.Input;

namespace ViewModels
{
    /// <summary>
    /// Модель-Представление том менеджмента
    /// </summary>
    public class TopManagementViewModel : BaseClassViewModelINPC
    {
        #region Закрытые поля

        Ministry _ministry;
        Visibility _visibilityGeneralDirector;
        Visibility _visibilityChiefAccountant;
        Visibility _visibilityDeputyDirector;
        GeneralDirector _generalDirector;
        ChiefAccountant _chiefAccountant;
        DeputyDirector _deputyDirector;

        #endregion

        #region Открытые поля

        /// <summary>
        /// Генеральный директор
        /// </summary>
        public GeneralDirector GeneralDirector
        {
            get => _generalDirector;
            set => Set(ref _generalDirector, value);
        }

        /// <summary>
        /// Главный бухгалтер
        /// </summary>
        public ChiefAccountant ChiefAccountant
        {
            get => _chiefAccountant;
            set => Set(ref _chiefAccountant, value);
        }

        /// <summary>
        /// Заместитель генерального директора
        /// </summary>
        public DeputyDirector DeputyDirector
        {
            get => _deputyDirector;
            set => Set(ref _deputyDirector, value);
        }

        /// <summary>
        /// Отображение контрола генерального директора
        /// </summary>
        public Visibility VisibilityGeneralDirector
        {
            get => _visibilityGeneralDirector;
            set => Set(ref _visibilityGeneralDirector, value);
        } 

        /// <summary>
        /// Отображение контрола главного бухгалтера
        /// </summary>
        public Visibility VisibilityChiefAccountant
        {
            get => _visibilityChiefAccountant;
            set => Set(ref _visibilityChiefAccountant, value); 
        }

        /// <summary>
        /// Отображение контрола заместителя генерального директора
        /// </summary>
        public Visibility VisibilityDeputyDirector
        { 
            get => _visibilityDeputyDirector;
            set => Set(ref _visibilityDeputyDirector, value); 
        }

        #endregion

        #region Команда Добавить Генерального директора

        private ICommand _addGeneralDirector;
        public ICommand AddGeneralDirector
        {
            get => _addGeneralDirector ?? (_addGeneralDirector = new RelayCommand((obj) =>
            {

            }, (obj) => GeneralDirector is null));
        }

        #endregion

        #region Команда Добавить Заместителя генерального директора

        private ICommand _addDeputyDirector;
        public ICommand AddDeputyDirector
        {
            get => _addDeputyDirector ?? (_addDeputyDirector = new RelayCommand((obj) =>
            {

            }, (obj) => DeputyDirector is null));
        }

        #endregion

        #region Команда Добавить Главного бухгалтера

        private ICommand _addChiefAccountant;
        public ICommand AddChiefAccountant
        {
            get => _addChiefAccountant ?? (_addChiefAccountant = new RelayCommand((obj) =>
            {

            }, (obj) => ChiefAccountant is null));
        }

        #endregion

        #region Команда Удалить Генерального директора

        private ICommand _deleteGeneralDirector;
        public ICommand DeleteGeneralDirector
        {
            get => _deleteGeneralDirector ?? (_deleteGeneralDirector = new RelayCommand((obj) =>
            {
                if(MessageBox.Show("Удалить генерально директора?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                }
            }, (obj) => !(GeneralDirector is null)));
        }

        #endregion

        #region Команда Удалить Заместителя генерального директора

        private ICommand _deleteDeputyDirector;
        public ICommand DeleteDeputyDirector
        {
            get => _deleteDeputyDirector ?? (_deleteDeputyDirector = new RelayCommand((obj) =>
            {
                if (MessageBox.Show("Удалить заместителя директора?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                }
            }, (obj) => !(DeputyDirector is null)));
        }

        #endregion

        #region Команда Удалить Главного Бухгалтера

        private ICommand _deleteChiefAccountant;
        public ICommand DeleteChiefAccountant
        {
            get => _deleteChiefAccountant ?? (_deleteChiefAccountant = new RelayCommand((obj) =>
            {
                if (MessageBox.Show("Удалить главного бухгалтера?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                }
            }, (obj) => !(ChiefAccountant is null)));
        }

        #endregion

        #region Команда Редактировать Главного директора 

        private ICommand _editGeneralDirector;
        public ICommand EditGeneralDirector
        {
            get => _editGeneralDirector ?? (_editGeneralDirector = new RelayCommand((obj) =>
            {
                if (MessageBox.Show("Редактировать генерального директора?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                }
            }, (obj) => !(GeneralDirector is null)));
        }

        #endregion

        #region Команда Редактировать Заместителя генерального директора

        private ICommand _editDeputyDirector;
        public ICommand EditDeputyDirector
        {
            get => _editDeputyDirector ?? (_editDeputyDirector = new RelayCommand((obj) =>
            {
                if (MessageBox.Show("Редактировать заместителя директора?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                }
            }, (obj) => !(DeputyDirector is null)));
        }

        #endregion

        #region Команда Редактировать Главного Бухгалтера

        private ICommand _editChiefAccountant;
        public ICommand EditChiefAccountant
        {
            get => _editChiefAccountant ?? (_editChiefAccountant = new RelayCommand((obj) =>
            {
                if (MessageBox.Show("Редактировать главного бухгалтера?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                }
            }, (obj) => !(ChiefAccountant is null)));
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
