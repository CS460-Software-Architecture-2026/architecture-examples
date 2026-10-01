using DIP.Orders.After.Infrastructure;
using DIP.Orders.Demo;
using BeforeOrderService = DIP.Orders.Before.Application.OrderService;
using AfterOrderService = DIP.Orders.After.Application.OrderService;

namespace DIP.Orders;

public class OrdersExample
{
    public void Run()
    {
        var order = new Order(42, "customer@example.com", 100m);

        Console.WriteLine("BEFORE: OrderService constructs SmtpEmailSender");
        var before = new BeforeOrderService();
        before.PlaceOrder(order);

        Console.WriteLine();
        Console.WriteLine("AFTER: OrderService receives an IOrderNotifier");
        // Composition root: concrete implementations are chosen at the entry point.
        var after = new AfterOrderService(new SmtpEmailNotifier());
        after.PlaceOrder(order);

        Console.WriteLine();
        Console.WriteLine("AFTER WITH A FAKE: same OrderService, no email delivery");
        var recordingNotifier = new RecordingOrderNotifier();
        var withFake = new AfterOrderService(recordingNotifier);
        withFake.PlaceOrder(order);
        Console.WriteLine($"Recorded notification for order #{recordingNotifier.LastNotifiedOrder?.Id}.");
    }
}
