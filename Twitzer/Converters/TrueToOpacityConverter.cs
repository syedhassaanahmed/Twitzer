using System;
using Windows.UI.Xaml.Data;

namespace Twitzer.Converters
{
    class TrueToOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (bool) value ? 0.5 : 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
