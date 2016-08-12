using System;
using Windows.UI.Xaml.Data;

namespace XamBindingSample.Helpers
{
    public class BoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var input = (bool)value;
            return input ? "TTT" : "FFF";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var input = (string)value;
            return input == "TTT";
        }
    }
}
