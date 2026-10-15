namespace Observer.Exercise;

public class Downloader
{
    private int progress;

    private readonly List<IDownloadListener> listeners = new();

    public Downloader()
    {
        listeners.Add(new ProgressDisplay());
        listeners.Add(new CompletionNotification());
    }

    public void AddListener(IDownloadListener listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(IDownloadListener listener)
    {
        listeners.Remove(listener);
    }

    public void UpdateProgress(int percentage)
    {
        if (progress == percentage)
        {
            return;
        }

        progress = percentage;

        foreach (var listener in listeners)
        {
            listener.OnProgressChanged(progress);
        }
    }
}