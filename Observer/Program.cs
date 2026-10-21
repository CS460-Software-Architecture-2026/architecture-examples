using Observer.Exercise;

var downloader = new Downloader();
//
var display = new DisplayProgress();
var notifier = new NotifyOnComplete();
//
// downloader.Subscribe(display);
// downloader.Subscribe(notifier);
//
// downloader.UpdateProgress(10);
// downloader.UpdateProgress(50);
// downloader.UpdateProgress(100);
//
// downloader.Unsubscribe(display);
// downloader.Unsubscribe(notifier);

// === 

var eventDownloader = new EventDownloader();

eventDownloader.ProgressChanged += display.OnProgressUpdate;
eventDownloader.ProgressChanged += notifier.OnProgressUpdate;

eventDownloader.UpdateProgress(10);
eventDownloader.UpdateProgress(50);
eventDownloader.UpdateProgress(100);


eventDownloader.ProgressChanged -= display.OnProgressUpdate;