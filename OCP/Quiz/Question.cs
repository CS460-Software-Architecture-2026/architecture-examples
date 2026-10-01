namespace OCP.Quiz;

public abstract record Question(string Prompt)
{
    public abstract string Instructions { get; }

    public abstract bool IsCorrect(string answer);
}
