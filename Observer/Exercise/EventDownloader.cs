namespace Observer.Exercise;

public class EventDownloader
{
    private int progress;
    public event Action<int>? ProgressChanged;

    public void UpdateProgress(int percentage) {
        if (percentage == progress) {
            return;
        }

        progress = percentage;
        ProgressChanged?.Invoke(percentage);
    }
}
