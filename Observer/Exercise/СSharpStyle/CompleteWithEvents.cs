namespace Observer.Exercise.СSharpStyle;

public class CompleteWithEvents
{
    public void SubscribeTo(DownloaderWithEvent downloader)
    {
        downloader.OnProgressChanged += OnProgressChanged;
    }
    
    public void OnProgressChanged(int progress)
    {
        if (progress == 100)
        {
            Console.WriteLine("Download complete");
        }
    }
}