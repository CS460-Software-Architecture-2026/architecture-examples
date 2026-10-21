using System.Globalization;

namespace OCP.Quiz;

public class NumericQuestion : IQuestion
{
    private readonly string prompt;
    private readonly decimal expectedAnswer;
    private readonly decimal tolerance;

    public NumericQuestion(string prompt, decimal expectedAnswer, decimal tolerance)
    {
        if (tolerance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(tolerance));
        }

        this.prompt = prompt;
        this.expectedAnswer = expectedAnswer;
        this.tolerance = tolerance;
    }

    public void Display()
    {
        Console.WriteLine(prompt);
        Console.WriteLine("Enter a number:");
    }

    public bool IsCorrect(string answer)
    {
        return decimal.TryParse(
                answer,
                NumberStyles.Number,
                CultureInfo.InvariantCulture,
                out var actualAnswer)
            && Math.Abs(actualAnswer - expectedAnswer) <= tolerance;
    }
}
