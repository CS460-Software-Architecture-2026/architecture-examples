namespace Observer.Exercise;

class DownloaderWithEvents
{
    public event Action<int> SubscriberAdded;
    
    public void UpdateProgress(int percentage)
    {
        SubscriberAdded(percentage);
    }
}

class DisplayerWithEvents
{
    public void SubscribeTo(DownloaderWithEvents center)
    {
        center.SubscriberAdded += DisplayProgress;
    }
    
    void DisplayProgress(int percentage)
    {
        Console.WriteLine(percentage);
        // if (percentage == 100)
    }
}

class CompleteWithEvents
{
    public void SubscribeTo(DownloaderWithEvents center)
    {
        center.SubscriberAdded += CompleteProgress;
    }
    
    void CompleteProgress(int percentage)
    {
        if (percentage == 100)
        {
            Console.WriteLine("Completed download");
        }
    }
}

class Publisher
{
    public event Action ActionPerformed;

    public void InvokeEvent()
    {
        ActionPerformed?.Invoke();
    }
}