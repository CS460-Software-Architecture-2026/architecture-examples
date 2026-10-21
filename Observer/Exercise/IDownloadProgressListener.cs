namespace Observer.Exercise;

public interface IDownloadProgressListener
{
    void OnDownloadProgressChanged(int percentage);
}