using System.Globalization;

namespace Lab5.UI.ValueConverters;

public class PositionToColorValueConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if ((int)value < 6)
            return Colors.LightGreen;
        else if ((int)value > 15)
            return Colors.LightPink;

        return Colors.WhiteSmoke;
    }
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
