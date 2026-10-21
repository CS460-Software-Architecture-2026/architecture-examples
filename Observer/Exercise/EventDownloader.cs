namespace Observer.Exercise;

public class EventDownloader
{
    public int Progress { get; private set; }
    public event Action<int>? ProgressChanged;

    public void UpdateProgress(int percentage)
    {
        if (percentage < 0 || percentage > 100)
            throw new ArgumentOutOfRangeException(nameof(percentage), "Progress must be between 0 and 100.");
        if (percentage == Progress)
            return;

        Progress = percentage;
        ProgressChanged?.Invoke(percentage);
    }
}
