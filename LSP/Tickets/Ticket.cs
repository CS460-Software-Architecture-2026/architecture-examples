namespace LSP.Tickets;

public class Ticket
{
    public string Reference { get; }
    public decimal Price { get; }
    public DateTimeOffset Departure { get; }
    public bool IsCancelled { get; protected set; }

    public Ticket(string reference, decimal price, DateTimeOffset departure)
    {
        Reference = reference;
        Price = price;
        Departure = departure;
    }

    public virtual void Cancel(DateTimeOffset now)
    {
        EnsureCanCancel(now);
        IsCancelled = true;
    }

    protected void EnsureCanCancel(DateTimeOffset now)
    {
        if (IsCancelled)
        {
            throw new InvalidOperationException("Ticket is already cancelled.");
        }

        if (now >= Departure)
        {
            throw new InvalidOperationException("Ticket cannot be cancelled after departure has started.");
        }
    }
}
