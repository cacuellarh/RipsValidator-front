using Presentation.RipsValidator.ViewModel;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;


namespace Presentation.RipsValidator.Windows
{
    /// <summary>
    /// Lógica de interacción para ErrorDetails.xaml
    /// </summary>
    public partial class ErrorDetails : Window
    {
        public ErrorDetails(List<string> errorsFound)
        {
            InitializeComponent();
            DataContext = new ErrorViewModel(errorsFound);
        }

     
    }
}
