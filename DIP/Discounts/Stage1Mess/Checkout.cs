namespacex DIP.Discounts.Stage1Mess;

public class Checkout
{
    public Receipt Complete(decimal subtotal, bool isVip)
    {
        // Validation, reading the clock, pricing rules, and output all live here.
        if (subtotal <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(subtotal), "Subtotal must be positive.");
        }

        var now = DateTimeOffset.UtcNow;
        var discountRate = 0m;

        if (isVip)
        {
            discountRate += 0.10m;
        }

        if (subtotal >= 200m)
        {
            discountRate += 0.05m;
        }

        if (now >= new DateTimeOffset(2026, 9, 25, 0, 0, 0, TimeSpan.Zero)
            && now < new DateTimeOffset(2026, 9, 28, 0, 0, 0, TimeSpan.Zero))
        {
            discountRate += 0.10m;
        }

        discountRate = Math.Min(discountRate, 0.20m);
        var discount = Math.Round(subtotal * discountRate, 2, MidpointRounding.AwayFromZero);
        var receipt = new Receipt(subtotal, discountRate, discount, subtotal - discount);

        Console.WriteLine(FormattableString.Invariant(
            $"Subtotal: {receipt.Subtotal:F2} | Rate: {receipt.DiscountRate:P0} | Discount: {receipt.Discount:F2} | Total: {receipt.Total:F2}"));

        return receipt;
    }
}
