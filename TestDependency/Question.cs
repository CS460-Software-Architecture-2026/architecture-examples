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
    protected Question(string prompt)
    {
        Prompt = prompt;
    }

    public string Prompt { get; }

    protected abstract QuestionType Type { get; }
    public abstract void Ask();

    public abstract bool CheckAnswer(string answer);
}
