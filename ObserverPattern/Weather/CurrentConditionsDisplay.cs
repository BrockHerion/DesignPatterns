using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Weather
{
    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private ISubject _weatherDataSubject;
        private WeatherData _weatherData;

        public CurrentConditionsDisplay(ISubject weatherDataSubject)
        {
            _weatherDataSubject = weatherDataSubject;
            _weatherDataSubject.RegisterObserver(this);

            _weatherData = new WeatherData(0.0f, 0.0f, 0.0f);
        }

        public void Update(WeatherData weatherData)
        {
            _weatherData = weatherData;
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"Current Conditions: {_weatherData.Temperature}F degrees and {_weatherData.Humidity}% humidity");
        }
    }
}
