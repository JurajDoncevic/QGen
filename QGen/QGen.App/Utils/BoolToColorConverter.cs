using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace QGen.App.Utils;
internal class BoolToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null)
        {
            return new SolidColorBrush(Colors.Black);
        }
        if (value is bool && (bool)value)
        {
            return new SolidColorBrush(Colors.Green);
        }
        else
        {
            return new SolidColorBrush(Colors.Red);
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is SolidColorBrush && ((SolidColorBrush)value).Color == Colors.Black)
        {
            return null;
        }
        return value is SolidColorBrush && ((SolidColorBrush)value).Color == Colors.Green;
    }
}
