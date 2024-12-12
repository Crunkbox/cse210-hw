using System;

public class OutdoorEvent : Event
{
    private string _weather;

    public OutdoorEvent(string title, string description, string date, string time, Address address, string weather) : base (title, description, date, time, address)
    {
        _weather = weather;
    }
    public string FullOutdoorDetails()
    {
        return $"{GetBaseDetails()}\nType: Outdoor Gathering\nWeather: {_weather}";
    }
    public string OutdoorShortDescriptions()
    {
        return ShortDesciption("Outdoor Gathering");
    }
}