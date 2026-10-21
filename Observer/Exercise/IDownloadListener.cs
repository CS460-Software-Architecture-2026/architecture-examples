namespace Observer.Exercise;

public interface IDownloadListener
{
    void OnProgressChanged(int percentage);
}