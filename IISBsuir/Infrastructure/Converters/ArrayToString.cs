using System;
using System.Globalization;

namespace IISBsuir.Infrastructure.Converters
{
    internal class ArrayToString : MultiConverter
    {
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Join(' ', values);
        }
    }
}