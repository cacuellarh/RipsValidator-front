using Backend.RipsValidator.Domain.Rules.ColumnLength;
using Backend.RipsValidator.Infraestructure.StreamFile;

namespace Test.RipsValidator
{
    [TestClass]
    public class ValidateColumnLengthTest
    {
        [TestMethod]
        public void ValidateColumnWithValidFormat_ShouldTrue()
        {
            EnsureFileExist validator = new EnsureFileExist();
            FileReader reader = new FileReader(validator);
            ValidateColumnLength columValidator = new ValidateColumnLength(14);
            var result = reader.ReadFile(@"C:\Users\camil\OneDrive\Desktop\escritorio\Proyectos\RIPS\Rips Ecopetrol\Rips Ecopetrol\US001935_invalid_CC.txt");
            var validation = columValidator.Validate(result.ValueResult);

            Assert.IsNotNull(validation);
        }

        [TestMethod]
        public void ValidateColumnWithInvalidFormat_ShouldFalse()
        {
            EnsureFileExist validator = new EnsureFileExist();
            FileReader reader = new FileReader(validator);
            ValidateColumnLength columValidator = new ValidateColumnLength(14);
            var result = reader.ReadFile(@"C:\Users\camil\OneDrive\Desktop\escritorio\Proyectos\RIPS\Rips Ecopetrol\Rips Ecopetrol\US001935Incorrect.txt");
            var validation = columValidator.Validate(result.ValueResult);

            Assert.IsFalse(validation.Success);
        }
    }
}
