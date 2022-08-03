using System;
using System.Collections.Generic;

namespace Design_Browser_History
{
  class Program
  {
    static void Main(string[] args)
    {
      BrowserHistory browserHistory = new BrowserHistory("leetcode.com");
      browserHistory.Visit("google.com");
      browserHistory.Visit("facebook.com");
      browserHistory.Visit("youtube.com");
      var answer = browserHistory.Back(1);
      Console.WriteLine(answer);
      answer = browserHistory.Back(1);
      Console.WriteLine(answer);
      answer = browserHistory.Forward(1);
      Console.WriteLine(answer);
      browserHistory.Visit("linkedin.com");
      answer = browserHistory.Forward(2);
      Console.WriteLine(answer);
      answer = browserHistory.Back(2);
      Console.WriteLine(answer);
      answer = browserHistory.Back(7);
      Console.WriteLine(answer);
    }
  }

  public class BrowserHistory
  {
    Stack<string> history;
    Stack<string> future;

    public BrowserHistory(string homepage)
    {
      history = new Stack<string>();
      history.Push(homepage);
      future = new Stack<string>();
    }

    public void Visit(string url)
    {
      history.Push(url);
      future = new Stack<string>();
    }

    public string Back(int steps)
    {
      while (steps > 0 && history.Count > 1)
      {
        future.Push(history.Pop());
        steps--;
      }
      return history.Peek();
    }

    public string Forward(int steps)
    {
      while (steps > 0 && future.Count > 0)
      {
        history.Push(future.Pop());
        steps--;
      }
      return history.Peek();
    }
  }
}
