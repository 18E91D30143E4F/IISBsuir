using System;
using System.Globalization;
using System.Windows.Data;

namespace IISBsuir.Infrastructure.Converters.StudyDataGrid
{
    internal class StatusToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var val = value.ToString();
                if (val.Contains("Напечатана", StringComparison.CurrentCultureIgnoreCase))
                    return "#dff0d8"; // Green
                return "#f2dede"; // Red
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "White";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}