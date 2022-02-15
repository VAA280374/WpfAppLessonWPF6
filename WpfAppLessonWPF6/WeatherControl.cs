using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfAppLessonWPF6
{
    internal class WeatherControl : DependencyObject
    {
        public static readonly DependencyProperty TemperatureProperety; // взамен закрытого поля
        //private int temperature;
        private string windDirection;
        private enum precipitation
        {
            Sunny = 0,
            Cloudy = 1,
            Rain = 2,
            Snow = 3,
        };
        public int Temperature
        {
            //get { return temperature; } 
            get => (int) GetValue(TemperatureProperety);
            //set 
            //{
            //    if (value >= -50 && value <= 50) temperature = value;
            //    else
            //    {
            //        if (value < -50) temperature = -50;
            //        if (value > 50) temperature = 50;
            //    }
            //}
            set => SetValue(TemperatureProperety, value);
        }
        public string WindDirection
        {
            get => windDirection; 
            set => windDirection = value; 
        }
        public WeatherControl(int temperature, string windDirection)
        { 
            this.Temperature = temperature;
            this.WindDirection = windDirection;
        }
        static WeatherControl()
        {
            TemperatureProperety = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0, // значение по умолчанию
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender, // набор флагов
                    null, // действия при изменении свойства
                    new CoerceValueCallback(CoerceTemperature)), // действия при коррекции значения
                new ValidateValueCallback(ValidateTemperature)); // экземпляр делегата метода-валидатора
        }

        private static bool ValidateTemperature(object value)
        {
            // throw new NotImplementedException(); // исключение - студия вставляет по умолчанию
            if(t >= -50 && t <= 50) return true;
            else return false;
        }

        private static object CoerceTemperature(DependencyObject d, object baseValue)
        {
            // throw new NotImplementedException(); // исключение - студия вставляет по умолчанию
            int t = (int) baseValue;
            if (t >= -50 && t <= 50) return t;
            else
            {
                if (t < -50) return -50;
                if (t > 50) return 50;
                return 0; // чисто студию "успокоить"
            }

        }
    }
}
