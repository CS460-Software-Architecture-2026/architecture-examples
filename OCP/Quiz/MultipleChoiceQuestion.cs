namespace OCP.Quiz;

public record MultipleChoiceQuestion(string Prompt, string[] Options, int CorrectOptionNumber) : Question(Prompt)
{
    public override string Instructions =>
        string.Join(Environment.NewLine, Options.Select((option, i) => $"{i + 1}. {option}"))
        + Environment.NewLine + "Enter the option number:";

    public override bool IsCorrect(string answer)
    {
        return answer == CorrectOptionNumber.ToString();
    }
}
