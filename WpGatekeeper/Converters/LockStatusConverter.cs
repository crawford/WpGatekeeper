using WpGatekeeper.Models;
using System.Windows.Data;
using System;
using System.Globalization;

namespace WpGatekeeper.Converters
{
    public class LockStatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Door.LockStatus status = (Door.LockStatus)value;

            return status.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string status = (string)value;
            switch (status.ToLower())
            {
                case "locked":
                    return Door.LockStatus.LOCKED;
                case "unlocked":
                    return Door.LockStatus.UNLOCKED;
                case "unknown":
                    return Door.LockStatus.UNKNOWN;
                default:
                    throw (new ArgumentException("Invalid lock status"));
            }
        }
    }
}
