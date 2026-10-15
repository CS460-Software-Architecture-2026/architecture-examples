namespace Observer.Exercise;

public class EventDownloader
{
    private int _progress = 0;

    public event Action<int>? ProgressChanged;
    public event Action? DownloadCompleted;

    public void UpdateProgress(int percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            throw new ArgumentOutOfRangeException(
                nameof(percentage),
                "Progress must be between 0 and 100.");
        }

        if (_progress == percentage)
        {
            return;
        }

        _progress = percentage;

        ProgressChanged?.Invoke(_progress);

        if (_progress == 100)
        {
            DownloadCompleted?.Invoke();
        }
    }
}