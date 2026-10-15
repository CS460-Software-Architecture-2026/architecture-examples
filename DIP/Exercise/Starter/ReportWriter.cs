namespace DIP.Exercise.Starter;

public class ReportWriter: IWriter
{
    private string outputPath;
    public ReportWriter(string outputPath)
    {
        this.outputPath = outputPath;
    }
    
    public void Write(List<string> data)
    {
        File.WriteAllLines(this.outputPath, data);
    }
}