
using Backend.RipsValidator.Aplication.Request;
using Backend.RipsValidator.Aplication.UseCase;
using Backend.RipsValidator.Domain.DomainEvents.Events;
using Backend.RipsValidator.Domain.DomainEvents.Handlers;
using Backend.RipsValidator.Domain.Factories;
using Backend.RipsValidator.Domain.Handler.Validation;
using Backend.RipsValidator.Domain.Rules.RuleTypes;
using Backend.RipsValidator.Domain.Rules.TypeFiles;
using Backend.RipsValidator.Domain.Types;
using Backend.RipsValidator.Infraestructure.StreamFile;
using MediatR;
using Moq;

namespace Test.RipsValidator.Application.useCases
{
    [TestClass]
    public class UseCaseValidatorUSTest
    {
        [TestMethod]
        public void Execute_ShouldReturnSuccess_WhenValidationIsSuccessful()
        {
            // Crear el ValidationHandler real
            var validationHanlder = new ValidationHandler();

            // Crear las dependencias reales para US y CT
            var usRulesType = new USRulesTypes(validationHanlder);  // Para US
            var ctRulesType = new CTRulesTypes(validationHanlder);  // Para CT

            // Crear instancias reales de US y CT con sus dependencias
            var fileTypeUS = new US(usRulesType);
            var fileTypeCT = new CT(ctRulesType);

            // Crear el FileReader real con el validador de archivos
            var fileValidator = new EnsureFileExist();
            var fileReader = new FileReader(fileValidator);

            // Crear el handler real de eventos de validación
            var validateColumnsTypeHandlerEvent = new ValidateColumnsTypeHandlerEvent(validationHanlder);

            // Crear el mock de IMediator
            var mediatorMock = new Mock<IMediator>();

            // Crear el mock de IServiceProvider
            var mockServiceProvider = new Mock<IServiceProvider>();

            // Configurar el mock para devolver las instancias reales de US y CT
            mockServiceProvider
                .Setup(sp => sp.GetService(typeof(US)))
                .Returns(fileTypeUS);

            mockServiceProvider
                .Setup(sp => sp.GetService(typeof(CT)))
                .Returns(fileTypeCT);

            // Crear la instancia de TypeFileFactory con el mock de IServiceProvider
            var factory = new TypeFileFactory(mockServiceProvider.Object);

            // Configurar el mediatorMock para llamar al handler real
            mediatorMock
                .Setup(m => m.Send(It.IsAny<ValidateColumnsTypeEvent>(), default))
                .Returns((ValidateColumnsTypeEvent request, CancellationToken cancellationToken) =>
                {
                    // Llamar al handler real con los datos del evento
                    return validateColumnsTypeHandlerEvent.Handle(request, cancellationToken);
                });

            // Crear la instancia del caso de uso UseCaseValidateColumnLength
            var useCase = new UseCaseValidateColumnLength(factory, fileReader, mediatorMock.Object);

            // Definir el path para el archivo de prueba
            var path = @"C:\Users\camil\OneDrive\Desktop\escritorio\Proyectos\RIPS\17\RIPS FACTURA FVCI-194\US001817.txt";

            // Crear la solicitud del caso de uso
            var requestUseCase = new UseCaseValiteFileTypeRequest(path, TypeFilesEnum.US);

            // Ejecutar el caso de uso
            var result = useCase.Execute(requestUseCase);

            // Verificar que la validación fue exitosa
            Assert.IsTrue(result.Success);
        }
    }
}
    

