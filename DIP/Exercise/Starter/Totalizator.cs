namespace DIP.Exercise.Starter;

public class Totalizator : ITotalCalculator
{
    public override SortedDictionary<string, decimal> getTotal(string[] salesStats)
    {
        var totals = new SortedDictionary<string, decimal>(StringComparer.Ordinal);

        foreach (var line in salesStats.Skip(1))
        {
            var columns = line.Split(',');
            var category = columns[0];
            var amount = decimal.Parse(columns[1], CultureInfo.InvariantCulture);
            var status = columns[2];

            if (status == "Cancelled")
            {
                continue;
            }

            if (status == "Refunded")
            {
                amount = -amount;
            }

            totals.TryGetValue(category, out var currentTotal);
            totals[category] = currentTotal + amount;
        }
        return totals;
    }
}