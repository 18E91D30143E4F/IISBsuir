using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace IISBsuir.Infrastructure.Converters
{
    internal class ValueToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
                return new SolidColorBrush(Colors.Black);

            var firstVal = values[0].ToString()
                .Trim('(', ')', '*');
            var secondVal = values[1].ToString();

            if (secondVal.Contains("зач"))
                return new SolidColorBrush(Colors.Green);

            if (!double.TryParse(firstVal, NumberStyles.Any, CultureInfo.InvariantCulture, out var leftValue) ||
                !double.TryParse(secondVal, NumberStyles.Any, CultureInfo.InvariantCulture, out var rightValue))
                return new SolidColorBrush(Colors.Black);

            return leftValue > rightValue ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.Green);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}