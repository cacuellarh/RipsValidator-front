

using Backend.RipsValidator.Domain;
using Backend.RipsValidator.Domain.Handler.Validation;
using Backend.RipsValidator.Domain.Rules.RuleTypes;
using Backend.RipsValidator.Domain.Rules.TypeFiles;
using Backend.RipsValidator.Infraestructure.StreamFile;
using System.Collections.Generic;

namespace Test.RipsValidator.Domain.RulesTypes
{
    [TestClass]
    public class USRulesTypesTest
    {
        [TestMethod]
        public void AddValuesWithValidTypes_ShouldTrue()
        {
            EnsureFileExist validator = new EnsureFileExist();
            FileReader reader = new FileReader(validator);
            var result = reader.ReadFile(@"C:\Users\camil\OneDrive\Desktop\escritorio\Proyectos\RIPS\11285\US011285.txt");

            ValidationHandler handler = new ValidationHandler();
            USRulesTypes typesValidator = new USRulesTypes(handler);

            US us = new US(typesValidator);
            var resultValidation = us.ValidateTypes(result.ValueResult);

            Assert.IsTrue(resultValidation.Success);
        }
        [TestMethod]
        public void AddValuesWithInvalidCCField_ShouldFalse()
        {
            EnsureFileExist validator = new EnsureFileExist();
            FileReader reader = new FileReader(validator);
            var result = reader.ReadFile(@"C:\Users\camil\OneDrive\Desktop\escritorio\Proyectos\RIPS\Rips Ecopetrol\Rips Ecopetrol\US001935_invalid_CC.txt");

            ValidationHandler handler = new ValidationHandler();
            USRulesTypes typesValidator = new USRulesTypes(handler);

            US us = new US(typesValidator);
            var resultValidation = us.ValidateTypes(result.ValueResult);

            Assert.IsFalse(resultValidation.Success);
        }
    }
}
