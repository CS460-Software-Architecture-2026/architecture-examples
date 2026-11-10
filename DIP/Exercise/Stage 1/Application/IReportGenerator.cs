namespace DIP.Exercise.Stage_1;

public interface IReportGenerator
{
    void Generate(SalesRecord[] records, string outputPath);
}