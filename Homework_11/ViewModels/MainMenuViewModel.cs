using Commands;
using Models;
using System.Windows;
using System.Windows.Input;
using Infrastructure;
using Homework_11;
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
        
        #region Команда закрыть приложение

        private ICommand _exit;
        public ICommand ExitVM
        {
            get
            {
                return _exit ?? (_exit = new RelayCommand((obj) =>
                {
                    Close();
                }));
            }
        }

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

        #region Закрытые методы

        /// <summary>
        /// Закрывает окно
        /// </summary>
        private void Close()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window is MainWindow)
                {
                    window.Close();
                    break;
                }
            }
        }

        #endregion
    }
}
