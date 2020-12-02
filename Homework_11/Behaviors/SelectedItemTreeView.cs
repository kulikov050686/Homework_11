using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace Behaviors
{
    public class SelectedItemTreeView : Behavior<TreeView>
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register(nameof(SelectedItem),
                                                                                                     typeof(object),
                                                                                                     typeof(SelectedItemTreeView), 
                                                                                                     new UIPropertyMetadata(null, OnSelectedItemChanged));        

        /// <summary>
        /// Расширенное свойство
        /// </summary>
        public object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var item = e.NewValue as TreeViewItem;

            if(item != null)
            {
                item.SetValue(TreeViewItem.IsExpandedProperty, true);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();            
            this.AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
        }
        
        /// <summary>
        /// 
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();

            if (this.AssociatedObject != null)
            {
                this.AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
            }            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            this.SelectedItem = e.NewValue;
        }
    }
}
