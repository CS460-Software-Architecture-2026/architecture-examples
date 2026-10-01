namespace ISP.Exercise;

public interface IGradable
{
    void RecordGrade(string courseCode, decimal points);
    decimal? GetFinalGrade(string courseCode);
}