namespace OCP.Quiz;

// The starting model stores both kinds of question in the same shape.
// For multiple choice, CorrectAnswer is the one-based option number as a string.
// public record Question(
//     QuestionType Type,
//     string Prompt,
//     string CorrectAnswer,
//     string[] Options);

public abstract class Question
{
    public string Prompt { get; set; }
    public string CorrectAnswer { get; set; }

    protected Question(string prompt,  string correctAnswer)
    {
        Prompt = prompt;
        CorrectAnswer = correctAnswer;
    }
    
    public abstract void Process();
    public abstract bool Evaluate(string answer);
}

public class QuestionText : Question
{
    public QuestionText(string prompt, string correctAnswer) : base(prompt, correctAnswer)
    {
    }

    public override void Process()
    {
        Console.WriteLine("Type your answer:");
    }

    public override bool Evaluate(string answer)
    {
        return answer.Equals(
            CorrectAnswer,
            StringComparison.OrdinalIgnoreCase);
    }
}

public class QuestionMultipleChoice : Question
{
    public string[] Options { get; set; }
    public QuestionMultipleChoice(string prompt, string[] options, string correctAnswer) : base(prompt, correctAnswer)
    {
        Options = options;
    }

    public override void Process()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
        Console.WriteLine("Enter the option number:");

    }

    public override bool Evaluate(string answer)
    {
        return answer == CorrectAnswer;
    }
}