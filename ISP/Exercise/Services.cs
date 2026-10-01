namespace ISP.Exercise;

// Exercise: derive interfaces from actual usage in Clients.cs; preserve its behavior.
// An auditor receives announcements and attends classes, has grades but no billing.
// Support auditors without adding auditor-specific methods or pretending they are students.
// Replace the duplicated student/teacher methods with operations on client roles.

public interface ICourseAnnouncements
{
    void SendAnnouncement(IPerson person, string courseCode, string subject, string body);
}

public interface IAttendanceTracker
{
    void MarkPresent(IPerson person, string courseCode, DateOnly date);
}

public interface IGradebook
{
    void RecordGrade(IGradable person, string courseCode, decimal points);
    decimal? GetFinal(IGradable person, string courseCode);
}

public interface IContractsBilling
{
    void AddCharge(IVisitor student, decimal amount, string reason);
    decimal GetBalance(IVisitor student);
}
