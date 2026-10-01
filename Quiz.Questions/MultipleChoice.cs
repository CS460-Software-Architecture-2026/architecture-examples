using Quiz.Core;
namespace Quiz.Questions;

public class MultipleChoice : Question {
    public override void PrintQuestion() {
        for (int i = 0; i < Options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {Options[i]}");
        }
        Console.WriteLine("Enter the option number:");
    }

    public override bool CheckAnswer(string answer) {
        return answer == CorrectAnswer;
    }
}