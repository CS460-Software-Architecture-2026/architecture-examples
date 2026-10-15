using System;

namespace Observer.Exercise;

public class ProgressObserver : IObserver
{
    public void Update(int progress)
    {
        Console.WriteLine($"Progress: {progress}%");
    }
}