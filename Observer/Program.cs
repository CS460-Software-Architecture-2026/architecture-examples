using Observer.Exercise;


var progressDisplay = new ProgressDisplay();
var completionNotifier = new CompletionNotifier();

//variant 1
var downloader = new Downloader();
downloader.AddListener(progressDisplay);
downloader.AddListener(completionNotifier);

//variant 2
var eventDownloader = new EventDownloader();
eventDownloader.DownloadProgressUpdate += progressDisplay.OnDownloadProgressChanged;
eventDownloader.DownloadProgressUpdate += completionNotifier.OnDownloadProgressChanged;

Console.WriteLine("Variant 1");
downloader.UpdateProgress(10);
downloader.UpdateProgress(50);
downloader.UpdateProgress(50);
downloader.RemoveListener(progressDisplay);
downloader.UpdateProgress(67);
downloader.UpdateProgress(100);

Console.WriteLine();
Console.WriteLine("Variant 2");
eventDownloader.UpdateProgress(10);
eventDownloader.UpdateProgress(50);
eventDownloader.UpdateProgress(50);
eventDownloader.DownloadProgressUpdate -= progressDisplay.OnDownloadProgressChanged;
eventDownloader.UpdateProgress(67);
eventDownloader.UpdateProgress(100);
