namespace ISP.Exercise;

public class CourseAnnouncements : ICourseAnnouncements
{
    public void Send(IPerson recipient, string courseCode, string subject, string body)
    {
        Console.WriteLine($"To: {recipient.FullName} <{recipient.Email}> | {courseCode}: {subject} | {body}");
    }
}

public class AttendanceTracker : IAttendanceTracker
{
    public void MarkPresent(IPerson attendee, string courseCode, DateOnly date)
    {
        Console.WriteLine($"{date:yyyy-MM-dd} | {courseCode} | {attendee.Id} {attendee.FullName}: present");
    }
}

public class Gradebook : IGradebook
{
    public void RecordGrade(IStudent student, string courseCode, decimal points)
    {
        student.RecordGrade(courseCode, points);
    }

    public decimal? GetFinal(IStudent student, string courseCode)
    {
        return student.GetFinalGrade(courseCode);
    }
}

public class ContractsBilling : IContractsBilling
{
    public void AddCharge(IStudent student, decimal amount, string reason)
    {
        student.AddCharge(amount, reason);
    }

    public decimal GetBalance(IStudent student)
    {
        return student.OutstandingBalance;
    }
}

public class Auditor : IPerson
{
    public Guid Id { get; init; }
    public string FullName { get; init; } = "";
    public string Email { get; init; } = "";
}