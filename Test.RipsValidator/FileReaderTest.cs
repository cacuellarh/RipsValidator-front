using Backend.RipsValidator.Infraestructure.StreamFile;

namespace Test.RipsValidator
{
    [TestClass]
    public class FileReaderTest
    {
        [TestMethod]

        public void FileReaderWithValidPath_ShouldTrue()
        { 
            EnsureFileExist validator = new EnsureFileExist();
            FileReader reader = new FileReader(validator);
            var result = reader.ReadFile(@"C:\Users\camil\OneDrive\Desktop\escritorio\Proyectos\RIPS\11285\US011285.txt");

            Assert.IsNotNull(result.ValueResult);   
        }

        [TestMethod]
        public void FileReaderWithInvalidPath_ShouldFalse()
        {
            EnsureFileExist validator = new EnsureFileExist();
            FileReader reader = new FileReader(validator);
            var result = reader.ReadFile(@"C:\Users\camil\OneDrive\Desktop\escritorio\Proyectos\RIPS\Rips Ecopetrol\Rips Ecopetrolp\US001935.txt");

            Assert.IsFalse(result.Success);
        }
        [TestMethod]
        public void FileReaderWithEmptyValues_ShouldFalse()
        {
            EnsureFileExist validator = new EnsureFileExist();
            FileReader reader = new FileReader(validator);
            var result = reader.ReadFile(@"C:\Users\camil\OneDrive\Desktop\escritorio\Proyectos\RIPS\Rips Ecopetrol\Rips Ecopetrol\prueba.txt");

            Assert.IsFalse(result.Success);
        }
    }
}
