public abstract class Question
{
    public string Prompt {get; set;}
    public string CorrectAnswer {get; set;}
    public string[] Options {get; set;}

    public abstract void PrintQuestion();
    public abstract bool CheckAnswer(string answer);
}

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