using Commands;
using Controllers;
using Models;
using Services;
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
        
        #endregion

        #region Команда Добавить Генерального директора

        private ICommand _addGeneralDirector;
        public ICommand AddGeneralDirector
        {
            get => _addGeneralDirector ?? (_addGeneralDirector = new RelayCommand((obj) =>
            {
                GeneralDirector supervisor = (GeneralDirector)AddSupervisorDialog.Show(EmployeePosition.GeneralDirector);

                if (supervisor != null)
                {
                    _ministry.AddGeneralDirector(supervisor);
                    GeneralDirector = _ministry.GeneralDirector;                    
                }
            }, (obj) => GeneralDirector is null));
        }

        #endregion

        #region Команда Добавить Заместителя генерального директора

        private ICommand _addDeputyDirector;
        public ICommand AddDeputyDirector
        {
            get => _addDeputyDirector ?? (_addDeputyDirector = new RelayCommand((obj) =>
            {
                DeputyDirector supervisor = (DeputyDirector)AddSupervisorDialog.Show(EmployeePosition.DeputyDirector);

                if (supervisor != null)
                {
                    _ministry.AddDeputyDirector(supervisor);
                    DeputyDirector = _ministry.DeputyDirector;                    
                }
            }, (obj) => DeputyDirector is null));
        }

        #endregion

        #region Команда Добавить Главного бухгалтера

        private ICommand _addChiefAccountant;
        public ICommand AddChiefAccountant
        {
            get => _addChiefAccountant ?? (_addChiefAccountant = new RelayCommand((obj) =>
            {
                ChiefAccountant supervisor = (ChiefAccountant)AddSupervisorDialog.Show(EmployeePosition.ChiefAccountant);

                if(supervisor != null)
                {
                    _ministry.AddChiefAccountant(supervisor);
                    ChiefAccountant = _ministry.ChiefAccountant;                    
                }
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
                    _ministry.DeleteGeneralDirector();
                    GeneralDirector = _ministry.GeneralDirector;                    
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
                    _ministry.DeleteDeputyDirector();
                    DeputyDirector = _ministry.DeputyDirector;                    
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
                    _ministry.DeleteChiefAccountant();
                    ChiefAccountant = _ministry.ChiefAccountant;                    
                }
            }, (obj) => !(ChiefAccountant is null)));
        }

        #endregion

        #region Команда Редактировать Генерального директора 

        private ICommand _editGeneralDirector;
        public ICommand EditGeneralDirector
        {
            get => _editGeneralDirector ?? (_editGeneralDirector = new RelayCommand((obj) =>
            {
                if (MessageBox.Show("Редактировать генерального директора?", "Внимание!!!", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    GeneralDirector tempSupervisor = (GeneralDirector)EditDataSupervisorDialog.Show(GeneralDirector);

                    if (!tempSupervisor.Equals(GeneralDirector))
                    {
                        _ministry.DeleteGeneralDirector();
                        _ministry.AddGeneralDirector(tempSupervisor);
                        GeneralDirector = _ministry.GeneralDirector;
                    }    
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
                    DeputyDirector tempSupervisor = (DeputyDirector)EditDataSupervisorDialog.Show(DeputyDirector);

                    if(!tempSupervisor.Equals(DeputyDirector))
                    {
                        _ministry.DeleteDeputyDirector();
                        _ministry.AddDeputyDirector(tempSupervisor);
                        DeputyDirector = _ministry.DeputyDirector;
                    }
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
                    ChiefAccountant tempSupervisor = (ChiefAccountant)EditDataSupervisorDialog.Show(ChiefAccountant);

                    if(!tempSupervisor.Equals(ChiefAccountant))
                    {
                        _ministry.DeleteChiefAccountant();
                        _ministry.AddChiefAccountant(tempSupervisor);
                        ChiefAccountant = _ministry.ChiefAccountant;
                    }
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

            ministry.PropertyChanged += OnPropertyChanged;
        }

        /// <summary>
        /// Событие возникающее при изменении какого-лидо свойства
        /// </summary>        
        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            GeneralDirector = _ministry.GeneralDirector;
            DeputyDirector = _ministry.DeputyDirector;
            ChiefAccountant = _ministry.ChiefAccountant;
        }

        #endregion
    }
}
