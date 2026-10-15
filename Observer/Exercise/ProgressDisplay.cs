namespace Observer.Exercise;

public class ProgressDisplay : IDownloadListener
{
    public void OnProgressChanged(int percentage)
    {
        Console.WriteLine($"{percentage}%");
    }
}