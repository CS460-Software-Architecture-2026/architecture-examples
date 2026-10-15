using Observer.Exercise;

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
