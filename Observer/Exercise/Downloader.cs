namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.

public interface IProgressObserver
{
    void OnProgressUpdate(int percentage);
}

public class Downloader
{
    private readonly List<IProgressObserver> observers = new();
    private int _progress = 0;
    
    public void UpdateProgress(int percentage)
    {
        // TODO: Update progress and notify subscribers.
        if (percentage < 0 || percentage > 100)
        {
            throw new Exception("Progress out of range");
        }

        if (_progress == percentage) return;
        
        _progress = percentage;

        foreach (var observer in observers)
        {
            observer.OnProgressUpdate(percentage);
        }
    }

    public void Subscribe(IProgressObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(IProgressObserver observer)
    {
        observers.Remove(observer);
    }
}

public class DisplayProgress : IProgressObserver
{
    public void OnProgressUpdate(int percentage)
    {
        Console.WriteLine($"{percentage}%");
    }
}

public class NotifyOnComplete : IProgressObserver
{
    public void OnProgressUpdate(int percentage)
    {
        if (percentage == 100)
        {
            Console.WriteLine($"Completed");
        }
    }
}