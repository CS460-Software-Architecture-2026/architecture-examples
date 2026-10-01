namespace DIP.Exercise.Starter;

public class Printer: IPrinter
{
    public void Report(string outputPath, Totals totals)
    {
        var report = new List<string> { "SALES REPORT" };
        foreach (var entry in totals.totals)
        {
            report.Add(FormattableString.Invariant($"{entry.Key}: {entry.Value:F2}"));
        }

        report.Add(FormattableString.Invariant($"TOTAL: {totals.totals.Values.Sum():F2}"));
        File.WriteAllLines(outputPath, report);

    }
}