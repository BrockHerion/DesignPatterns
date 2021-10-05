using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiltInObservablePattern
{
    public class CurrentConditionsDisplay : IObserver<WeatherData>, IDisplayElement
    {
        private WeatherData _weatherData;
        private IDisposable cancellation;

        public CurrentConditionsDisplay()
        {
            _weatherData = new WeatherData(0.0f, 0.0f, 0.0f);
        }

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
            _weatherData = weatherData;
            Display();
        }

        public virtual void Display()
        {
            Console.WriteLine($"Current Conditions: {_weatherData.Temperature}F degrees and {_weatherData.Humidity}% humidity");
        }
    }
}
