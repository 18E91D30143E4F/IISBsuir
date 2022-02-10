using System;
using System.Globalization;
using System.Windows.Data;

namespace IISBsuir.Infrastructure.Converters
{
    internal class GridMarkToString : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (values[1] == null)
                    return values[0];
                if (values[0] is null || values[0] == string.Empty)
                    return $"*({values[1]:F1})";
                var mark1 = double.Parse(values[0] as string ?? string.Empty, CultureInfo.InvariantCulture);
                var mark2 = (double)values[1];

                return $"{mark1} *({mark2:F1})";
            }
            catch
            {
                return values;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}