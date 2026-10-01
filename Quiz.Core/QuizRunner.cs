namespace Quiz.Core;

public class QuizRunner
{
    public void Run(IEnumerable<Question> questions)
    {
        var score = 0;
        var total = 0;

        foreach (var question in questions)
        {
            total++;
            
            var answer = question.AskQuestion();
            
            var correct = question.IsCorrectAnswer(answer);

            if (correct)
            {
                score++;
            }

            Console.WriteLine(correct ? "Correct!" : "Incorrect.");
        }

        Console.WriteLine($"Score: {score}/{total}");
    }
}