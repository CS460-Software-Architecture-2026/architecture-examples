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
            Console.WriteLine(question.Prompt);

            // Adding a question type currently means editing both switches.
            question.GetInput();

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