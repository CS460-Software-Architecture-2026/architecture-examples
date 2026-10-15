namespace Observer.Exercise.СSharpStyle;

public class ProgressChangeWithEvents
{
    public void SubscribeTo(DownloaderWithEvent downloader)
    {
        downloader.OnProgressChanged += OnProgressChanged;
    }

    public void OnProgressChanged(int progress)
    {
       Console.WriteLine(progress);
    }
}