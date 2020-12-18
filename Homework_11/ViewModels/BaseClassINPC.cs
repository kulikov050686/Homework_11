using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xaml;

namespace ViewModels
{
    /// <summary>
    /// Базовый класс с реализацией интерфейса INotifyPropertyChanged
    /// </summary>
    public abstract class BaseClassINPC : MarkupExtension, INotifyPropertyChanged
    {
        private WeakReference _TargetRef;
        private WeakReference _RootRef;

        /// <summary>
        /// 
        /// </summary>
        public object TargetObject => _TargetRef.Target;

        /// <summary>
        /// 
        /// </summary>
        public object RootObject => _RootRef.Target;

        /// <summary>
        /// Событие для извещения об изменения свойства
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Метод для вызова события извещения об изменении свойства
        /// </summary>
        /// <param name="property"> Изменившееся свойство </param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));

            var handlers = PropertyChanged;
            if (handlers is null) return;

            var invocation_list = handlers.GetInvocationList();

            var arg = new PropertyChangedEventArgs(propertyName);
            foreach (var action in invocation_list)
            {
                if (action.Target is DispatcherObject disp_object)
                {
                    disp_object.Dispatcher.Invoke(action, this, arg);
                }                    
                else
                {
                    action.DynamicInvoke(this, arg);
                }                    
            }               
        }        

        /// <summary>
        /// Метод для обновления значения свойства
        /// </summary>
        /// <typeparam name="T"> Тип данных свойства и поля </typeparam>
        /// <param name="field"> Поле </param>
        /// <param name="value"> Значение </param>
        /// <param name="property"> Изменившееся свойство </param>        
        public bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        /// <summary>
        /// Метод возвращает объект, предоставляемый как значение целевого свойства для расширения разметки
        /// </summary>
        /// <param name="serviceProvider"> Поставщик услуг </param>        
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var value_target_service = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            var root_object_service = serviceProvider.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;

            OnInitialized( value_target_service?.TargetObject, value_target_service?.TargetProperty, root_object_service?.RootObject);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Target"></param>
        /// <param name="Property"></param>
        /// <param name="Root"></param>
        protected virtual void OnInitialized(object Target, object Property, object Root)
        {
            _TargetRef = new WeakReference(Target);
            _RootRef = new WeakReference(Root);
        }
    }
}
