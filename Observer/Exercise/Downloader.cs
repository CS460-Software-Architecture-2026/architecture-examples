namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.

public interface IDownloadListener
{
    void OnProgressChanged(int percentage);
}
public class Downloader
{
    private readonly List<IDownloadListener> listeners = new();
    private int progress = 0;

    public void AddListener(IDownloadListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(IDownloadListener listener)
    {
        listeners.Remove(listener);
    }

    public void UpdateProgress(int percentage)
    {
        if (percentage == progress)
        {
            return;
        }

        progress = percentage;

        foreach (var listener in listeners)
        {
            listener.OnProgressChanged(percentage);
        }
    }
}
public class ProgressMonitor : IDownloadListener
{
    public void OnProgressChanged(int percentage)
    {
        Console.WriteLine($"Progress: {percentage}%");
    }
}
public class NotifyOnComplete : IDownloadListener
{
    public void OnProgressChanged(int percentage)
    {
        if (percentage != 100)
        {
            return;
        }

        Console.WriteLine("Download complete");
    }
}

// C# delegates/events.ver 

public delegate void ProgressChanged(int percentage);

public class Downloaderv2
{
    public ProgressChanged? ProgressChanged { get; set; }
    private int progress = 0;

    public void UpdateProgress(int percentage)
    {
        if (percentage == progress)
        {
            return;
        }

        progress = percentage;
        
        ProgressChanged?.Invoke(percentage);
    }
}
