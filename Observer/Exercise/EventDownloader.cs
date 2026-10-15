namespace Observer.Exercise;

public class EventDownloader
{
    public event Action<int>? ProgressChanged;
    private int _progress = 0;

    public void UpdateProgress(int percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            throw new Exception("Progress out of range");
        }

        if (_progress == percentage) return;
        
        _progress = percentage;
        
        ProgressChanged?.Invoke(_progress);
    }
}