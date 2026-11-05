namespace Observer.Exercise;

public class EventStyleListener
{
    public void Subscribe(Downloader downloader)
    {
        downloader.ProgressChanged += OnProgressUpdated;
    }

    public void Unsubscribe(Downloader downloader)
    {
        downloader.ProgressChanged -= OnProgressUpdated;
    }

    private void OnProgressUpdated(int percentage)
    {
        if (percentage == 100)
        {
            Console.WriteLine("Download complete");
        }
    }
}
