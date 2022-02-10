using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Windows.Data;
using IIsHelper.Models;

namespace IISBsuir.Infrastructure.Converters
{
    public class StrToMarkPage : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var key = value as string;
            var markBook = parameter as MarkBook;

            return markBook.MarkPages[key];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}