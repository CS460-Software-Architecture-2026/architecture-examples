namespace ISP.Exercise;

public interface IStudent
{
    Guid Id { get; }
    string FullName { get; }
    string Email { get; }
    void RecordGrade(string courseCode, decimal points);
    decimal? GetFinalGrade(string courseCode);
    
    public interface IBillngStudent
    {
        decimal OutstandingBalance { get; }
        void AddCharge(decimal amount, string reason);
    }
}

public interface ITeacher
{
    Guid Id { get; }
    string FullName { get; }
    string Email { get; }
}
