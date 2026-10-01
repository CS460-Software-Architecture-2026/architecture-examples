namespace ISP.Products.After.Report;

public interface IFile
{
   public string[] FileRead(string inputPath)
   {
      var lines = File.ReadAllLines(inputPath);
      return lines;
   }
}