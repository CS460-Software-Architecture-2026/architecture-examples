namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.
public interface Downloader {
    public void UpdateProgress(int percentage);
}

public class ListenerDownloader : Downloader
{
    private List<IDownloadListener> listeners = new();
    private int progress;

    public void Subscribe(IDownloadListener listener)
    {
        if (!listeners.Contains(listener)) listeners.Add(listener);
    }

    public void Unsubscribe(IDownloadListener listener)
    {
        listeners.Remove(listener);
    }

    public void UpdateProgress(int percentage)
    {
        if (percentage == progress) return;
        progress = percentage;
        foreach (var listener in listeners.ToList()) listener.OnProgressChanged(progress);
    }
}

public class EventDownloader : Downloader
{
    public event Action<int>? ProgressChanged;
    private int progress;

    public void UpdateProgress(int percentage)
    {
        if (percentage == progress) return;
        progress = percentage;
        ProgressChanged?.Invoke(progress);
    }
}
