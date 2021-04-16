using System.Windows.Controls;
using System.Windows;
using Models;
using System.ComponentModel;

namespace UserControls
{   
    public partial class GeneralManagerUserControl : UserControl
    {
        #region Должность управляющего

        public static readonly DependencyProperty TitleUCProperty =
            DependencyProperty.Register(nameof(TitleUC),
                                        typeof(string),
                                        typeof(GeneralManagerUserControl),
                                        new PropertyMetadata(default(string)));
        [Description("Должность управляющего")]
        public string TitleUC
        {
            get => (string)GetValue(TitleUCProperty);
            set => SetValue(TitleUCProperty, value);
        }

        #endregion

        #region Главный управляющий

        public static readonly DependencyProperty SupervisorUCProperty =
            DependencyProperty.Register(nameof(SupervisorUC),
                                        typeof(Supervisor),
                                        typeof(GeneralManagerUserControl), 
                                        new PropertyMetadata(default(Supervisor)));
        [Description("Управляющий")]
        public Supervisor SupervisorUC
        {
            get => (Supervisor)GetValue(SupervisorUCProperty);
            set => SetValue(SupervisorUCProperty, value);
        }

        #endregion

        public GeneralManagerUserControl() => InitializeComponent();        
    }
}
