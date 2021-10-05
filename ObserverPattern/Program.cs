using ObserverPattern;

var WeatherDataSubject = new WeatherDataSubject();

var CurrentConidtionsDisplay = new CurrentConditionsDisplay(WeatherDataSubject);
var StatisticsDisplay = new StatisticsDisplay(WeatherDataSubject);
var ForecastDisplay = new ForecastDisplay(WeatherDataSubject);

WeatherDataSubject.WeatherData = new WeatherData(80.0f, 65.0f, 30.4f);
WeatherDataSubject.WeatherData = new WeatherData(82.0f, 70.0f, 29.2f);
WeatherDataSubject.WeatherData = new WeatherData(78.0f, 90.0f, 29.2f);