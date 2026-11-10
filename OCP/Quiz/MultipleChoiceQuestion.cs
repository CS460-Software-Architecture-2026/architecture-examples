namespace OCP.Quiz;

public class MultipleChoiceQuestion : IQuestion
{
    private readonly string prompt;
    private readonly string[] options;
    private readonly int correctOption;

    public MultipleChoiceQuestion(string prompt, IEnumerable<string> options, int correctOption)
    {
        this.prompt = prompt;
        this.options = options.ToArray();

        if (correctOption < 1 || correctOption > this.options.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(correctOption));
        }

        this.correctOption = correctOption;
    }

    public void Display()
    {
        Console.WriteLine(prompt);

        for (var index = 0; index < options.Length; index++)
        {
            Console.WriteLine($"{index + 1}. {options[index]}");
        }

        Console.WriteLine("Enter the option number:");
    }

    public bool IsCorrect(string answer)
    {
        return int.TryParse(answer, out var selectedOption)
            && selectedOption == correctOption;
    }
}
