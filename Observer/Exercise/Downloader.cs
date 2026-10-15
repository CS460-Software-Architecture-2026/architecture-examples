namespace Observer.Exercise;

// Variant 1: Observer with interface

public interface IProgressObserver
{
    void Update(int percentage);
}

public class ProgressDisplay : IProgressObserver
{
    public void Update(int percentage)
    {
        Console.WriteLine("Progress: " + percentage + "%");
    }
}

public class CompletionNotifier : IProgressObserver
{
    public void Update(int percentage)
    {
        if (percentage == 100)
        {
            Console.WriteLine("Download complete");
        }
    }
}

public class Downloader
{
    private List<IProgressObserver> observers = new List<IProgressObserver>();
    private int progress = 0;

    public void Subscribe(IProgressObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(IProgressObserver observer)
    {
        observers.Remove(observer);
    }

    public void UpdateProgress(int percentage)
    {
        if (percentage == progress)
        {
            return;
        }

        progress = percentage;

        foreach (IProgressObserver observer in observers)
        {
            observer.Update(progress);
        }
    }
}