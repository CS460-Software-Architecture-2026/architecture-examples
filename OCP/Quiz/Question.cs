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