using System;
using System.Globalization;
using System.Windows.Data;

namespace IISBsuir.Infrastructure.Converters
{
    public class MarkToColorString : IMultiValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var markStr = parameter as string;
                var commonMarkStr = value as string;

                if (markStr.Contains("зач", StringComparison.InvariantCultureIgnoreCase))
                    return "Green";

                var mark = double.Parse(markStr);
                var commonMark = double.Parse(commonMarkStr);
                if (mark > commonMark)
                    return "Green";

                return "Red";
            }
            catch
            {
                return "Black";
            }
        }

        public object[] ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}