namespace Observer.Exercise;

public interface IProgressListener
{
    void OnProgressChanged(int percentage);
}