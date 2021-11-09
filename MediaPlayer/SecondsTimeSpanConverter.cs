
using System;
using System.Globalization;
using System.Windows.Data;

namespace MediaPlayer
{
    [ValueConversion(typeof(double), typeof(TimeSpan))]
    public class SecondsTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return TimeSpan.FromSeconds((double)(value)).ToString(@"hh\:mm\:ss");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
