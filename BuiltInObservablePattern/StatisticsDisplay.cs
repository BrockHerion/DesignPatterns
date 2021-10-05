using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiltInObservablePattern
{
    public class StatisticsDisplay : IObserver<WeatherData>, IDisplayElement
    {
        private float _maxTemp = 0.0f;
        private float _minTemp = 200.0f;
        private float _tempSum = 0.0f;
        private int _numReadings;
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

        /// <summary>
        /// Updates the current weather data
        /// </summary>
        /// <param name="weatherData"></param>
        public virtual void OnNext(WeatherData weatherData)
        {
            _tempSum += weatherData.Temperature;
            _numReadings++;

            if (weatherData.Temperature > _maxTemp)
                _maxTemp = weatherData.Temperature;

            if (weatherData.Temperature < _minTemp)
                _minTemp = weatherData.Temperature;

            Display();
        }

        public virtual void Display()
        {
            Console.WriteLine($"Avg/Max/Min temperature = {_tempSum / _numReadings}/{_maxTemp}/{_minTemp}");
        }
    }
}
