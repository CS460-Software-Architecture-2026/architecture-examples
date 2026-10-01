namespace OCP.Quiz;

public class TextQuestion : Question
{
    private string correctAnswer;

    public TextQuestion(string prompt, string correctAnswer)
        : base(prompt)
    {
        this.correctAnswer = correctAnswer;
    }

    public override void Display()
    {
        Console.WriteLine(Prompt);
        Console.WriteLine("type your answer:");
    }

    public override bool CorrectAnswer(string answer)
    {
        return answer.Equals(
            correctAnswer,
            StringComparison.OrdinalIgnoreCase);
    }
}