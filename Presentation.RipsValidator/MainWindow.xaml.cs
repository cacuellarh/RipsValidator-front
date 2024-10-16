
using Presentation.RipsValidator.Views;
using System.Windows;


namespace Presentation.RipsValidator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWrapper mainWrapper;
        public MainWindow()
        { }
        public MainWindow(MainWrapper _mainWrapper) : this() 
        {
            mainWrapper = _mainWrapper;
            InitializeComponent();
        }
        private void NavigateToFrame_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(mainWrapper);
        }


    }
}