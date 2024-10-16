using Microsoft.Extensions.DependencyInjection;
using Presentation.RipsValidator.Services;
using Presentation.RipsValidator.ViewModel;
using Presentation.RipsValidator.Views;
using Presentation.RipsValidator.Windows;

namespace Presentation.RipsValidator
{
    public static class UIRegistrationServices
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<MainWrapper>();
            services.AddSingleton<USView>();
            services.AddSingleton<CTView>();
            services.AddSingleton<USViewModel>();
            services.AddSingleton<MainWrapperViewModel>();
            services.AddSingleton<MainWindow>();
            services.AddSingleton<ErrorDetails>();

            services.AddTransient<IFileService, FileService>();
        }
    }
}
