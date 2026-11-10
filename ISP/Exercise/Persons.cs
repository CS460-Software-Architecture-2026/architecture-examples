namespace ISP.Exercise;

public class Student : IPerson, IEnrollable, IBillable
{
    Dictionary<string, decimal> _grades;
   List<(decimal Amount, string Reason)> _charges;

    Guid Id { get; }
    string FullName { get; }
    string Email { get; }

    public void RecordGrade(string courseCode, decimal points) {}

    public decimal? GetFinalGrade(string courseCode) {}

    public void AddCharge(decimal amount, string reason) {}

    public decimal OutstandingBalance;
}

public class Teacher : IPerson
{
    Guid Id { get; }
    string FullName { get; }
    public required string Email { get; }
}

public class Auditor : IPerson
{
    Guid Id { get; }
    string FullName { get; }
    string Email { get; }
}
