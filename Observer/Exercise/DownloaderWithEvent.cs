namespace Observer.Exercise;

public class DownloaderWithEvent
{
    private int progress;

    public event Action<int>? ProgressChanged;

    public void UpdateProgress(int percentage)
    {
        if (progress == percentage)
        {
            return;
        }

        progress = percentage;

        ProgressChanged?.Invoke(progress);
    }
}