
using Backend.RipsValidator.Aplication.Request.Test;
using Backend.RipsValidator.Domain.DomainEvents.Events;
using Backend.RipsValidator.Domain.DomainEvents.Handlers;
using Backend.RipsValidator.Domain.Factories;
using Backend.RipsValidator.Domain.Handler.Validation;
using Backend.RipsValidator.Domain.Rules.RuleTypes;
using Backend.RipsValidator.Domain.Rules.TypeFiles;
using Backend.RipsValidator.Infraestructure.StreamFile;
using MediatR;
using Moq;

namespace Test.RipsValidator.Application.Helpers
{
    public static class GenerateServiceToUseCaseValidation
    {
        public static UseCaseRequestTest GenerateServices()
        {
            var validationHanlder = new ValidationHandler();
            var usRulesType = new USRulesTypes(validationHanlder);  // Dependencia real para US
            var ctRulesType = new CTRulesTypes(validationHanlder);  // Dependencia real para CT
            var afRulesType = new AFRulesTypes(validationHanlder);
            // Crear instancias reales de US y CT
            var fileTypeUS = new US(usRulesType);
            var fileTypeCT = new CT(ctRulesType);
            var fileTypeAF = new AF(afRulesType);

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

            mockServiceProvider
                .Setup(sp => sp.GetService(typeof(AF)))
                .Returns(fileTypeAF);

            // Act - Crear la instancia de TypeFileFactory
            var factory = new TypeFileFactory(mockServiceProvider.Object);

            mediatorMock
                .Setup(m => m.Send(It.IsAny<ValidateColumnsTypeEvent>(), default))
                .Returns((ValidateColumnsTypeEvent request, CancellationToken cancellationToken) =>
                {
                    // Llamar al handler real con los datos del evento
                    return validateColumnsTypeHandlerEvent.Handle(request, cancellationToken);
                });

            return new UseCaseRequestTest(factory, fileReader, mediatorMock.Object);
        }
    }
}
