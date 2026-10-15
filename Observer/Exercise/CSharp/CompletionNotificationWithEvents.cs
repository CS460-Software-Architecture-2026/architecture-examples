namespace Observer.Exercise.CSharp;

public class ProgressDisplayWithEvents
{
    public void SubscribeTo(DownloaderWithEvents downloader)
    {
        downloader.ProgressChanged += OnProgressChanged;
    }
 
    public void UnsubscribeFrom(DownloaderWithEvents downloader)
    {
        downloader.ProgressChanged -= OnProgressChanged;
    }
 
    private void OnProgressChanged(int percentage)
    {
        Console.WriteLine($"Progress: {percentage}%");
    }
}