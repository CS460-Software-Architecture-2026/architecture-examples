using Observer.Exercise;

var downloader = new Downloader();
var pm = new ProgressMonitor();
downloader.AddListener(pm);
downloader.AddListener(new NotifyOnComplete());
downloader.UpdateProgress(10);
downloader.UpdateProgress(50);
downloader.RemoveListener(pm);
downloader.UpdateProgress(100);

