using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace q1
{
    public class SliderValueHeightConverter : IValueConverter
    {
        public Double maximumHeightValue = 250;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int SliderValue = System.Convert.ToInt32(value);
            if (SliderValue <= maximumHeightValue*0.25)
            {
                return "SMALL";
            }
            if (SliderValue > maximumHeightValue * 0.25 && SliderValue <= maximumHeightValue * 0.5)
            {
                return "MEDIUM";
            }
            if (SliderValue > maximumHeightValue * 0.5 && SliderValue <= maximumHeightValue * 0.75)
            {
                return "LARGE"; 

            }
                return "EXTRA LARGE";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
