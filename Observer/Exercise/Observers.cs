namespace Observer.Exercise;

public interface IDownloadObserver
{
    void OnProgressChanged(int percentage);
}

public class ProgressDisplayObserver : IDownloadObserver
{
    public void OnProgressChanged(int percentage)
    {
        Console.WriteLine($"Progress: {percentage}%");
    }
}

public class CompletionObserver : IDownloadObserver
{
    public void OnProgressChanged(int percentage)
    {
        if (percentage == 100)
        {
            Console.WriteLine("Download complete");
        }
    }
}