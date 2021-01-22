using Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace UserControls
{    
    public partial class DepartmentUserControl : UserControl
    {
        #region Свойство-зависимости команда Добавить департамент

        public static readonly DependencyProperty AddDepartmentUCProperty = DependencyProperty.Register(nameof(AddDepartmentUC), typeof(ICommand), typeof(DepartmentUserControl));
        public ICommand AddDepartmentUC
        {
            get => (ICommand)GetValue(AddDepartmentUCProperty);
            set => SetValue(AddDepartmentUCProperty, value);
        }

        #endregion

        #region Свойство-зависимости команда Добавить поддепартамент

        public static readonly DependencyProperty AddNextDepartmentUCProperty = DependencyProperty.Register(nameof(AddNextDepartmentUC), typeof(ICommand), typeof(DepartmentUserControl));
        public ICommand AddNextDepartmentUC
        {
            get => (ICommand)GetValue(AddNextDepartmentUCProperty);
            set => SetValue(AddNextDepartmentUCProperty, value);
        }

        #endregion

        #region Свойство-зависимости команда Удалить департамент

        public static readonly DependencyProperty DeleteDepartmentUCProperty = DependencyProperty.Register(nameof(DeleteDepartmentUC), typeof(ICommand), typeof(DepartmentUserControl));
        public ICommand DeleteDepartmentUC
        {
            get => (ICommand)GetValue(DeleteDepartmentUCProperty);
            set => SetValue(DeleteDepartmentUCProperty, value);
        }

        #endregion

        #region Свойство-зависимости Список департаментов

        public static readonly DependencyProperty DepartmentsUCProperty = DependencyProperty.Register(nameof(DepartmentsUC), typeof(ObservableCollection<Department>), typeof(DepartmentUserControl));
        public ObservableCollection<Department> DepartmentsUC
        {
            get => (ObservableCollection<Department>)GetValue(DepartmentsUCProperty);
            set => SetValue(DepartmentsUCProperty, value);
        }

        #endregion

        #region Свойство-зависимости Выбранный департамент

        public static readonly DependencyProperty SelectedDepartmentUCProperty = DependencyProperty.Register(nameof(SelectedDepartmentUC), typeof(Department), typeof(DepartmentUserControl));
        public Department SelectedDepartmentUC
        {
            get => (Department)GetValue(SelectedDepartmentUCProperty);
            set => SetValue(SelectedDepartmentUCProperty, value);
        }

        #endregion

        public DepartmentUserControl() => InitializeComponent();        
    }
}
