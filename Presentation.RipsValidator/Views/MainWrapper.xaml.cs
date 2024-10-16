using Presentation.RipsValidator.ViewModel;
using System.Windows.Controls;


namespace Presentation.RipsValidator.Views
{
    /// <summary>
    /// Lógica de interacción para MainWrapper.xaml
    /// </summary>
    public partial class MainWrapper : Page
    {
        public MainWrapper(MainWrapperViewModel mainWrapperModelView)
        {
            InitializeComponent();
            DataContext = mainWrapperModelView;
        }

    }
}
