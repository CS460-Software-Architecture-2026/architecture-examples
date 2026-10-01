namespace OCP.Quiz.Questions;

public class TextQuestion : Question
{
    public TextQuestion(string prompt, string correctAnswer) : base(prompt, correctAnswer)
    {
    }

    public override void GetInput()
    {
        Console.WriteLine("Type your answer:");
    }

    public override bool CheckAnswer(string answer)
    {
        return answer.Equals(
            CorrectAnswer,
            StringComparison.OrdinalIgnoreCase);
    }
}