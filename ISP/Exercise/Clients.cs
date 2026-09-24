namespace ISP.Exercise;

public class CourseAnnouncements : ICourseAnnouncements
{
    public void SendToStudent(IStudent student, string courseCode, string subject, string body)
    {
        Console.WriteLine($"To: {student.FullName} <{student.Email}> | {courseCode}: {subject} | {body}");
    }

    public void SendToTeacher(ITeacher teacher, string courseCode, string subject, string body)
    {
        Console.WriteLine($"To: {teacher.FullName} <{teacher.Email}> | {courseCode}: {subject} | {body}");
    }
}

public class AttendanceTracker : IAttendanceTracker
{
    public void MarkPresent(IStudent student, string courseCode, DateOnly date)
    {
        Console.WriteLine($"{date:yyyy-MM-dd} | {courseCode} | {student.Id} {student.FullName}: present");
    }

    public void MarkPresentTeacher(ITeacher teacher, string courseCode, DateOnly date)
    {
        Console.WriteLine($"{date:yyyy-MM-dd} | {courseCode} | {teacher.Id} {teacher.FullName}: present");
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
    public void AddCharge(IStudent.IBillngStudent student, decimal amount, string reason)
    {
        student.AddCharge(amount, reason);
    }

    public decimal GetBalance(IStudent.IBillngStudent student)
    {
        return student.OutstandingBalance;
    }
}
