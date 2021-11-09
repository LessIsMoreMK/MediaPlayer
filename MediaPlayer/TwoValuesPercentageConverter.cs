using System;
using System.Globalization;
using System.Windows.Data;

namespace MediaPlayer
{
    public class TwoValuesPercentageConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var watchedTime = (double)values[0];
            var totalTime = (double)values[1];

            return watchedTime/totalTime;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
