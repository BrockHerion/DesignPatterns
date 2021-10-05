using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiltInObservablePattern
{
    /// <summary>
    /// Handles the 
    /// </summary>
    public class WeatherDataHander : IObservable<WeatherData>
    {
        private List<IObserver<WeatherData>> _observers;
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

        public WeatherDataHander()
        {
            _observers = new List<IObserver<WeatherData>>();
        }

        public IDisposable Subscribe(IObserver<WeatherData> observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
                observer.OnNext(_weatherData);
            }

            return new Unsubscriber<WeatherData>(_observers, observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.OnNext(_weatherData);
            }
        }

        public void MeasurementsChanged()
        {
            NotifyObservers();
        }
    }

    /// <summary>
    /// Removes an observable from the list. Allows observables to stop recieving
    /// notifications before OnComplete() is called.
    /// </summary>
    /// <typeparam name="WeatherData"></typeparam>
    internal class Unsubscriber<WeatherData> : IDisposable
    {
        private List<IObserver<WeatherData>> _observers;
        private IObserver<WeatherData> _obersver;

        internal Unsubscriber(List<IObserver<WeatherData>> observers, IObserver<WeatherData> observer)
        {
            _observers = observers;
            _obersver = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_obersver))
                _observers.Remove(_obersver);
        }
    }
}
