namespace ISP.Exercise;

public interface IStudent : IPerson
{
    void RecordGrade(string courseCode, decimal points);
    decimal? GetFinalGrade(string courseCode);
    void AddCharge(decimal amount, string reason);
    decimal OutstandingBalance { get; }
}

public interface ITeacher : IPerson
{
}