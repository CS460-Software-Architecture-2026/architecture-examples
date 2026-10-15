using Observer.OOP.Exercise;
using Observer.Exercise.СSharpStyle;

Console.WriteLine("OOP");

var downloader = new Downloader();

var complete = new DownloadCompletePrinter();
var progres = new ProgressPrinter();

downloader.AddListener(complete);
downloader.AddListener(progres);

downloader.UpdateProgress(10);
downloader.UpdateProgress(50);
downloader.UpdateProgress(50);

downloader.RemoveListener(progres);

downloader.UpdateProgress(100);

Console.WriteLine("C#");

var eventdownloader = new DownloaderWithEvent();

var eventcomplete = new CompleteWithEvents();
var eventprogres = new ProgressChangeWithEvents();

eventcomplete.SubscribeTo(eventdownloader);
eventprogres.SubscribeTo(eventdownloader);

eventdownloader.OnProgress(10);
eventdownloader.OnProgress(50);
eventdownloader.OnProgress(50);

eventdownloader.OnProgressChanged -= eventprogres.OnProgressChanged;

eventdownloader.OnProgress(100);
