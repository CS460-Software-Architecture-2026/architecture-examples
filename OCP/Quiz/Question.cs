using OCP.Quiz.Questions;

namespace OCP.Quiz;

// The starting model stores both kinds of question in the same shape.
// For multiple choice, CorrectAnswer is the one-based option number as a string.

public abstract class Question
{
    public string Prompt { get; }
    protected string CorrectAnswer { get;}
    
    public abstract void GetInput();
    public abstract bool CheckAnswer(string input);
    
    protected Question(string prompt, string correctAnswer)
    {
        Prompt = prompt;
        CorrectAnswer = correctAnswer;
    }
}