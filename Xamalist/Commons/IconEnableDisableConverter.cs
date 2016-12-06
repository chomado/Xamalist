using System;
using System.Globalization;
using Xamarin.Forms;

namespace Xamalist.Commons
{
	public class IconEnableDisableConverter : IValueConverter
	{
		public IconEnableDisableConverter()
		{
		}

		// ViewModel から画面に行くときの変換処理
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var osName = (string)parameter;
			var storeUrl = (string)value;

			// ストアのURLが空だったら
			if (string.IsNullOrEmpty(storeUrl))
			{
				return $"{osName}Disable.png";
			}
			return $"{osName}Enable.png";
		}

		// 画面から ViewModel に行くときの変換処理
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
