namespace OCP.Quiz;

public interface IQuestion
{
    void Display();
    bool IsCorrect(string answer);
}
