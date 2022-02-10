using System;
using System.Globalization;
using System.Windows.Data;

namespace IISBsuir.Infrastructure.Converters
{
    internal class RetakesToString : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (values[1] != null)
                    return $"{values[0]} ({100 * double.Parse(values[1].ToString()):F1}%)";
                return $"{values[0]}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return string.Empty;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}