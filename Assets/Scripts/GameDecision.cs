using System;
using System.Collections.Generic;
public class GameDecision
{
    public string Title;

    public GameDecision(string title)
    {
        Title = title;
    }

    public override string ToString()
    {
        return Title;
    }
}
