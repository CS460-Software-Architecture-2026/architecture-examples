using OCP.Quiz;
using System.Globalization;

public record MultipleChoiceQuestion(
    string Prompt,
    string[] Options,
    string CorrectAnswer
) : Question(Prompt)
{
    public override string GetQuestionText()
    {
        var optionsText = string.Join("\n", Options.Select((opt, i) => $"{i + 1}. {opt}"));
        return $"{Prompt}\n{optionsText}";
    }

    public override bool IsCorrect(string answer)
    {
        string trimmed = answer.Trim();

        // Перевірка 1: користувач ввів номер варіанта (наприклад, "2")
        if (int.TryParse(trimmed, out int choice) && choice >= 1 && choice <= Options.Length)
        {
            return string.Equals(Options[choice - 1], CorrectAnswer, StringComparison.OrdinalIgnoreCase);
        }

        // Перевірка 2: користувач ввів сам текст відповіді (наприклад, "7")
        return string.Equals(trimmed, CorrectAnswer, StringComparison.OrdinalIgnoreCase);
    }
}


public record OpenTextQuestion(
    string Prompt, 
    string CorrectAnswer
) : Question(Prompt)
{
    public override string GetQuestionText() => Prompt;

    public override bool IsCorrect(string answer) =>
        string.Equals(answer.Trim(), CorrectAnswer.Trim(), StringComparison.OrdinalIgnoreCase);
}


public record NumericToleranceQuestion(
    string Prompt,
    double ExpectedAnswer,
    double Tolerance
) : Question(Prompt)
{
    public override string GetQuestionText() => Prompt;

    public override bool IsCorrect(string answer)
    {
        // InvariantCulture коректно парсить крапку як десятковий роздільник
        if (!double.TryParse(answer.Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out double parsedValue))
        {
            return false;
        }

        return Math.Abs(parsedValue - ExpectedAnswer) <= Tolerance;
    }
}