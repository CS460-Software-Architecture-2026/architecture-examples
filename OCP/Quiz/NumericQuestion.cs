using System.Globalization;

namespace OCP.Quiz;

public record NumericQuestion(string Prompt, double ExpectedAnswer, double Tolerance) : Question(Prompt)
{
    public override string Instructions => "Enter a number:";

    public override bool IsCorrect(string answer)
    {
        return double.TryParse(answer, NumberStyles.Float, CultureInfo.InvariantCulture, out double value)
            && Math.Abs(value - ExpectedAnswer) <= Tolerance;
    }
}
