using Commands;
using Models;
using System.Windows.Input;
using Infrastructure;
using Controllers;

namespace ViewModels
{
    /// <summary>
    /// Модель-Представление Главного меню Меню
    /// </summary>
    public class MainMenuViewModel : BaseClassViewModelINPC
    {
        #region Закрытые поля
                
        Ministry _minystry;

        #endregion
        
        #region Команда открыть файл

        private ICommand _openFile;
        public ICommand OpenFileVM
        {
            get
            {
                return _openFile ?? (_openFile = new RelayCommand((obj) =>
                {
                    _minystry.SetListOfAllWorkersMinistry(FileDialog<BaseWorker>.OpenFileDialog());                    
                }));
            }
        }

        #endregion

        #region Команда сохранить файл

        private ICommand _saveFile;
        public ICommand SaveFileVM
        {
            get
            {
                return _saveFile ?? (_saveFile = new RelayCommand((obj) =>
                {
                    FileDialog<BaseWorker>.SaveFileDialog(_minystry.GetListOfAllWorkersMinistry());
                }, (obj) => _minystry.Departments != null));
            }
        }

        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>        
        public MainMenuViewModel(Ministry minystry)
        {
            _minystry = minystry;            
        }        
    }
}
