namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.
public class Downloader
{
    Center center;

    public Downloader()
    {
        center = new Center();
        center.Subscribe(new DisplaySubscriber());
        center.Subscribe(new CompleteSubscriber());
    }
    public void UpdateProgress(int percentage)
    {
        // TODO: Update progress and notify subscribers.
        center.NotifySubscribers(percentage);
    }
}

interface IDownloaderEventSubscriber
{
    public void UpdateProgressEvent(int percentage, Center center);
}


class Center
{
    public List<IDownloaderEventSubscriber> subscribers = new List<IDownloaderEventSubscriber>();

    public void Subscribe(IDownloaderEventSubscriber subscriber)
    {
        subscribers.Add(subscriber);
    }

    public void Unsubscribe(IDownloaderEventSubscriber subscriber)
    {
        subscribers.Remove(subscriber);
    }

    public void NotifySubscribers(int percentage)
    {
        subscribers.ForEach(subscriber => subscriber.UpdateProgressEvent(percentage, this));
    }
}

class DisplaySubscriber : IDownloaderEventSubscriber
{
    public void UpdateProgressEvent(int percentage, Center center)
    {
        System.Console.WriteLine($"{percentage}%");
        if (percentage >= 100)
            center.Unsubscribe(this);
    }
}

class CompleteSubscriber : IDownloaderEventSubscriber
{
    public void UpdateProgressEvent(int percentage, Center center)
    {
        if (percentage == 100)
            Console.WriteLine("Download complete");
    }
}