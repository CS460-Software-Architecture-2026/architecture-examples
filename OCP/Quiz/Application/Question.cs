namespace OCP.Quiz.Application;

public abstract class Question
{

    public string Prompt { get; }

    protected Question(string prompt)
    {
        Prompt = prompt;
    }

    public abstract void Display();
    public abstract bool IsCorrectAnswer(string answer);
}
