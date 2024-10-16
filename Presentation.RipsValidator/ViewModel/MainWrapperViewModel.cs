using Microsoft.Win32;
using Presentation.RipsValidator.Contracts;
using Presentation.RipsValidator.Windows;
using Rips.Backend.src.core.dto.response;
using Rips.Backend.src.core.interfaces;
using System.Windows.Controls;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.RipsValidator.ViewModel
{
    public class MainWrapperViewModel : ViewModelBase
    {
        public int ErrorsLength
        {
            get
            {
                return errorsLength;
            }
            set
            {
                if (errorsLength != value)
                {
                    errorsLength = value;
                    OnPropertyChanged(nameof(ErrorsLength));
                }
            }
        }
        private int errorsLength { get; set; }

        public int RecordsLength
        {
            get
            {
                return _recordsLength;
            }
            set
            {
                if (_recordsLength != value)
                {
                    _recordsLength = value;
                    OnPropertyChanged(nameof(RecordsLength));
                }
            }
        }
        private int _recordsLength { get; set; }
        public int TotalRecords { get; set; }
        private readonly IValidateStructureServiceFactory _validateStructureServiceFactory;
        private IPageValidator viewIntance;
        private readonly List<string> errors;
        public RelayCommand OpenErrorWindowCommand { get; }
        public RelayCommand NavigateBetweenPagesCommand { get; }
        public RelayCommand UploadDocumentCommand { get; }
        private Type FileRelatedType { get; set; }
        private string pathFile { get; set; }
        private readonly IServiceProvider _serviceProvider;


        public MainWrapperViewModel(IValidateStructureServiceFactory validateStructureServiceFactory,
            IServiceProvider serviceProvider) 
        {
            _validateStructureServiceFactory = validateStructureServiceFactory;
            errors = new List<string>();
            OpenErrorWindowCommand = new RelayCommand(OpenErrorWindow, CanOpenErrorWindow);
            NavigateBetweenPagesCommand = new RelayCommand(Navigate);
            UploadDocumentCommand = new RelayCommand(UploadFile);
            _serviceProvider = serviceProvider;
        }

        public void Navigate(object sender)
        {
            var button = sender as RadioButton;

            if (button != null && button.Tag is Type viewType)
            {
                viewIntance = (IPageValidator)_serviceProvider.GetRequiredService(viewType);
                FileRelatedType = viewIntance.GetFileRelatedTypeFileRip();
                FilePresentationFrame.Navigate(viewIntance);

            }

        }

        public void UploadFile(object sender)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Title = "Selecciona un archivo";
            openFileDialog.Filter = "Todos los archivos (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                pathFile = openFileDialog.FileName;
            }
        }

        public void ValidateStructFileRip_Click(object sender, RoutedEventArgs e)
        {
            if (FileRelatedType is null) throw new ArgumentNullException(nameof(FileRelatedType), "Error");

            var validationStruct = _validateStructureServiceFactory.Create(FileRelatedType);
            var validationResult = validationStruct.ValidateFileRip(pathFile);
            GetNumbersOfRecords(validationResult);

            if (viewIntance is Page page)
            {
                var viewM = (ViewModelBase)page.DataContext;
                viewM.ValidationRipGetInformation(validationResult);
            }

        }
        public bool CanOpenErrorWindow(object e)
        {
            return errors.Count == 0;
        }

        public void OpenErrorWindow(object e)
        {
            ErrorDetails errorWindows = new(errors);
            errorWindows.Show();
        }
        public override void ValidationRipGetInformation(ValidationMappingResponse validationInfo)
        {
            throw new NotImplementedException();
        }
        private void GetNumbersOfRecords(ValidationMappingResponse validationInfo)
        { 
            RecordsLength = validationInfo.Records.Count;
            errorsLength = validationInfo.Errors.Count; 
        }

    }
}
