namespace ISP.Exercise;

// Exercise: derive interfaces from actual usage in Clients.cs; preserve its behavior.
// An auditor receives announcements and attends classes, but has no grades or billing.
// Support auditors without adding auditor-specific methods or pretending they are students.
// Replace the duplicated student/teacher methods with operations on client roles.

public interface ICourseAnnouncements
{
    void SendToStudent(IStudent student, string courseCode, string subject, string body);
    void SendToTeacher(ITeacher teacher, string courseCode, string subject, string body);
}

public interface IAttendanceTracker
{
    void MarkPresent(IStudent student, string courseCode, DateOnly date);
    void MarkPresentTeacher(ITeacher teacher, string courseCode, DateOnly date);
}

public interface IGradebook
{
    void RecordGrade(IStudent student, string courseCode, decimal points);
    decimal? GetFinal(IStudent student, string courseCode);
}

public interface IContractsBilling
{
    void AddCharge(IStudent.IBillngStudent student, decimal amount, string reason);
    decimal GetBalance(IStudent.IBillngStudent student);
}
