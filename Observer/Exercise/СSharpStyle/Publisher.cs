namespace Observer.Exercise.СSharpStyle;

public class Publisher
{
    public event Action ActionPerformed;
    public event Action ActionBPerformed = delegate { };

    public void InvokeEvent()
    {
        ActionPerformed();
        ActionPerformed?.Invoke();
    }
}