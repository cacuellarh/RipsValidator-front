using Backend.RipsValidator.Domain.Rules.File;
using Backend.RipsValidator.Infraestructure.StreamFile;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ff
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider _serviceProvider { get; private set; }
        public static IHost? AppHost { get; set; }
        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddTransient<IFileValidator, EnsureFileExist>();

                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();
            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
        }
    }

}
