namespace Observer.Exercise;

public interface IDownloaderListener
{
    void OnPercentageUpdate(int percentage);
}
