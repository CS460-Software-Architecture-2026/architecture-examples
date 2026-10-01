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
    public QuestionType Type { get; }
    public string Prompt { get; }
    public string CorrectAnswer { get; }
    public string[] Options { get; }

    public Question(QuestionType type, string prompt, string correctAnswer, string[] options)
    {
        Type = type;
        Prompt = prompt;
        CorrectAnswer = correctAnswer;
        Options = options;
    }

    public abstract void Ask();
    public abstract bool CheckAnswer(string answer);
}

public class TextQuestion : Question
{
    public TextQuestion(string prompt, string correctAnswer)
        : base(QuestionType.Text, prompt, correctAnswer, Array.Empty<string>())
    {
    }
    public override void Ask()
    {
        Console.WriteLine(Prompt);
        Console.WriteLine("Type ur answer:");
    }

    public override bool CheckAnswer(string answer)
    {
        return answer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
    }
}
public class MultipleChoiceQuestion : Question
{
    public MultipleChoiceQuestion(string prompt, string[] options, string correctAnswer)
        : base(QuestionType.MultipleChoice, prompt, correctAnswer, options)
    {
    }
    public override void Ask()
    {
        Console.WriteLine(Prompt);
        for (int i = 0; i < Options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
        Console.WriteLine("Enter ur oprion number:");
    }
    public override bool CheckAnswer(string answer)
    {
        return answer == CorrectAnswer;
    }
}

/// numeric similar way 