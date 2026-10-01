using Quiz.Core;

namespace Quiz.Extensions;

public class MultipleChoice : Question<string>
{
    protected IReadOnlyList<string> AnswerOptions { get; }

    public MultipleChoice(
        string questionString,
        IReadOnlyList<string> answerOptions,
        string correctAnswer)
        : base(questionString, correctAnswer)
    {
        AnswerOptions = answerOptions;
    }


    public override string AskQuestion()
    {
        Console.WriteLine(QuestionString);
        
        for (var i = 0; i < AnswerOptions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {AnswerOptions[i]}");
        }
        Console.WriteLine("Enter the option number:");
        return (Console.ReadLine() ?? "").Trim();
    }

    public override bool IsCorrectAnswer(string answer)
    {
        return answer.Equals(CorrectAnswer, StringComparison.Ordinal);
    }
}