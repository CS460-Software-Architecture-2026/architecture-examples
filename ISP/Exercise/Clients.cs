namespace ISP.Exercise;

public class CourseAnnouncements : ICourseAnnouncements
{
    public void Send(IPerson person, string courseCode, string subject, string body)
    {
        Console.WriteLine($"To: {person.FullName} <{person.Email}> | {courseCode}: {subject} | {body}");
    }
}

public class AttendanceTracker : IAttendanceTracker
{
    public void MarkPresent(IPerson person, string courseCode, DateOnly date)
    {
        Console.WriteLine($"{date:yyyy-MM-dd} | {courseCode} | {person.Id} {person.FullName}: present");
    }
}

public class Gradebook : IGradebook
{
    public void RecordGrade(IEnrollable student, string courseCode, decimal points)
    {
        student.RecordGrade(courseCode, points);
    }

    public decimal? GetFinal(IEnrollable student, string courseCode)
    {
        return student.GetFinalGrade(courseCode);
    }
}

public class ContractsBilling : IContractsBilling
{
    public void AddCharge(IBillable student, decimal amount, string reason)
    {
        student.AddCharge(amount, reason);
    }

    public decimal GetBalance(IBillable student)
    {
        return student.OutstandingBalance;
    }
}
