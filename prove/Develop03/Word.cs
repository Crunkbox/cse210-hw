using System;
using System.Collections.Concurrent;

public class Word
{
    private string _word;
    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;

    }
    public void Hide()
    {
        if (!_isHidden)
        {
            _isHidden = true;
        }
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string Show()
    {
        return _isHidden ? new string('_', _word.Length) : _word;
    }
}