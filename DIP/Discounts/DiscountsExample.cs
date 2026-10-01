using DIP.Discounts.Demo;
using DIP.Discounts.Stage3Dip.Application;
using DIP.Discounts.Stage3Dip.Infrastructure;
using MessCheckout = DIP.Discounts.Stage1Mess.Checkout;
using ClassesCheckout = DIP.Discounts.Stage2Classes.Application.CheckoutService;

namespace DIP.Discounts;

public class DiscountsExample
{
    public void Run()
    {
        const decimal subtotal = 250m;
        const bool isVip = true;

        Console.WriteLine("DISCOUNTS: VIP + order size + timed promotion, capped at 20%");
        Console.WriteLine("STAGE 1 — MESS: everything in one method, using the real clock");
        new MessCheckout().Complete(subtotal, isVip);

        Console.WriteLine();
        Console.WriteLine("STAGE 2 — CLASSES: extracted responsibilities, concrete dependencies");
        new ClassesCheckout().Complete(subtotal, isVip);

        Console.WriteLine();
        Console.WriteLine("STAGE 3 — DIP: application contracts, using the real clock");
        // Composition root: infrastructure is selected outside the application.
        var checkout = new CheckoutService(new DiscountPolicy(new SystemClock()), new ConsoleReceiptPrinter());
        checkout.Complete(subtotal, isVip);

        Console.WriteLine();
        Console.WriteLine("SAME DIP CLASSES, FIXED CLOCK: promotion start is inclusive, end is exclusive");
        var instants = new[]
        {
            new DateTimeOffset(2026, 9, 24, 23, 59, 59, TimeSpan.Zero),
            new DateTimeOffset(2026, 9, 25, 0, 0, 0, TimeSpan.Zero),
            new DateTimeOffset(2026, 9, 28, 0, 0, 0, TimeSpan.Zero)
        };

        foreach (var instant in instants)
        {
            Console.WriteLine($"UTC: {instant:O}");
            var fixedCheckout = new CheckoutService(new DiscountPolicy(new FixedClock(instant)), new ConsoleReceiptPrinter());
            fixedCheckout.Complete(subtotal, isVip);
        }
    }
}
