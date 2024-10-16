using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using Rips.Backend.src.infra;

namespace Presentation.RipsValidator
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
                    UIRegistrationServices.RegisterServices(services);
                    RipsCoreServicesRegistration.RegisterRipsCoreServicesRegistration(services);
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
