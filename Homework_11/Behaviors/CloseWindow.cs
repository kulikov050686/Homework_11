using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace Behaviors
{
    /// <summary>
    /// Поведение для закрытия окна при нажатии на кнопку
    /// </summary>
    public class CloseWindow : Behavior<Button>
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
        private void OnButtonClick(object sender, RoutedEventArgs e) => (AssociatedObject.FindVisualRoot() as Window)?.Close();       
                
        /// <summary>
        /// Вызывается когда поведение удаляется из коллекции
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= OnButtonClick;
        }
    }
}
