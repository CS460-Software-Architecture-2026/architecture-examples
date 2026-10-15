namespace Observer.Exercise;

public interface IDownloadListener
{
    void OnProgressChanged(int percentage);
}

public class ProgressDisplay : IDownloadListener
{
    public void OnProgressChanged(int percentage)
    {
        Console.WriteLine($"Progress: {percentage}%");
    }
}

public class CompletionNotifier : IDownloadListener
{
    public void OnProgressChanged(int percentage)
    {
        if (percentage == 100) Console.WriteLine("Download complete");
    }
}
