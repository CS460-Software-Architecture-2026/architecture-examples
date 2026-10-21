namespace DIP.Exercise.Stage_1;

public interface IParser
{ 
    SalesRecord[] Parse(string inputFile);
}
