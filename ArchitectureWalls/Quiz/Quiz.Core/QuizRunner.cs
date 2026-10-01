namespace Quiz.Core;


public abstract class Question
{
    public string Prompt { get; set; }
    public string CorrectAnswer { get; set; }

    public abstract void PrintQuestion();

    public virtual bool CheckAnswer(string answer)
    {
        return answer == CorrectAnswer;
    }
}
public class QuizRunner
{
    public void Run(List<Question> questions)
    {
        int score = 0;
        int total = 0;

        foreach (var question in questions)
        {
            total++;
            question.PrintQuestion();

            string answer = (Console.ReadLine() ?? "").Trim();
            bool correct = question.CheckAnswer(answer);

            if (correct)
            {
                score++;
            }

            Console.WriteLine(correct ? "Correct!" : "Incorrect.");
        }

        Console.WriteLine($"Score: {score}/{total}");
    }
}
