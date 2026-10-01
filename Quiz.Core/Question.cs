namespace Quiz.Core;

public abstract class Question
{
    public string Prompt {get; set;}
    public string CorrectAnswer {get; set;}
    public string[] Options {get; set;}

    public abstract void PrintQuestion();
    public abstract bool CheckAnswer(string answer);
}
