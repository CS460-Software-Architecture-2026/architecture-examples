namespace DIP.Exercise.Starter;

public class ReportReader: IReader
{
    private string inputPath;

    public ReportReader(string inputPath)
    {
        this.inputPath = inputPath;
    }
    
    public string[] Read()
    {
        var lines = File.ReadAllLines(this.inputPath);
        
        return lines;
    }
}