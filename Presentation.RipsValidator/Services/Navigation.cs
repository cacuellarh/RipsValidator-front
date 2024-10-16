using Microsoft.Extensions.DependencyInjection;
using Presentation.RipsValidator.Contracts;
using System.Windows.Controls;

namespace Presentation.RipsValidator.Services
{
    public class Navigation
    {
        private readonly IServiceProvider serviceProvider;
        protected Navigation(IServiceProvider serviceProvider_) 
        { 
            serviceProvider = serviceProvider_;
        }
        public void NavigateByRadioButton(object sender)
        {
            var button = sender as RadioButton;

            if (button != null && button.Tag is Type viewType)
            {
                var viewIntance = (IPageValidator)serviceProvider.GetRequiredService(viewType);
                FileRelatedType = viewIntance.GetFileRelatedTypeFileRip();
                FilePresentationFrame.Navigate(viewIntance);

            }

        }
    }
}
