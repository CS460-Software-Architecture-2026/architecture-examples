namespace OCP.Quiz.Questions;

public class MultipleChoiceQuestion: Question
{
    public MultipleChoiceQuestion(string prompt, string correctAnswer, string[] options) : base(prompt, correctAnswer)
    {
        Options = options;
    }

    public string[] Options { get; }
    
    public override void GetInput()
    {
        for (int i = 0; i < Options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
        Console.WriteLine("Enter the option number:");
    }

    public override bool CheckAnswer(string answer)
    {
        return answer == CorrectAnswer;
    }
}