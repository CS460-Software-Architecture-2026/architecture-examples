using Observer.Exercise;

Console.WriteLine("OOP version:");
var downloaderOOP = new Downloader();

var listenerOOP1 = new User();
var listenerOOP2 = new User();
downloaderOOP.AddProgressListener(listenerOOP1);
downloaderOOP.AddProgressListener(listenerOOP2);
downloaderOOP.AddCompletionListener(listenerOOP1);
downloaderOOP.AddCompletionListener(listenerOOP2);

downloaderOOP.UpdateProgress(10);
downloaderOOP.RemoveProgressListener(listenerOOP2);

downloaderOOP.UpdateProgress(50);
downloaderOOP.UpdateProgress(50);

downloaderOOP.UpdateProgress(100);
downloaderOOP.UpdateProgress(100);

downloaderOOP.RemoveProgressListener(listenerOOP1);
downloaderOOP.RemoveCompletionListener(listenerOOP2);
downloaderOOP.RemoveCompletionListener(listenerOOP1);


Console.WriteLine("C# version:");
var downloaderEvents = new DownloaderWithEvents();
var listenerEvents1 = new UserWithEvents();
var listenerEvents2 = new UserWithEvents();
listenerEvents1.SubscribeTo(downloaderEvents);
listenerEvents2.SubscribeTo(downloaderEvents);

downloaderEvents.UpdateProgress(10);
downloaderEvents.OnProgressChanged -= listenerEvents2.OnProgressChanged;

downloaderEvents.UpdateProgress(50);
downloaderEvents.UpdateProgress(50);

downloaderEvents.UpdateProgress(100);
downloaderEvents.UpdateProgress(100);
