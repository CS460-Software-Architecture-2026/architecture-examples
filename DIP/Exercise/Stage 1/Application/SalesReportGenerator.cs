namespace DIP.Exercise.Stage_1;

public class SalesReportGenerator
{
    private readonly IParser _parser;
    private readonly IReportGenerator _reportGenerator;

    public SalesReportGenerator(IParser parser, IReportGenerator reportGenerator)
    {
        _parser = parser;
        _reportGenerator = reportGenerator;
    }

    public void Generate(string inputPath, string outputPath)
    {
        var records = _parser.Parse(inputPath);
        _reportGenerator.Generate(records, outputPath);
    }
}
