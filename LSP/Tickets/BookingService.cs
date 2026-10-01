namespace LSP.Tickets;

public class BookingService
{
    public string CancelBooking(Ticket ticket, DateTimeOffset now)
    {
        ticket.Cancel(now);

        // A successful Ticket.Cancel promises a full refund.
        return $"Booking {ticket.Reference} cancelled. You will receive a refund of {ticket.Price:0.00}.";
    }
}
