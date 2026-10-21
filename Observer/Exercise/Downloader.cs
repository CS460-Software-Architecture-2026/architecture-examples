namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.
public class Downloader
{
    private readonly List<IProgressObserver> observers = new();
    public int Progress { get; private set; }

    public void Subscribe(IProgressObserver observer)
    {
        ArgumentNullException.ThrowIfNull(observer);
        if (!observers.Contains(observer))
            observers.Add(observer);
    }

    public void Unsubscribe(IProgressObserver observer)
    {
        observers.Remove(observer);
    }

    public void UpdateProgress(int percentage)
    {
        if (percentage < 0 || percentage > 100)
            throw new ArgumentOutOfRangeException(nameof(percentage), "Progress must be between 0 and 100.");
        if (percentage == Progress)
            return;

        Progress = percentage;
        // A subscriber can unsubscribe during notification.
        foreach (var observer in observers.ToArray())
            observer.OnProgressChanged(percentage);
    }
}
