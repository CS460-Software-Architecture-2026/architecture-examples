namespace Observer.Exercise;

public class OopStyleListener : IDownloaderListener
{
    public void OnPercentageUpdate(int percentage)
    {
        Console.WriteLine($"Progress: {percentage}%");
    }
}
