using Observer.Exercise;

Console.WriteLine("=== OOP Observer ===");

var downloader = new Downloader();

var progressObserver = new ProgressDisplayObserver();
var completionObserver = new CompletionObserver();

downloader.Subscribe(progressObserver);
downloader.Subscribe(completionObserver);

downloader.UpdateProgress(10);
downloader.UpdateProgress(10);
downloader.UpdateProgress(50);

downloader.Unsubscribe(progressObserver);

downloader.UpdateProgress(100);
downloader.UpdateProgress(100);


Console.WriteLine();
Console.WriteLine("=== Events / Delegates ===");

var eventDownloader = new EventDownloader();

void ShowProgress(int percentage)
{
    Console.WriteLine($"Progress: {percentage}%");
}

void ShowCompletion()
{
    Console.WriteLine("Download complete");
}

eventDownloader.ProgressChanged += ShowProgress;
eventDownloader.DownloadCompleted += ShowCompletion;

eventDownloader.UpdateProgress(10);
eventDownloader.UpdateProgress(10);
eventDownloader.UpdateProgress(50);

eventDownloader.ProgressChanged -= ShowProgress;

eventDownloader.UpdateProgress(100);
eventDownloader.UpdateProgress(100);