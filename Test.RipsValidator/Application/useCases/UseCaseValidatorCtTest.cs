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
    public class UseCaseValidatorCtTest
    {

        [TestMethod]
        public void Execute_ShouldReturnSuccess_WhenValidationIsSuccessfull()
        {
            var validationHanlder = new ValidationHandler();
            var usRulesType = new USRulesTypes(validationHanlder);  // Dependencia real para US
            var ctRulesType = new CTRulesTypes(validationHanlder);  // Dependencia real para CT

            // Crear instancias reales de US y CT
            var fileTypeUS = new US(usRulesType);
            var fileTypeCT = new CT(ctRulesType);

            var fileValidator = new EnsureFileExist();
            var fileReader = new FileReader(fileValidator);
            var validateColumnsTypeHandlerEvent = new ValidateColumnsTypeHandlerEvent(validationHanlder);
            var mediatorMock = new Mock<IMediator>();

            var mockServiceProvider = new Mock<IServiceProvider>();

            // Configurar el servicio para devolver las instancias reales
            mockServiceProvider
                .Setup(sp => sp.GetService(typeof(US)))
                .Returns(fileTypeUS);

            mockServiceProvider
                .Setup(sp => sp.GetService(typeof(CT)))
                .Returns(fileTypeCT);

            // Act - Crear la instancia de TypeFileFactory
            var factory = new TypeFileFactory(mockServiceProvider.Object);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ValidateColumnsTypeEvent>(), default))
                .Returns((ValidateColumnsTypeEvent request, CancellationToken cancellationToken) =>
                {
                    // Llamar al handler real con los datos del evento
                    return validateColumnsTypeHandlerEvent.Handle(request, cancellationToken);
                });

            // Usar la fábrica en el caso de uso
            var useCase = new UseCaseValidateColumnLength(factory, fileReader, mediatorMock.Object);

            // El path de prueba
            var path = @"C:\Users\camil\OneDrive\Desktop\escritorio\Proyectos\RIPS\11285\CT011285.txt";
            var requestUseCase = new UseCaseValiteFileTypeRequest(path, TypeFilesEnum.AC);

            var result = useCase.Execute(requestUseCase);

            // Verificar que la validación fue exitosa
            Assert.IsTrue(result.Success);
        }
    }
}
