namespace Observer.Exercise.СSharpStyle;

public class DownloaderWithEvent
{
    public event Action<int> OnProgressChanged;
    private int currentProgress = 0;

    public void OnProgress(int progress)
    {
        if (progress == currentProgress) return;
        
        currentProgress = progress;
        OnProgressChanged?.Invoke(progress);
    }
}