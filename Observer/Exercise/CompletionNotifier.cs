namespace Observer.Exercise;

public class CompletionNotifier : IDownloadProgressListener
{
    public void OnDownloadProgressChanged(int percentage)
    {
        if (percentage == 100)
        {
            Console.WriteLine("[CompletionNotifier] Download complete");
        }
    }
}