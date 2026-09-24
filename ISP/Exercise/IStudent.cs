namespace ISP.Exercise;

public interface IHuman
{
    Guid Id { get; }
    string FullName { get; }
    string Email { get; }
}

public interface IGradebale
{
    void RecordGrade(string courseCode, decimal points);
    decimal? GetFinalGrade(string courseCode);
}
public interface IBilling
{
    decimal OutstandingBalance { get; }
    void AddCharge(decimal amount, string reason);
}
public interface IStudent : IHuman, IGradebale, IBilling
{
}

public interface IAmateur : IHuman, IGradebale
{
    
}

public interface ITeacher : IHuman
{
}
