namespace ISP.Exercise;

public interface IVisitor
{
    void AddCharge(decimal amount, string reason);
    decimal OutstandingBalance { get; }
}