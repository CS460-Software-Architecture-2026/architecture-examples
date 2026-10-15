using DIP.Exercise.Stage_1.Application;

namespace DIP.Exercise.Stage_1;

public class TextReportGenerator : IReportGenerator
{
    private readonly IBusinessRules _businessRules;

    public TextReportGenerator(IBusinessRules businessRules)
    {
        _businessRules = businessRules;
    }

    public void Generate(SalesRecord[] records, string outputPath)
    {
        var totals = _businessRules.Apply(records);

        var report = new List<string> { "SALES REPORT" };
        foreach (var entry in totals)
        {
            report.Add(FormattableString.Invariant($"{entry.Key}: {entry.Value:F2}"));
        }

        report.Add(FormattableString.Invariant($"TOTAL: {totals.Values.Sum():F2}"));
        File.WriteAllLines(outputPath, report);
    }
}
