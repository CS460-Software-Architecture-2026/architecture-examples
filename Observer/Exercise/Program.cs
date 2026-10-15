using Observer.Exercise.OOP;

var downloader = new Downloader_OOP();
var display = new ProgressDisplay();
var completion = new CompletionNotification();

downloader.Subscribe(display);
downloader.Subscribe(completion);

downloader.UpdateProgress(10);
downloader.UpdateProgress(10); // nothing printed
downloader.UpdateProgress(50);

downloader.Unsubscribe(display);
Console.WriteLine("(progress display unsubscribed)");

downloader.UpdateProgress(100); // only "Download complete"