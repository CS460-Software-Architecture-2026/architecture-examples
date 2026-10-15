namespace Observer.Exercise;

public class ProgressDisplay : IProgressObserver
{
    public void OnProgressChanged(int percentage) => Console.WriteLine($"Progress: {percentage}%");
}

public class CompletionNotification : IProgressObserver
{
    public void OnProgressChanged(int percentage) {
        if (percentage == 100) {
            Console.WriteLine("Download complete");
        }
    }
}
