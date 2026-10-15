namespace OCP.Quiz;

public class TrueFalseQuestion : IQuestion
{
    private readonly string prompt;
    private readonly bool correctAnswer;

    public TrueFalseQuestion(string prompt, bool correctAnswer)
    {
        this.prompt = prompt;
        this.correctAnswer = correctAnswer;
    }

    public void Display()
    {
        Console.WriteLine(prompt);
        Console.WriteLine("Enter true or false:");
    }

    public bool IsCorrect(string answer)
    {
        return bool.TryParse(answer, out var selectedAnswer)
            && selectedAnswer == correctAnswer;
    }
}
