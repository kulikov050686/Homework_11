using System.Windows.Controls;
using Models;
using System.ComponentModel;
using System.Windows;

namespace UserControls
{    
    public partial class SupervisorUserControl : UserControl
    {
        #region Должность управляющего

        public static readonly DependencyProperty TitleUCProperty =
            DependencyProperty.Register(nameof(TitleUC),
                                        typeof(string),
                                        typeof(SupervisorUserControl),
                                        new PropertyMetadata(default(string)));
        [Description("Должность управляющего")]
        public string TitleUC
        {
            get => (string)GetValue(TitleUCProperty);
            set => SetValue(TitleUCProperty, value);
        }

        #endregion

        #region Управляющий

        public static readonly DependencyProperty SupervisorUCProperty =
            DependencyProperty.Register(nameof(SupervisorUC),
                                        typeof(Supervisor),
                                        typeof(SupervisorUserControl),
                                        new PropertyMetadata(default(Supervisor)));
        [Description("Управляющий")]
        public Supervisor SupervisorUC
        {
            get => (Supervisor)GetValue(SupervisorUCProperty);
            set => SetValue(SupervisorUCProperty, value);
        }

        #endregion

        public SupervisorUserControl() => InitializeComponent();        
    }
}
