using System;
using System.Collections.Generic;

public class Video
{
    private string _author;
    private string _title;
    private string _videoLength;
    private List<Comment> _comments;

    public Video()
    {
        _comments = new List<Comment>();
    }
    public void SetAuthor(string author)
    {
        _author = author;
    }
    public string GetAuthor()
    {
        return _author;
    }
    public void SetTitle(string title)
    {
        _title = title;
    }
    public string GetTitle()
    {
        return _title;
    }
    public void SetVideoLength(string videoLength)
    {
        _videoLength = videoLength;
    }
    public string GetVideoLength()
    {
        return _videoLength;
    }
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }
    public void Display()
    {
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_videoLength}");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");

        foreach (var comment in _comments)
        {
            Console.WriteLine($"- {comment.GetUsername()}: {comment.GetComment()}");
        }
    }
}