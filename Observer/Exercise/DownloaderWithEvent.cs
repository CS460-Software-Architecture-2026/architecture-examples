namespace Observer.Exercise;
public class DownloaderWithEvent
{
    private int _progress = 0;
    public event Action<int>? ProgressChanged;
    
    public void UpdateProgress(int percentage)
    {
        if (percentage == _progress) return;
        _progress = percentage;

        ProgressChanged?.Invoke(_progress);
    }
}

public class ProgressDisplayWithEvent
{
    public void SubscribeTo(DownloaderWithEvent downloader)
    {
        downloader.ProgressChanged += OnProgressChanged;
    }

    public void UnsubscribeFrom(DownloaderWithEvent downloader)
    {
        downloader.ProgressChanged -= OnProgressChanged;
    }

    public void OnProgressChanged(int percentage)
    {
        Console.WriteLine($"Progress: {percentage}%");
    }
}

public class CompletionNotifierWithEvent
{
    public void SubscribeTo(DownloaderWithEvent downloader)
    {
        downloader.ProgressChanged += OnProgressChanged;
    }
    public void OnProgressChanged(int percentage)
    {
        if (percentage == 100)
            Console.WriteLine("Download complete");
    }
}