using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Data;
using System.Globalization;

namespace WpGatekeeper.Converters
{
    public class PhoneNumberConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string numberString;
            long number = (long)value;

            numberString = string.Format("{0:D4}", number % 10000);
            number /= 10000;
            numberString = string.Format("{0:D3}-{1}", number % 1000, numberString);
            number /= 1000;
            numberString = string.Format("({0:D3}) {1}", number % 1000, numberString);

            return numberString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
