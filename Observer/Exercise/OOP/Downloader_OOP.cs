namespace Observer.Exercise;

// Simulate download progress (0–100); no actual downloading is required.
// Add two subscribers: one prints progress after each change, the other prints
// "Download complete" when progress reaches 100. Repeating a value must not notify.
// Demonstrate updates at 10, 50, and 100, and unsubscribing the progress display
// while keeping the completion notification subscribed.
// Implement two variants: OOP Observer with an interface, and C# delegates/events.
public class Downloader_OOP
{
    public void UpdateProgress(int percentage)
    {
        var downloader = new Downloader_OOP();
        var display = new ProgressDisplay();
        var completion = new CompletionNotification();
 
        downloader.Subscribe(display);
        downloader.Subscribe(completion);
 
        downloader.UpdateProgress(10);
        downloader.UpdateProgress(10);
        downloader.UpdateProgress(50);
 
        downloader.Unsubscribe(display);
        Console.WriteLine("(progress display unsubscribed)");
 
        downloader.UpdateProgress(100);
    }
    
    
}
