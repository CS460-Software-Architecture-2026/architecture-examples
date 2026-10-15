namespace Observer.Exercise;

public class ProgressDisplay : IDownloadProgressListener
{
    
    public void OnDownloadProgressChanged(int percentage)
    {
        if (percentage != 100)
        {
            Console.WriteLine($"[ProgressDisplay] Download Progress Changed: {percentage}%");
        }
    }
}