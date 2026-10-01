namespace OCP.Quiz;


public abstract record Question(string Prompt)
{
    public abstract string GetQuestionText();
    public abstract bool IsCorrect(string answer);
    
    public virtual string ReadAnswer()
    {
        Console.Write("Your answer: ");
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }
}


