using Quiz.Core;
namespace Quiz.Questions;

public class Text : Question {
    public override void PrintQuestion() {
        Console.WriteLine("Type your answer:");
    }
    public override bool CheckAnswer(string answer) {
        return answer.Equals(
            CorrectAnswer,
            StringComparison.OrdinalIgnoreCase);
    }
}