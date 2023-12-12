using System.Globalization;

namespace ResponsiveDesign
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
    }

    public class GreaterThanConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (!double.TryParse(value?.ToString(), out double parsedValue) ||
                !double.TryParse(parameter?.ToString(), out double parsedParameter))
            {
                return false;
            }

            return parsedValue > parsedParameter;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
