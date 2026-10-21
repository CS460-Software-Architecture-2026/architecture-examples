using Observer.Exercise;

var downloader = new ListenerDownloader();
var progressDisplay = new ProgressDisplay();
var completionNotifier = new CompletionNotifier();

downloader.Subscribe(progressDisplay);
downloader.Subscribe(completionNotifier);

downloader.UpdateProgress(10);
downloader.UpdateProgress(50);
downloader.UpdateProgress(50);
downloader.UpdateProgress(100);

downloader.Unsubscribe(progressDisplay);
downloader.Unsubscribe(completionNotifier);

var eventDownloader = new EventDownloader();

eventDownloader.ProgressChanged += progressDisplay.OnProgressChanged;
eventDownloader.ProgressChanged += completionNotifier.OnProgressChanged;

eventDownloader.UpdateProgress(10);
eventDownloader.UpdateProgress(50);
eventDownloader.UpdateProgress(50);
eventDownloader.UpdateProgress(100);

eventDownloader.ProgressChanged -= progressDisplay.OnProgressChanged;
eventDownloader.ProgressChanged -= completionNotifier.OnProgressChanged;
