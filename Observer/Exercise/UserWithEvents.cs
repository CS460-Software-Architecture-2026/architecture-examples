namespace Observer.Exercise;

public class UserWithEvents
{
    public bool IsInterestedInProgress(int percentage) => true;
    public bool IsInterestedInCompletion() => true;
    
    public void SubscribeTo(DownloaderWithEvents downloader)
    {
        downloader.OnProgressChanged += OnProgressChanged;
        downloader.OnCompleted += OnCompleted;
    }

    public void OnProgressChanged(int percentage)
    {
        if (!IsInterestedInProgress(percentage))
        {
            return;
        }
        
        Console.WriteLine(percentage + "%");
    }

    private void OnCompleted()
    {
        if (!IsInterestedInCompletion())
        {
            return;
        }
        
        Console.WriteLine("Download complete");
    }
}