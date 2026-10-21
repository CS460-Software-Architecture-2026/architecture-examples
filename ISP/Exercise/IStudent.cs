namespace ISP.Exercise;

public interface IStudent : ICourseMember, IGradingMember, IBillingMember
{

}

public interface ITeacher : ICourseMember
{

}


public interface ICourseMember
{
    Guid Id { get; }
    string FullName { get; }
    string Email { get; }
}


public interface IGradingMember : ICourseMember
{
    void RecordGrade(string courseCode, decimal points);
    decimal? GetFinalGrade(string courseCode);
}


public interface IBillingMember : IGradingMember
{
    void AddCharge(decimal amount, string reason);
    decimal OutstandingBalance { get; }
}