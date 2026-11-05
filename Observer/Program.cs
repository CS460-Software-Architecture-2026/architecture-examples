using Observer.Exercise;

var downloader = new Downloader();
var progressListener = new OopStyleListener();
var completionListener = new EventStyleListener();

downloader.AddListener(progressListener);
completionListener.Subscribe(downloader);

downloader.UpdateProgress(10);
downloader.UpdateProgress(50);
downloader.UpdateProgress(50); // repeated value: nobody is notified

downloader.RemoveListener(progressListener);

downloader.UpdateProgress(100);
