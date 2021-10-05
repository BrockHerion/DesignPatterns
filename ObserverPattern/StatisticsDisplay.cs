using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        private float _maxTemp = 0.0f;
        private float _minTemp = 200.0f;
        private float _tempSum = 0.0f;
        private int _numReadings;
        private ISubject _weatherDataSubject;

        public StatisticsDisplay(ISubject weatherDataSubject)
        {
            _weatherDataSubject = weatherDataSubject;
            _weatherDataSubject.RegisterObserver(this);
        }

        public void Update(WeatherData weatherData)
        {
            _tempSum += weatherData.Temperature;
            _numReadings++;

            if (weatherData.Temperature > _maxTemp) 
                _maxTemp = weatherData.Temperature;

            if (weatherData.Temperature < _minTemp)
                _minTemp = weatherData.Temperature;

            Display();
        }

        public void Display()
        {
            Console.WriteLine($"Avg/Max/Min temperature = {_tempSum / _numReadings}/{_maxTemp}/{_minTemp}");
        }
    }
}
