namespace ISP.Exercise;

public class CourseAnnouncements : ICourseAnnouncements
{
    public void SendAnnouncement(IPerson person, string courseCode, string subject, string body)
    {
        Console.WriteLine($"To: {person.FullName} <{person.Email}> | {courseCode}: {subject} | {body}");
    }
}

public class AttendanceTracker : IAttendanceTracker
{
    public void MarkPresent(IPerson student, string courseCode, DateOnly date)
    {
        Console.WriteLine($"{date:yyyy-MM-dd} | {courseCode} | {student.Id} {student.FullName}: present");
    }
}

public class Gradebook : IGradebook
{
    public void RecordGrade(IGradable person, string courseCode, decimal points)
    {
        person.RecordGrade(courseCode, points);
    }

    public decimal? GetFinal(IGradable person, string courseCode)
    {
        return person.GetFinalGrade(courseCode);
    }
}

public class ContractsBilling : IContractsBilling
{
    public void AddCharge(IVisitor student, decimal amount, string reason)
    {
        student.AddCharge(amount, reason);
    }

    public decimal GetBalance(IVisitor student)
    {
        return student.OutstandingBalance;
    }
}
