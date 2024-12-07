using System;

public class Comment
{
    private string _userName;
    private string _comment;

    public Comment(string userName, string comment)
    {
        _userName = userName;
        _comment = comment;
    }
    public void SetUsername(string userName)
    {
        _userName = userName;
    }
    public string GetUsername()
    {
        return _userName;
    }
    public void SetComment(string comment)
    {
        _comment = comment;
    }
    public string GetComment()
    {
        return _comment;
    }
}