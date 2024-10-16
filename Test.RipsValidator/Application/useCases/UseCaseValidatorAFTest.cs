using Backend.RipsValidator.Aplication.Request;
using Backend.RipsValidator.Aplication.UseCase;
using Backend.RipsValidator.Domain.Types;
using Test.RipsValidator.Application.Helpers;

namespace Test.RipsValidator.Application.useCases
{
    [TestClass]
    public class UseCaseValidatorAFTest
    {
        //Validar AF CORRECTO
        [TestMethod]
        public void Execute_ShouldReturnSuccess_WhenValidationIsSuccessfull()
        {
            var useCaseRequest = GenerateServiceToUseCaseValidation.GenerateServices();

            // Usar la fábrica en el caso de uso
            var useCase = new UseCaseValidateColumnLength
                (
                    useCaseRequest.TypeFileFactory,
                    useCaseRequest.FileReader,
                    useCaseRequest.Mediator
                );

            // El path de prueba
            var path = @"C:\Users\camil\OneDrive\Desktop\escritorio\Proyectos\RIPS\11285\AF011285.txt";
            var requestUseCase = new UseCaseValiteFileTypeRequest(path, TypeFilesEnum.AF);

            var result = useCase.Execute(requestUseCase);

            // Verificar que la validación fue exitosa
            Assert.IsTrue(result.Success);
        }
        //Validar AF COLUMNAS INCORRECTAS
        [TestMethod]
        public void AFfileWithInvalidColumnsLength()
        {
            var useCaseRequest = GenerateServiceToUseCaseValidation.GenerateServices();

            var useCase = new UseCaseValidateColumnLength
                (
                    useCaseRequest.TypeFileFactory,
                    useCaseRequest.FileReader,
                    useCaseRequest.Mediator
                );

            // El path de prueba
            var path = @"C:\Users\camil\OneDrive\Desktop\escritorio\Proyectos\RIPS\11285\af\AF_bad_columns.txt";
            var requestUseCase = new UseCaseValiteFileTypeRequest(path, TypeFilesEnum.AF);

            var result = useCase.Execute(requestUseCase);

            // Verificar que la validación fue falsa
            Assert.IsFalse(result.Success);
        }

        //Validar AF Numero de identificacion el prestador con letras.
        [TestMethod]
        public void AFfileWithInvalidIDPrestador()
        {
            var useCaseRequest = GenerateServiceToUseCaseValidation.GenerateServices();

            var useCase = new UseCaseValidateColumnLength
                (
                    useCaseRequest.TypeFileFactory,
                    useCaseRequest.FileReader,
                    useCaseRequest.Mediator
                );

            // El path de prueba
            var path = @"C:\Users\camil\OneDrive\Desktop\escritorio\Proyectos\RIPS\11285\af\AF_bad_Id_Prestador.txt";
            var requestUseCase = new UseCaseValiteFileTypeRequest(path, TypeFilesEnum.AF);

            var result = useCase.Execute(requestUseCase);

            // Verificar que la validación fue falsa
            Assert.IsFalse(result.Success);
        }

    }
}
