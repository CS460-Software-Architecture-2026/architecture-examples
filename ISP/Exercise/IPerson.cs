namespace ISP.Exercise;

public interface IPerson
{
    Guid Id { get; }
    string FullName { get; }
    string Email { get; }
}