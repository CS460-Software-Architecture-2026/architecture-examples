namespace ISP.Exercise;

public interface IPerson
{
    Guid Id { get; }
    string FullName { get; }
    string Email { get; }
}

public interface IEnrollable
{
    void RecordGrade(string courseCode, decimal points);
    decimal? GetFinalGrade(string courseCode);
}

public interface IBillable
{
    void AddCharge(decimal amount, string reason);
    decimal OutstandingBalance { get; }
}
