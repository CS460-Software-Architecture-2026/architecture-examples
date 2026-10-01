using Quiz.Core; 
namespace Quiz.Questions;

// The starting model stores both kinds of question in the same shape.
// For multiple choice, CorrectAnswer is the one-based option number as a string.

public class TextQuestion : Question
{
    public TextQuestion(string prompt, string correctAnswer)
    {
        Prompt = prompt;
        CorrectAnswer = correctAnswer;
        
    }

    public override void PrintQuestion()
    {
        Console.WriteLine(Prompt);
        Console.WriteLine("Type your answer:");
    }

}

public class MultipleChoiceQuestion : Question
{
    public string[] Options { get; set; }

    public MultipleChoiceQuestion(string prompt, string correctAnswer, string[] options)
    {
        Prompt = prompt;
        CorrectAnswer = correctAnswer;
        Options = options;
    }

    public override void PrintQuestion()
    {
        Console.WriteLine(Prompt);
        for (int i = 0; i < Options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
        Console.WriteLine("Enter the option number:");
    }

}

public class NumericQuestion : Question
{
    public int ExpectedAnswer { get; }
    public int Tolerance { get; }

    public NumericQuestion(string prompt, int correctAnswer, int tolerance)
    {
        Prompt = prompt;
        ExpectedAnswer = correctAnswer;
        Tolerance = tolerance;
    }

    public override void PrintQuestion()
    {
        Console.WriteLine(Prompt);
        Console.WriteLine("Type your answer (number):");
    }

    public override bool CheckAnswer(string answer)
    {
        return int.TryParse(answer, out int userAnswer)
            && Math.Abs((long)userAnswer - ExpectedAnswer) <= Tolerance;
    }
}