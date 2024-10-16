using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
namespace Presentation
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
        }
}
