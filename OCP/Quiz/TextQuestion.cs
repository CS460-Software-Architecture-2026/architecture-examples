namespace OCP.Quiz;

public record TextQuestion(string Prompt, string CorrectAnswer) : Question(Prompt)
{
    public override string Instructions => "Type your answer:";

    public override bool IsCorrect(string answer)
    {
        return answer.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase);
    }
}
