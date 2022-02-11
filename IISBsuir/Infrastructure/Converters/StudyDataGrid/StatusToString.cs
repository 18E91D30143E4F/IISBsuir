using System;
using System.Globalization;
using System.Windows.Data;

namespace IISBsuir.Infrastructure.Converters.StudyDataGrid
{
    internal class StatusToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var status = int.Parse(value.ToString());
                if (status == 3)
                    return "Отклонена";

                return "Напечатана";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}