namespace ISP.Exercise;

// Exercise: derive interfaces from actual usage in Clients.cs; preserve its behavior.
// An auditor receives announcements and attends classes, has grades but no billing.
// Support auditors without adding auditor-specific methods or pretending they are students.
// Replace the duplicated student/teacher methods with operations on client roles.

public interface ICourseAnnouncements
{
    void Send(IPerson person, string courseCode, string subject, string body);
}

public interface IAttendanceTracker
{
    void MarkPresent(IPerson person, string courseCode, DateOnly date);
}

public interface IGradebook
{
    void RecordGrade(IEnrollable student, string courseCode, decimal points);
    decimal? GetFinal(IEnrollable student, string courseCode);
}

public interface IContractsBilling
{
    void AddCharge(IBillable student, decimal amount, string reason);
    decimal GetBalance(IBillable student);
}
