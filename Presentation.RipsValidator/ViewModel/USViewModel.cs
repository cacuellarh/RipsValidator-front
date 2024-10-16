using Rips.Backend.src.core.dto.response;
using Rips.Backend.src.core.interfaces;
using System.Collections.ObjectModel;

namespace Presentation.RipsValidator.ViewModel
{
    public class USViewModel : ViewModelBase
    {
        
        private ObservableCollection<IFileRip> _rips;
        public ObservableCollection<IFileRip> Rips
        {
            get => _rips;
            set
            {
                if (_rips != value)
                {
                    _rips = value;
                    OnPropertyChanged(nameof(Rips));
                }
            }
        }

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

        public USViewModel()
        {
            Rips = new ObservableCollection<IFileRip>();
            Errors = new ObservableCollection<string>();
        }
        public sealed override void ValidationRipGetInformation(ValidationMappingResponse validationInfo)
        {
            GetErrors(validationInfo);
            GetValidatedRecords(validationInfo);
        }
        private void GetValidatedRecords(ValidationMappingResponse validationInfo)
        {
            if (!validationInfo.Records.Any()) return;

            foreach (var record in validationInfo.Records)
            {
                Rips.Add(record);
            }
        }
        private void GetErrors(ValidationMappingResponse validationInfo)
        {
            if (!validationInfo.Errors.Any()) return;

            foreach (var error in validationInfo.Errors)
            {
                Errors.Add(error);
            }

        }
    }
}
