using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public record WeatherData(float Temperature, float Humidity, float Pressure);

    public class WeatherDataSubject : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private WeatherData _weatherData;

        public WeatherData WeatherData
        {
            get => _weatherData;
            set
            {
                _weatherData = value;
                MeasurementsChanged();
            }
        }

        public WeatherDataSubject()
        {
            _weatherData = new WeatherData(0.0f, 0.0f, 0.0f);
        }

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_weatherData);
            }
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }
    }
}
