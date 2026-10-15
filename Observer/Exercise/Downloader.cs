namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.
// OOP
public class Downloader
{
    private int progress = 0;
    private readonly List<IProgressListener> progressListeners = new();
    private readonly List<ICompletionListener> completionListeners = new();

    public void AddProgressListener(IProgressListener listener)
    {
        progressListeners.Add(listener);
    }

    public void RemoveProgressListener(IProgressListener listener)
    {
        progressListeners.Remove(listener);
    }
    
    public void AddCompletionListener(ICompletionListener listener)
    {
        completionListeners.Add(listener);
    }

    public void RemoveCompletionListener(ICompletionListener listener)
    {
        completionListeners.Remove(listener);
    }
    public void UpdateProgress(int percentage)
    {
        if (progress >= percentage)
        {
            return;
        }
        
        progress = Math.Clamp(percentage, 0, 100);
        
        foreach (var listener in progressListeners)
        {
            listener.OnProgressChanged(progress);
        }
    
        if (percentage == 100)
        {
            foreach (var listener in completionListeners)
            {
                listener.OnCompleted();
            }
        }
    }
}

// C#
public class DownloaderWithEvents
{
    private int progress = 0;
    public event Action<int> OnProgressChanged;
    public event Action OnCompleted;
    public void UpdateProgress(int percentage)
    {
        if (progress >= percentage)
        {
            return;
        }
        
        progress = Math.Clamp(percentage, 0, 100);
        
        OnProgressChanged?.Invoke(percentage);
        
        if (percentage == 100)
        {
            OnCompleted?.Invoke();
        }
    }
}
