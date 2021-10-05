using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiltInObservablePattern
{
    public class ForecastDisplay : IObserver<WeatherData>, IDisplayElement
    {
        private float _currentPressure = 29.92f;
        private float _lastPressure;
        private IDisposable cancellation;

        /// <summary>
        /// Allows the observer to subscribe itself to a handler
        /// </summary>
        /// <param name="provider"></param>
        public virtual void Subscribe(WeatherDataHander provider)
        {
            cancellation = provider.Subscribe(this);
        }

        /// <summary>
        /// Unsubscribes an the observer from the handler
        /// </summary>
        public virtual void Unsubscribe()
        {
            cancellation.Dispose();
        }

        // Do nothing, no implementation needed
        public virtual void OnCompleted() { }

        // Do nothing, no implementation needed
        public virtual void OnError(Exception e) { }

        public virtual void OnNext(WeatherData weatherData)
        {
            _lastPressure = _currentPressure;
            _currentPressure = weatherData.Pressure;
            Display();
        }

        public virtual void Display()
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
