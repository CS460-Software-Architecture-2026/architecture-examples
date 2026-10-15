namespace OCP.Quiz;

public class MultipleChoiceQuestion : Question
{
    private readonly string correctAnswer;
    private readonly string[] options;

    public MultipleChoiceQuestion(string prompt, string[] correctAnswer, string[] options)
        : base(prompt)
    {
        this.correctAnswer = correctAnswer;
        this.options = options;
    }

    public override void Display()
    {
        for (int i = 0; i < question.Options.Length; i++)
        {
           Console.WriteLine($"{i + 1}. {question.Options[i]}");
        }

        Console.WriteLine("Enter the option number:");
    }

    public override bool CheckAnswer(string[] answer)
    {
        return answer == this.correctAnswer;
    }


}