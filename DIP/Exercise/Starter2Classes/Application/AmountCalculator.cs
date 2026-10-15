using System.Globalization;

using DIP.Exercise.Starter2Classes.Infrastructure;
namespace DIP.Exercise.Stage2Classes.Application;

public class AmountCalculator
{
    public Totals Calculate(string inputPath) {

        var lines = File.ReadAllLines(inputPath);
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