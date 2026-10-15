using Observer.Exercise;

// Object-oriented way:

// var downloader = new Downloader();
// var display = new ProgressDisplay();
// var notifier = new CompletionNotifier();

// downloader.Subscribe(display);
// downloader.Subscribe(notifier);

// downloader.UpdateProgress(10);
// downloader.UpdateProgress(50);
// downloader.UpdateProgress(50);

// downloader.Unsubscribe(display);

// downloader.UpdateProgress(100);


// C# way:

var downloader2 = new DownloaderWithEvent();
var display2 = new ProgressDisplayWithEvent();
var notifier2 = new CompletionNotifierWithEvent();

display2.SubscribeTo(downloader2);
notifier2.SubscribeTo(downloader2);

downloader2.UpdateProgress(10);
downloader2.UpdateProgress(50);
downloader2.UpdateProgress(50);

display2.UnsubscribeFrom(downloader2);

downloader2.UpdateProgress(100);  