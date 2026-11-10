namespace DIP.Exercise.Stage_1;

public class SalesReportGeneratorBusinessRules : IBusinessRules
{
    public SortedDictionary<string, decimal> Apply(SalesRecord[] records)
    {
        var totals = new SortedDictionary<string, decimal>(StringComparer.Ordinal);

        foreach (var record in records)
        {
            if (record.Status == "Cancelled")
            {
                continue;
            }

            var amount = record.Amount;

            if (record.Status == "Refunded")
            {
                amount = -amount;
            }

            totals.TryGetValue(record.Category, out var currentTotal);
            totals[record.Category] = currentTotal + amount;
        }

        return totals;
    }
}