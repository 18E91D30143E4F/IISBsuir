using System;
using System.Globalization;
using System.Windows.Data;

namespace IISBsuir.Infrastructure.Converters
{
    public abstract class MultiConverter : IMultiValueConverter
    {
        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        public virtual object[] ConvertBack(object v, Type[] tt, object p, CultureInfo c) =>
            throw new NotSupportedException("Не поддерживается");
    }
}