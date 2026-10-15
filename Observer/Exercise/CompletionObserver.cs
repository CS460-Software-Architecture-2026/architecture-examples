using System;

namespace Observer.Exercise;

public class CompletionObserver : IObserver
{
    public void Update(int progress)
    {
        if (progress == 100)
        {
            Console.WriteLine("Download complete");
        }
    }
}