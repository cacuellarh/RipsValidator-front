namespace Presentation.RipsValidator.Helpers.Converter
{
    public class ConverterPrimitives
    {
        public static int ConverterObjToInt(object obj)
        {
            if (int.TryParse(obj.ToString(), out int numberConverter))
            {
                return numberConverter;
            }

            return 0;
        }
    }
}
