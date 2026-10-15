namespace OCP.Quiz;

public class TextQuestion : Question
{
    private readonly string correctAnswer;

    public TextQuestion(string prompt, string correctAnswer)
        : base(prompt)
    {
        this.correctAnswer = correctAnswer;
    }

    public override void Display()
    {
        Console.WriteLine("Type your answer:");
    }

    public override bool CheckAnswer(string answer)
    {
        return answer.Equals(
            correctAnswer,
            StringComparison.OrdinalIgnoreCase);
    }
}