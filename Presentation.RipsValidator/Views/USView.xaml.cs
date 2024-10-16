using Presentation.RipsValidator.Contracts;
using Rips.Backend.src.core.file;
using System.Windows.Controls;

namespace Presentation.RipsValidator.Views
{

    public partial class USView : Page, IPageValidator
    {
        public USView()
        {
            InitializeComponent();
        }

        public Type GetFileRelatedTypeFileRip()
        {
            return typeof(US);
        }
    }
}
