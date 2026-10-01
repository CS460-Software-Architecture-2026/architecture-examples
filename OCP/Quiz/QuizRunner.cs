namespace OCP.Quiz;

public class QuizRunner
{
    public void Run(IEnumerable<Question> questions)
    {
        int score = 0;
        int total = 0;

        foreach (var question in questions)
        {
            total++;
            question.Display();
            string answer = (Console.ReadLine() ?? "").Trim();
            bool correct = question.CorrectAnswer(answer);
            if (correct)
            {
                score++;
            }

            Console.WriteLine(correct ? "correct!" : "incorrect.");
        }

        Console.WriteLine($"Score: {score}/{total}");
    }
}