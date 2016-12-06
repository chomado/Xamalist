using System;
using System.Globalization;
using Xamarin.Forms;
namespace Xamalist.Commons
{
    public class UrlToVisibleConverter : IValueConverter
    {
        public UrlToVisibleConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // GitHub の URL が空だったら false、存在していたら true を返す
            var gitHubUrl = (string)value;
            return !string.IsNullOrEmpty(gitHubUrl);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
