using System;
using Windows.UI.Xaml.Data;

namespace Twitzer.Converters
{
	class InverseBoolConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, string language)
		{
            return !(bool)value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, string language)
		{
			throw new NotImplementedException("This converter cannot be used in two-way binding.");
		}
	}
}
