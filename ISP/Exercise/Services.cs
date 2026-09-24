namespace ISP.Exercise;

// Exercise: derive interfaces from actual usage in Clients.cs; preserve its behavior.
// An auditor receives announcements, attends classes and grades, but has no billing.
// Support auditors without adding auditor-specific methods or pretending they are students.
// Replace the duplicated student/teacher methods with operations on client roles.

public interface ICourseAnnouncements
{
    void SendToHuman(IHuman human, string courseCode, string subject, string body);
}

public interface IAttendanceTracker
{
    void MarkPresent(IHuman human, string courseCode, DateOnly date);
}

public interface IGradebook
{
    void RecordGrade(IGradebale student, string courseCode, decimal points);
    decimal? GetFinal(IGradebale student, string courseCode);
}

public interface IContractsBilling
{
    void AddCharge(IBilling student, decimal amount, string reason);
    decimal GetBalance(IBilling student);
}
