namespace Observer.Exercise;

public class EventDownloader
{
    private int currentDownloadPercentage = 0;
    
    public event Action<int>? DownloadProgressUpdate;
    
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
        
        DownloadProgressUpdate?.Invoke(percentage);
    }
}