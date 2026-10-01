namespace LSP.Tickets;

public class TicketCancellationExercise
{
    public void Run()
    {
        var now = new DateTimeOffset(2026, 10, 1, 10, 0, 0, TimeSpan.Zero);
        var departure = now.AddDays(7);
        var tickets = new Ticket[]
        {
            new Ticket("FLEX-001", 120m, departure),
            new NonRefundableTicket("BASIC-001", 80m, departure),
            new PartiallyRefundableTicket("STANDARD-001", 100m, departure, 20m)
        };
        
        RefundAll(tickets, now);
    }

    private decimal RefundAll(IEnumerable<Ticket> tickets, DateTimeOffset now)
    {
        var refunds = 0m;
        var bookings = new BookingService();
        foreach (var ticket in tickets)
        {
            Console.WriteLine(bookings.CancelBooking(ticket, now));
            refunds += ticket.Price;
            Console.WriteLine($"Cancelled: {ticket.IsCancelled}!");
            if (ticket is PartiallyRefundableTicket t)
            {
                refunds += t.Price;
            }
            Console.WriteLine();
        }

        return refunds;
    }
}
