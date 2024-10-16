using Presentation.RipsValidator.ViewModel;
using Rips.Backend.src.core.dto.response;

namespace Presentation.RipsValidator.Services
{
    public class FileService : ViewModelBase ,IFileService
    {
        public FileService() { }

        private ValidationMappingResponse _validationMappingResponse;
        public ValidationMappingResponse ValidationMappingResponse
        {
            get => _validationMappingResponse;
            set
            {
                if (_validationMappingResponse != value)
                {
                    _validationMappingResponse = value;
                    OnPropertyChanged(nameof(ValidationMappingResponse)); // Notifica a los suscriptores
                }
            }
        }

        public override void ValidationRipGetInformation(ValidationMappingResponse validationInfo)
        {
            throw new NotImplementedException();
        }
    }
}
