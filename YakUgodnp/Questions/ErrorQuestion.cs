using OCP.Quiz.Application;

namespace OCP.Quiz.Questions;

public class ErrorQuestion : Question
{
    private readonly double correctAnswer;
    private double error;

    public ErrorQuestion(string prompt, double correctAnswer, double error) : base(prompt)
    {
        this.correctAnswer = correctAnswer;
        this.error = error;
    }

    public override void Display()
    {
        Console.WriteLine("Type your answer:");
    }

    public override bool IsCorrectAnswer(string answer)
    {
        throw new NotImplementedException();
    }

    public bool CheckAnswer(string answer)
    {
        if (!double.TryParse(answer, out double value))
        {
            return false;
        }
        return Math.Abs(value - correctAnswer) <= error;
    }
}