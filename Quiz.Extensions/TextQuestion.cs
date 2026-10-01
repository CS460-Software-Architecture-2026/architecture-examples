using Quiz.Core;

namespace Quiz.Extensions;

public class TextQuestion : Question<string>
{
    public TextQuestion(string questionString, string correctAnswer)
        : base(questionString, correctAnswer)
    {
    }
    
    public override string AskQuestion()
    {
        Console.WriteLine(QuestionString);
        Console.WriteLine("Type your answer:");
        
        return (Console.ReadLine() ?? "").Trim();
    }

    public override bool IsCorrectAnswer(string answer)
    {
        return answer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
    }
}