namespace DIP.Exercise.Stage_1;

public class CSVParser : IParser
{
    public SalesRecord[] Parse(string inputPath)
    {
        var lines = File.ReadAllLines(inputPath);
        var salesRecords = new List<SalesRecord>();

        foreach (var line in lines.Skip(1))
        {
            var columns = line.Split(',');
            var category = columns[0];
            var amount = decimal.Parse(columns[1], CultureInfo.InvariantCulture);
            var status = columns[2];
            salesRecords.Add(new SalesRecord { Category = category, Amount = amount, Status = status });
        }

        return salesRecords.ToArray();
    }
}