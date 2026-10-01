namespace LSP.Tickets;

public class NonRefundableTicket : Ticket
{
    public NonRefundableTicket(string reference, decimal price, DateTimeOffset departure)
        : base(reference, price, departure)
    {
    }

    public override void Cancel(DateTimeOffset now)
    {
        EnsureCanCancel(now);
        IsCancelled = true;
    }
}
