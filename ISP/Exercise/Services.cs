namespace ISP.Exercise;

// Exercise: derive interfaces from actual usage in Clients.cs; preserve its behavior.
// An auditor receives announcements, grades and attends classes, but has no billing.
// Support auditors without adding auditor-specific methods or pretending they are students.
// Replace the duplicated student/teacher methods with operations on client roles.

public interface ICourseAnnouncements
{
    void SendToMember(ICourseMember member, string courseCode, string subject, string body);
}

public interface IAttendanceTracker
{
    void MarkPresentMember(IGradingMember member, string courseCode, DateOnly date);
}


public interface IGradebook
{
    void RecordGrade(IGradingMember member, string courseCode, decimal points);
    decimal? GetFinal(IGradingMember member, string courseCode);
}

public interface IContractsBilling
{
    void AddCharge(IBillingMember member, decimal amount, string reason);
    decimal GetBalance(IBillingMember member);
}
