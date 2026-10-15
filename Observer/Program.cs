using Observer.Exercise;

Console.WriteLine("=== Variant 1: OOP Observer with an interface ===");

var downloader = new Downloader();
var display = new ProgressDisplay();
var notifier = new CompletionNotifier();

downloader.Subscribe(display);
downloader.Subscribe(notifier);

downloader.UpdateProgress(10);
downloader.UpdateProgress(50);
downloader.UpdateProgress(50);

downloader.Unsubscribe(display);
downloader.UpdateProgress(100);

Console.WriteLine();
Console.WriteLine("=== Variant 2: C# delegates/events ===");

var downloader2 = new DownloaderWithEvents();

Action<int> showProgress = p => Console.WriteLine("Progress: " + p + "%");
Action<int> showComplete = p =>
{
    if (p == 100)
    {
        Console.WriteLine("Download complete");
    }
};

downloader2.ProgressChanged += showProgress;
downloader2.ProgressChanged += showComplete;

downloader2.UpdateProgress(10);
downloader2.UpdateProgress(50);
downloader2.UpdateProgress(50); 

downloader2.ProgressChanged -= showProgress;
downloader2.UpdateProgress(100);