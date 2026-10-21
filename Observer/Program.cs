
using System;
using Observer.Exercise;

// Variant 1

Console.WriteLine("_OOP Observer_");

var downloader = new Downloader();

var progressObserver = new ProgressObserver();
var completionObserver = new CompletionObserver();

downloader.Subscribe(progressObserver);
downloader.Subscribe(completionObserver);

downloader.UpdateProgress(10);
downloader.UpdateProgress(50);
downloader.UpdateProgress(50);

downloader.Unsubscribe(progressObserver);

downloader.UpdateProgress(100);


// Variant 2

Console.WriteLine("\n_C# Events_");

var eventDownloader = new EventDownloader();

Action<int> showProgress = progress =>
{
    Console.WriteLine($"Progress: {progress}%");
};

Action<int> showCompletion = progress =>
{
    if (progress == 100)
    {
        Console.WriteLine("Download complete");
    }
};

eventDownloader.ProgressChanged += showProgress;
eventDownloader.ProgressChanged += showCompletion;

eventDownloader.UpdateProgress(10);
eventDownloader.UpdateProgress(50);
eventDownloader.UpdateProgress(50);

eventDownloader.ProgressChanged -= showProgress;

eventDownloader.UpdateProgress(100);