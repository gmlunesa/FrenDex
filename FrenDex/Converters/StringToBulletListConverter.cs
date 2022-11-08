using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrenDex.Converters
{
    internal class StringToBulletListConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if(value == null)
                return null;

            if (parameter is null)
                parameter = "-";

            string str = value as string;
            str = $"{parameter} {str}";
            return str.Replace("\n", $"\n{parameter} ");

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();

        }
    }
}
