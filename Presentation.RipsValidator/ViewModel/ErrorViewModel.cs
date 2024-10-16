using Rips.Backend.src.core.dto.response;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Presentation.RipsValidator.ViewModel
{
    internal class ErrorViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private ObservableCollection<string> _errors;
        public ObservableCollection<string> Errors
        {
            get => _errors;
            set
            {
                if (_errors != value)
                {
                    _errors = value;
                    OnPropertyChanged(nameof(Errors));
                }
            }
        }
        public ErrorViewModel(List<string> errorsFound)
        {
            Errors = new ObservableCollection<string>();
            AddObservableErrors(errorsFound);
        }

        private void AddObservableErrors(List<string> errorsFound)
        {
            if (!errorsFound.Any()) return;

            foreach (var error in errorsFound)
            {
                Errors.Add(error);
            }
        }
        public override void ValidationRipGetInformation(ValidationMappingResponse validationInfo)
        {
            throw new NotImplementedException();
        }
    }
}
