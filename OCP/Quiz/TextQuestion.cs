namespace OCP.Quiz;

public class TextQuestion : IQuestion
{
    private readonly string prompt;
    private readonly string correctAnswer;

    public TextQuestion(string prompt, string correctAnswer)
    {
        this.prompt = prompt;
        this.correctAnswer = correctAnswer;
    }

    public void Display()
    {
        Console.WriteLine(prompt);
        Console.WriteLine("Type your answer:");
    }

    public bool IsCorrect(string answer)
    {
        return answer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase);
    }
}
