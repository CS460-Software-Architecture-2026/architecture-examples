using System.Globalization;
using Quiz.Core;

namespace Quiz.Extensions;

public class NumericQuestion : Question<double>
{
    private readonly double tolerance;

    public NumericQuestion(string questionString, double correctAnswer, double tolerance)
        : base(questionString, correctAnswer)
    {
        this.tolerance = tolerance;
    }

    public override string AskQuestion()
    {
        Console.WriteLine(QuestionString);
        Console.WriteLine("Enter a number (use '.' for decimals):");
        return (Console.ReadLine() ?? "").Trim();
    }

    public override bool IsCorrectAnswer(string answer)
    {
        return double.TryParse(answer, NumberStyles.Float, CultureInfo.InvariantCulture, out var number)
            && double.IsFinite(number)
            && Math.Abs(number - CorrectAnswer) <= tolerance;
    }
}
