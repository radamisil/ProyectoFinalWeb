using System.ComponentModel.DataAnnotations;

namespace AdondeVamos.Model.GenericClass
{
    public class MinValueAttribute : ValidationAttribute
    {
        private readonly double MinValue;

        public MinValueAttribute(double minValue, string errorMessage)
        {
            MinValue = minValue;
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            if (value != null)
            {
                return GetDecimal(value) >= (decimal)MinValue;
            }
            else
            {
                return true;
            }
        }

        public static decimal GetDecimal(object value)
        {
            if (value is int)
            {
                return (decimal)((int)value);
            }
            if (value is long)
            {
                return (decimal)((long)value);
            }
            return (decimal)value;
        }
    }
}