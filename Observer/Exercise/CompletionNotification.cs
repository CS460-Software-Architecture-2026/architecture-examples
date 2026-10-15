namespace Observer.Exercise;

public class CompletionNotification : IDownloadListener
{
    public void OnProgressChanged(int percentage)
    {
        if (percentage == 100)
        {
            Console.WriteLine("Download complete");
        }
    }
}