namespace Observer.Exercise;

// one prints progress after each change,
public class ProgressPrinter : IProgressListener
{
    public void OnProgressChanged(int percentage)
    {
        Console.WriteLine(percentage);
    }
}