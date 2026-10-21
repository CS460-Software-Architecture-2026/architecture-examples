namespace Observer.Exercise

public interface IProgressObserver
{
    void OnProgressChanged(int percentage);
}