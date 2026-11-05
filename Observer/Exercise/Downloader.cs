using IDownloaderListener = Observer.Exercise.IDownloaderListener;

namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.
public class Downloader
{
    private readonly List<IDownloaderListener> listeners = new();
    private int currentProgress;

    public event Action<int>? ProgressChanged;

    public void AddListener(IDownloaderListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(IDownloaderListener listener)
    {
        listeners.Remove(listener);
    }

    public void UpdateProgress(int percentage)
    {
        if (percentage == currentProgress)
        {
            return;
        }

        currentProgress = percentage;

        foreach (var listener in listeners)
        {
            listener.OnPercentageUpdate(percentage);
        }

        ProgressChanged?.Invoke(percentage);
    }
}
