using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Weather
{
    public class ForecastDisplay : IObserver, IDisplayElement
    {
        private float _currentPressure = 29.92f;
        private float _lastPressure;
        private ISubject _weatherDataSubject;

        public ForecastDisplay(ISubject weatherDataSubject)
        {
            _weatherDataSubject = weatherDataSubject;
            _weatherDataSubject.RegisterObserver(this);
        }

        public void Update(WeatherData weatherData)
        {
            _lastPressure = _currentPressure;
            _currentPressure = weatherData.Pressure;
            Display();
        }

        public void Display()
        {
            Console.Write("Forecast: ");
            if (_currentPressure > _lastPressure)
                Console.WriteLine("Improving weather on the way!");
            else if (_currentPressure == _lastPressure)
                Console.WriteLine("More of the same");
            else
                Console.WriteLine("Watch out for cooler, rainy weather");
        }
    }
}
