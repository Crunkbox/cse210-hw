using System;
using System.Net.Sockets;

public class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }
    public string StandardDetails()
    {
        return $"Event: {_title}\nDescription: {_description}\nDate: {_date}\nTime: {_time}\nAddress: {_address.ReturnFullAddress()}";
    }
   public string ShortDesciption(string eventType)
   {
        return $"Type: {eventType}\nTitle: {_title}\nDate: {_date}";
   }
   protected string GetBaseDetails()
   {
    return $"{StandardDetails()}";
   }
}