using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Baudi.Client.Converters
{
    public class BoolToTextConverter : IValueConverter
    {


    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var boolValue = value is bool && (bool) value;

        return boolValue ? "Tak" : "Nie";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value != null && value.ToString() == "Tak";
    }

    }
}
