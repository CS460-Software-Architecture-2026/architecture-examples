using System;

namespace Observer.Exercise;

public class EventDownloader
{
    private int _progress = 0;

    public event Action<int>? ProgressChanged;

    public void UpdateProgress(int percentage)
    {
        if (percentage < 0 || percentage > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(percentage));
        }

        if (_progress == percentage)
        {
            return;
        }

        _progress = percentage;

        ProgressChanged?.Invoke(_progress);
    }
}