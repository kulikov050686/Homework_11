using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Models
{
    /// <summary>
    /// Базовый класс модели с реализацией интерфейса INotifyPropertyChanged
    /// </summary>
    public abstract class BaseClassModelINPC : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие для извещения об изменения свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод для вызова события извещения об изменении свойства
        /// </summary>
        /// <param name="property"> Изменившееся свойство </param>
        public void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        
        /// <summary>
        /// Метод для обновления значения свойства
        /// </summary>
        /// <typeparam name="T"> Тип данных свойства и поля </typeparam>
        /// <param name="field"> Ссылка на поле значения свойства </param>
        /// <param name="value"> Новое значение </param>
        /// <param name="property"> Название свойства </param>        
        public bool Set<T>(ref T field, T value, [CallerMemberName] string property = null)
        {
            if (Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(property);

            return true;
        }
    }
}
