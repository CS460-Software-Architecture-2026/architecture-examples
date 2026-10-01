namespace LSP.Tickets;

public class PartiallyRefundableTicket : Ticket
{
    private readonly decimal cancellationFee;
    
    public decimal RefundAmount { get; private set; }

    public PartiallyRefundableTicket(
        string reference, decimal price, DateTimeOffset departure, decimal cancellationFee)
        : base(reference, price, departure)
    {
        if (cancellationFee < 0m)
        {
            throw new ArgumentOutOfRangeException(nameof(cancellationFee));
        }

        this.cancellationFee = cancellationFee;
    }

    public override void Cancel(DateTimeOffset now)
    {
        EnsureCanCancel(now);
        IsCancelled = true;
        // The cancellation fee is deducted; the refund cannot be negative.
        RefundAmount = Math.Max(0m, Price - cancellationFee);
    }
}
