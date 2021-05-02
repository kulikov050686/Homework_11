using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace Behaviors
{
    /// <summary>
    /// Поведение для закрытия окна при нажатии на выбранный пункт меню
    /// </summary>
    public class CloseWindowItemMenu : Behavior<MenuItem>
    {
        /// <summary>
        /// Вызывается когда поведение добавляется в коллекцию
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Click += OnButtonClick;
        }

        /// <summary>
        /// Обработчик события нажатия кнопки
        /// </summary>        
        private void OnButtonClick(object sender, RoutedEventArgs e) => (AssociatedObject.FindLogicalRoot() as Window)?.Close();

        /// <summary>
        /// Вызывается когда поведение удаляется из коллекции
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= OnButtonClick;
        }
    }
}
