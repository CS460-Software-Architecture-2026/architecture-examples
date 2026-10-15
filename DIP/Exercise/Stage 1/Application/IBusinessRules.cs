namespace DIP.Exercise.Stage_1;

public interface IBusinessRules
{
    SortedDictionary<string, decimal> Apply(SalesRecord[] records);
}
