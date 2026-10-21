namespace Observer.Exercise;

// Variant 2: C# delegates/events
public class DownloaderWithEvents
{
    public event Action<int> ProgressChanged;

    private int progress = 0;

    public void UpdateProgress(int percentage)
    {
        if (percentage == progress)
        {
            return; 
        }

        progress = percentage;

        if (ProgressChanged != null)
        {
            ProgressChanged(progress);
        }
    }
}