using Commands;
using System.Windows;
using System.Windows.Input;
using Views;

namespace ViewModels
{
    /// <summary>
    /// Модель-Представление окна добавление департамента
    /// </summary>
    public class AddDepartmentViewModel : BaseClassViewModelINPC
    {
        #region Закрытые поля

        string _nameDepartment;        
        
        #endregion

        #region Открытые свойства

        /// <summary>
        /// Название окна
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Название департамента
        /// </summary>
        public string NameDepartment
        {
            get => _nameDepartment;
            set => Set(ref _nameDepartment, value);
        }

        /// <summary>
        /// Нажатая кнопка Add = true, Cancel = false
        /// </summary>
        public bool AddCancel { get; private set; } = false;

        #endregion

        #region Команда Добавить

        private ICommand _add;
        public ICommand Add
        {
            get
            {
                return _add ?? (_add = new RelayCommand((obj) =>
                {
                    if (!string.IsNullOrWhiteSpace(NameDepartment))
                    {
                        AddCancel = true;
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка ввода данных!!!");
                    }
                }));
            }
        }

        #endregion

        #region Команда Отменить

        private ICommand _cancel;        
        public ICommand Cancel
        {
            get
            {
                return _cancel ?? (_cancel = new RelayCommand((obj) =>
                {
                    AddCancel = false;
                    Close();
                }));
            }
        }

        #endregion
        
        #region Конструктор

        public AddDepartmentViewModel()
        {
            AddCancel = false;
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
                if (window is WindowAddDepartment)
                {
                    window.Close();
                    break;
                }
            }
        }

        #endregion
    }
}
