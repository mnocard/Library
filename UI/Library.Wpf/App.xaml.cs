using Library.Wpf.Infrastructure.Interfaces;
using Library.Wpf.Infrastructure.Services;
using Library.Wpf.ViewModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Library.Wpf
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App
    {
        private static IHost _Hosting;
        public static IHost Hosting
        {
            get
            {
                if (_Hosting is null) _Hosting = CreateHostBuilder(Environment.GetCommandLineArgs()).Build();
                return _Hosting;
            }
        }

        public static IServiceProvider Services => Hosting.Services;

        public static IHostBuilder CreateHostBuilder(string[] vs)
        {
            return Host.CreateDefaultBuilder(vs)
                .ConfigureAppConfiguration(opt => opt.AddJsonFile("appsettings.json", false, true))
                .ConfigureServices(ConfigureServices);
        }

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<IServiceManager, ServiceManager>();
        }
    }
}
