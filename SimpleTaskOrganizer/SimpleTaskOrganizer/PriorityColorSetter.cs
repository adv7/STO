using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SimpleTaskOrganizer
{
    public class PriorityColorSetter : IValueConverter
    {
        //TODO add more colors
        private string[] _priorityBackGroundColor = { "#86A84E", "#C8D584", "#DBBD5C", "#D77F49", "#BE525C" };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var priority = (byte)value;

            switch (priority)
            {
                case 1:
                    return _priorityBackGroundColor[0];
                case 2:
                    return _priorityBackGroundColor[1];
                case 3:
                    return _priorityBackGroundColor[2];
                case 4:
                    return _priorityBackGroundColor[3];
                case 5:
                    return _priorityBackGroundColor[4];
                default:
                    throw new ArgumentException("WARN: Invalid priority value.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
