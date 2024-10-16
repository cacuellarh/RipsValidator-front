using Presentation.RipsValidator.Contracts;
using Rips.Backend.src.core.entities;
using System.Windows.Controls;
namespace Presentation.RipsValidator.Views
{
    /// <summary>
    /// Lógica de interacción para CTView.xaml
    /// </summary>
    public partial class CTView : Page, IPageValidator
    {
        public CTView()
        {
            InitializeComponent();
        }

        public Type GetFileRelatedTypeFileRip()
        {
            return typeof(CT);
        }
    }
}
