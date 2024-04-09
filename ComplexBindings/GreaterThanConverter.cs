using System.Globalization;

namespace ComplexBindings
{
    public class GreaterThanConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return
                double.TryParse(value?.ToString(), out double parsedValue) &&
                double.TryParse(parameter?.ToString(), out double parsedParameter) &&
                parsedValue > parsedParameter;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
