using Microsoft.Extensions.DependencyInjection;

namespace Library.Wpf.ViewModel
{
    internal class ViewModelLocator
    {
        public MainWindowViewModel MainWindowViewModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
