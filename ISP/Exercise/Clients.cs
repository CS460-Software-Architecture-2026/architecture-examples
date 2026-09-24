namespace ISP.Exercise;

public class CourseAnnouncements : ICourseAnnouncements
{
    public void SendToHuman(IHuman human, string courseCode, string subject, string body)
    {
        Console.WriteLine($"To: {human.FullName} <{human.Email}> | {courseCode}: {subject} | {body}");
    }
}

public class AttendanceTracker : IAttendanceTracker
{
    public void MarkPresent(IHuman human, string courseCode, DateOnly date)
    {
        Console.WriteLine($"{date:yyyy-MM-dd} | {courseCode} | {human.Id} {human.FullName}: present");
    }
}

public class Gradebook : IGradebook
{
    public void RecordGrade(IGradebale student, string courseCode, decimal points)
    {
        student.RecordGrade(courseCode, points);
    }

    public decimal? GetFinal(IGradebale student, string courseCode)
    {
        return student.GetFinalGrade(courseCode);
    }
}

public class ContractsBilling : IContractsBilling
{
    public void AddCharge(IBilling student, decimal amount, string reason)
    {
        student.AddCharge(amount, reason);
    }

    public decimal GetBalance(IBilling student)
    {
        return student.OutstandingBalance;
    }
}
