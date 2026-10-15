namespace Observer.Exercise;

public class User : IProgressListener, ICompletionListener
{
    public void OnProgressChanged(int percentage)
    {
        Console.WriteLine(percentage + "%");
    }

    public void OnCompleted()
    {
        Console.WriteLine("Download complete");
    }
}