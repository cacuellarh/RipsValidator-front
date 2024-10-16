using Rips.Backend.src.core.dto.response;
using System.ComponentModel;

namespace Presentation.RipsValidator.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void ValidationRipGetInformation(ValidationMappingResponse validationInfo);


    }
}
