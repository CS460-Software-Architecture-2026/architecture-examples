namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.

public class Downloader
{
    private readonly List<IDownloadObserver> _observers = new();
    private int _progress = 0;

    public void Subscribe(IDownloadObserver observer)
    {
        ArgumentNullException.ThrowIfNull(observer);

        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }
    }

    public void Unsubscribe(IDownloadObserver observer)
    {
        _observers.Remove(observer);
    }

    public void UpdateProgress(int percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            throw new ArgumentOutOfRangeException(
                nameof(percentage),
                "Progress must be between 0 and 100.");
        }

        if (_progress == percentage)
        {
            return;
        }

        _progress = percentage;

        foreach (var observer in _observers.ToArray())
        {
            observer.OnProgressChanged(_progress);
        }
    }
}
