using Rips.Backend.src.core.dto.response;
using System.ComponentModel;

namespace Presentation.RipsValidator.Services
{
    public interface IFileService : INotifyPropertyChanged
    {
        ValidationMappingResponse ValidationMappingResponse { get; set; }
    }
}