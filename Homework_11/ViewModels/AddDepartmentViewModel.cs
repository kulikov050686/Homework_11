using Commands;
using System.Windows;
using System.Windows.Input;
using Views;

namespace ViewModels
{
    /// <summary>
    /// Модель-Представление окна добавление департамента
    /// </summary>
    public class AddDepartmentViewModel : BaseClassINPC
    {
        #region Закрытые поля

        string _nameDepartment;        
        ICommand _add;
        ICommand _cancel;

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
        /// Добавить
        /// </summary>
        public ICommand Add
        {
            get
            {
                return _add ?? (_add = new RelayCommand((obj) =>
                {
                    if (!string.IsNullOrWhiteSpace(NameDepartment))
                    {                        
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка ввода данных!!!");
                    }
                }));
            }
        }

        /// <summary>
        /// Отменить
        /// </summary>
        public ICommand Cancel
        {
            get
            {
                return _cancel ?? (_cancel = new RelayCommand((obj) =>
                {
                    NameDepartment = "";
                    Close();
                }));
            }
        }      

        #endregion

        #region Конструктор

        public AddDepartmentViewModel()
        {
            NameDepartment = "";
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
