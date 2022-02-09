using System;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using IIsHelper.Models;

namespace IISBsuir.Infrastructure.Converters
{
    public class SkillsToStr : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var skills = value as StudentSkill[];
            var sb = new StringBuilder();
            foreach (var skill in skills)
                sb.Append($"{skill.Name} ");

            return sb.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}