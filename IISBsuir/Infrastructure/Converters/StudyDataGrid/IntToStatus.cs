using System;
using System.Globalization;
using System.Windows.Data;

namespace IISBsuir.Infrastructure.Converters.StudyDataGrid
{
    internal class IntToStatus : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var status = int.Parse(value.ToString());
                if (status == 3)
                    return "#f2dede";

                return "#dff0d8";
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