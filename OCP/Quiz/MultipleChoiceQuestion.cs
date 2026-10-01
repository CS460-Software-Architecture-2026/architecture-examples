namespace OCP.Quiz;

public class MultipleChoiceQuestion : Question
{
    private string correctAnswer;
    private string[] options;

    public MultipleChoiceQuestion(
        string prompt,
        string correctAnswer,
        string[] options)
        : base(prompt)
    {
        this.correctAnswer = correctAnswer;
        this.options = options;
    }

    public override void Display()
    {
        Console.WriteLine(Prompt);

        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }

        Console.WriteLine("enter the option number:");
    }

    public override bool CorrectAnswer(string answer)
    {
        return answer == correctAnswer;
    }
}