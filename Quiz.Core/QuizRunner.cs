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
            Console.WriteLine(question.GetQuestionText());

            string answer = question.ReadAnswer();
            
            bool correct = question.IsCorrect(answer);
            

            if (correct)
            {
                score++;
            }

            Console.WriteLine(correct ? "Correct!" : "Incorrect.");
        }

        Console.WriteLine($"Score: {score}/{total}");
    }
}
