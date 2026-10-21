namespace OCP.Quiz;

// The starting model stores both kinds of question in the same shape.
// For multiple choice, CorrectAnswer is the one-based option number as a string.


public abstract class Question
{
    public string Prompt { get; }

    protected Question(string prompt)
    {
        Prompt = prompt;
    }

    public abstract void Display();

    public abstract bool CheckAnswer(string answer);
}

public class TextQuestion : Question
{
    private string correctAnswer;

    public TextQuestion(string prompt, string correctAnswer)
        : base(prompt)
    {
        this.correctAnswer = correctAnswer;
    }

    public override void Display()
    {
        Console.WriteLine(Prompt);
        Console.WriteLine("Type your answer:");
    }

    public override bool CheckAnswer(string answer)
    {
        return answer.Equals(
            correctAnswer,
            StringComparison.OrdinalIgnoreCase);
    }
}

public class MultipleChoiceQuestion : Question
{
    private string correctAnswer;
    private string[] options;

    public MultipleChoiceQuestion(
        string prompt,
        string correctAnswer,
        string[] options)
        : base(prompt)
    {
        this.correctAnswer = correctAnswer;
        this.options = options;
    }

    public override void Display()
    {
        Console.WriteLine(Prompt);

        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }

        Console.WriteLine("Enter the option number:");
    }

    public override bool CheckAnswer(string answer)
    {
        return answer == correctAnswer;
    }
}

public class NumericQuestion : Question
{
    private double expectedAnswer;
    private double tolerance;

    public NumericQuestion(
        string prompt,
        double expectedAnswer,
        double tolerance)
        : base(prompt)
    {
        this.expectedAnswer = expectedAnswer;
        this.tolerance = tolerance;
    }

    public override void Display()
    {
        Console.WriteLine(Prompt);
        Console.WriteLine("Enter a number:");
    }

    public override bool CheckAnswer(string answer)
    {
        if (!double.TryParse(answer, out double number))
        {
            return false;
        }

        return Math.Abs(number - expectedAnswer) <= tolerance;
    }
}

