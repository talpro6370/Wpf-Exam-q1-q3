using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace q1
{
    public class SliderValueWidthConverter : IValueConverter
    {
        public Double maximumWidthValue = 250;
        
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int SliderValue = System.Convert.ToInt32(value);
            if (SliderValue <= maximumWidthValue*0.25)
            { // 250 - 100%
                
                return "SMALL";
            }
            if (SliderValue > maximumWidthValue * 0.25 && SliderValue <= maximumWidthValue * 0.5)
            {
                return "MEDIUM";
            }
            if (SliderValue > maximumWidthValue * 0.5 && SliderValue <= maximumWidthValue * 0.75)
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
