using Observer.Exercise;

Console.WriteLine("=== OOP Observer ===");
var downloader = new Downloader();
var display = new ProgressDisplay();
var completion = new CompletionNotification();

downloader.Subscribe(display);
downloader.Subscribe(completion);
downloader.UpdateProgress(10);
downloader.UpdateProgress(10); // Repeated values do not notify.
downloader.UpdateProgress(50);
downloader.Unsubscribe(display);
downloader.UpdateProgress(100); // Only completion remains subscribed.
downloader.UpdateProgress(100);

Console.WriteLine("=== Delegates/events ===");
var eventDownloader = new EventDownloader();
eventDownloader.ProgressChanged += display.OnProgressChanged;
eventDownloader.ProgressChanged += completion.OnProgressChanged;
eventDownloader.UpdateProgress(10);
eventDownloader.UpdateProgress(10);
eventDownloader.UpdateProgress(50);
eventDownloader.ProgressChanged -= display.OnProgressChanged;
eventDownloader.UpdateProgress(100);
eventDownloader.UpdateProgress(100);

