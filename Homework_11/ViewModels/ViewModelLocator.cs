using Homework_11;
using Microsoft.Extensions.DependencyInjection;

namespace ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    }
}
