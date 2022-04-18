using System;
using BuiltInObservablePattern;

var provider = new WeatherDataHander();

var currentConditionsDisplay = new CurrentConditionsDisplay();
var statisticsDisplay = new StatisticsDisplay();
var forecastDisplay = new ForecastDisplay();

provider.WeatherData = new WeatherData(80.0f, 65.0f, 30.4f);

currentConditionsDisplay.Subscribe(provider);
statisticsDisplay.Subscribe(provider);
forecastDisplay.Subscribe(provider);

Console.WriteLine();

forecastDisplay.Unsubscribe();

provider.WeatherData = new WeatherData(82.0f, 70.0f, 29.2f);

Console.WriteLine();

statisticsDisplay.Unsubscribe();

provider.WeatherData = new WeatherData(78.0f, 90.0f, 29.2f);

