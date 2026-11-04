using System.Globalization;

namespace DIP.Exercise.Starter;

public class CalculateTotals: ICalculateTotals
{
    public SortedDictionary<string, decimal> Calculate(string[] lines)
    {
        var totals = new SortedDictionary<string, decimal>(StringComparer.Ordinal);

        foreach (var line in lines.Skip(1))
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