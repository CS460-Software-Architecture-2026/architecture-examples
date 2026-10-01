namespace DIP.Exercise.Starter.Application;

public class GenerateService
{
    public void Generate(string inputPath, string outputPath)
    {
        var parse = new ParseService(); 
        var totals = parse.Parse(inputPath);

        var report = new List<string> { "SALES REPORT" };
        foreach (var entry in totals.Total)
        {
            report.Add(FormattableString.Invariant($"{entry.Key}: {entry.Value:F2}"));
        }

        report.Add(FormattableString.Invariant($"TOTAL: {totals.Total.Values.Sum():F2}"));
        File.WriteAllLines(outputPath, report);
    }
    
    
}