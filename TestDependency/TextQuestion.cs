namespace OCP.Quiz;

public class TextQuestion : Question
{
    protected override QuestionType Type => QuestionType.Text;
    private readonly string correctAnswer;

    public TextQuestion(string prompt, string correctAnswer) : base(prompt)
    {
        this.correctAnswer = correctAnswer;
    }

    public override void Ask()
    {
        Console.WriteLine("Type your answer:");
    }

    public override bool CheckAnswer(string answer)
    {
        return answer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase);
    }
}
