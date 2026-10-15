using System.Net;

namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.

public class Downloader
{
    private readonly List<IDownloadProgressListener> listeners = new();
    private int currentDownloadPercentage = 0;
    
    public void AddListener(IDownloadProgressListener listener) => listeners.Add(listener);
    public void RemoveListener(IDownloadProgressListener listener) => listeners.Remove(listener);
    
    public void UpdateProgress(int percentage)
    {
        if (percentage is < 0 or > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(percentage));
        }
        
        if (currentDownloadPercentage >= percentage)
        {
            return;
        }
        
        currentDownloadPercentage  = percentage;
        foreach (var listener in listeners)
        {
            listener.OnDownloadProgressChanged(currentDownloadPercentage);
        }
    }
}
