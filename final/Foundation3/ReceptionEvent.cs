using System;

public class ReceptionEvent : Event
{
    private string _email;

    public ReceptionEvent(string title, string description, string date, string time, Address address, string email) : base (title, description, date, time, address)
    {
        _email = email;
    }
    public string FullReceptionDetails()
    {
        return $"{GetBaseDetails()}\nType: Reception\n RSVP Email: {_email}";
    }
    public string ReceptionShortDescription()
    {
        return ShortDesciption("Reception");
    }
}