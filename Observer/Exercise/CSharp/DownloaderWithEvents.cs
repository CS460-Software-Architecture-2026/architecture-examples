namespace Observer.Exercise.OOP;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.
public class DownloaderWithEvents
{
    public event Action<int>? ProgressChanged; // null until someone subscribes
 
    private int _progress = 0;
 
    public void UpdateProgress(int percentage)
    {
        if (percentage == _progress)
        {
            return; // no change, no notification
        }
 
        _progress = percentage;
        ProgressChanged?.Invoke(percentage);
    }
}
