using Observer.Exercise;

var display = new ProgressDisplay();
var completion = new CompletionNotification();

Console.WriteLine("Interface observer:");
var downloader = new Downloader();
downloader.Subscribe(display);
downloader.Subscribe(completion);
downloader.UpdateProgress(10);
downloader.UpdateProgress(10);
downloader.UpdateProgress(50);
downloader.Unsubscribe(display);
downloader.UpdateProgress(100);

Console.WriteLine("Events:");
var eventDownloader = new EventDownloader();
eventDownloader.ProgressChanged += display.OnProgressChanged;
eventDownloader.ProgressChanged += completion.OnProgressChanged;
eventDownloader.UpdateProgress(10);
eventDownloader.UpdateProgress(10);
eventDownloader.UpdateProgress(50);
eventDownloader.ProgressChanged -= display.OnProgressChanged;
eventDownloader.UpdateProgress(100);
