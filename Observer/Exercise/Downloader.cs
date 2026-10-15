namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.
public interface IProgressObserver
{
    void OnProgressChanged(int percentage);
}

public class Downloader
{
    private int _progress = 0;
    private readonly List<IProgressObserver> _observers = new();
    public void Subscribe(IProgressObserver observer) => _observers.Add(observer);
    public void Unsubscribe(IProgressObserver observer)=> _observers.Remove(observer);


    public void UpdateProgress(int percentage)
    {
        if (percentage == _progress) return;
        _progress = percentage;

        foreach (var observer in _observers)
            observer.OnProgressChanged(_progress);
    }
}


public class ProgressDisplay : IProgressObserver
{
    public void OnProgressChanged(int percentage)
    {
        Console.WriteLine($"Progress: {percentage}%");
    }
}

public class CompletionNotifier : IProgressObserver
{
    public void OnProgressChanged(int percentage)
    {
        if (percentage == 100)
            Console.WriteLine("Download complete");
    }
}
