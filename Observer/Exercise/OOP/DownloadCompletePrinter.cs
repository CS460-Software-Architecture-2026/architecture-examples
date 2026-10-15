namespace Observer.OOP.Exercise;

//the other prints "Download complete" when progress reaches 100.
public class DownloadCompletePrinter : IProgressListener
{
    public void OnProgressChanged(int percentage)
    {
        if (percentage == 100)
        {
            Console.WriteLine("Download complete");
        }
    }
}