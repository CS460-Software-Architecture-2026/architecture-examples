namespace OCP.Quiz;

public class MultipleChoiceQuestion : Question
{
    private readonly string[] options;
    private readonly string correctAnswer;

    public MultipleChoiceQuestion(string prompt, string correctAnswer, string[] options) : base(prompt)
    {
        this.correctAnswer = correctAnswer;
        this.options = options;
    }

    protected override QuestionType Type => QuestionType.MultipleChoice;

    public override void Ask()
    {
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }
        Console.WriteLine("Enter the option number:");
    }

    public override bool CheckAnswer(string answer)
    {
        return answer == correctAnswer;
    }
}
