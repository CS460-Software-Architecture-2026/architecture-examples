using System.Globalization;


namespace DIP.Exercise.Starter.Application;

public class ParseService
{
    public Totals Parse(string inputPath)
    {
        var file = new IFile.FileRead(inputPath);
        var totals = new Totals( new SortedDictionary<string, decimal>(StringComparer.Ordinal));

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

            totals.Total.TryGetValue(category, out var currentTotal);
            totals.Total[category] = currentTotal + amount;
        }
        return totals;
    }
}