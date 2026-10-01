using OCP.Quiz;

namespace QuestionTypes;

public class QuestionText : Question
{
    public QuestionText(string prompt, string correctAnswer) : base(prompt, correctAnswer)
    {
    }

    public override void Process()
    {
        Console.WriteLine("Type your answer:");
    }

    public override bool Evaluate(string answer)
    {
        return answer.Equals(
            CorrectAnswer,
            StringComparison.OrdinalIgnoreCase);
    }
}

public class QuestionMultipleChoice : Question
{
    public string[] Options { get; set; }
    public QuestionMultipleChoice(string prompt, string[] options, string correctAnswer) : base(prompt, correctAnswer)
    {
        Options = options;
    }

    public override void Process()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
        Console.WriteLine("Enter the option number:");

    }

    public override bool Evaluate(string answer)
    {
        return answer == CorrectAnswer;
    }
}