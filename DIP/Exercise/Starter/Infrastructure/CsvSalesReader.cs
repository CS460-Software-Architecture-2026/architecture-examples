using System.Globalization;
using DIP.Exercise.Starter.Application;

namespace DIP.Exercise.Starter.Infrastructure;

public class CsvSalesReader : ISalesReader
{
    private readonly string path;

    public CsvSalesReader(string path)
    {
        this.path = path;
    }

    public IReadOnlyList<Sale> ReadAll()
    {
        return File.ReadAllLines(path)
            .Skip(1)
            .Select(line => line.Split(','))
            .Select(columns => new Sale(columns[0], decimal.Parse(columns[1], CultureInfo.InvariantCulture), columns[2]))
            .ToList();
    }
}
