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

    public abstract bool CorrectAnswer(string answer);
}