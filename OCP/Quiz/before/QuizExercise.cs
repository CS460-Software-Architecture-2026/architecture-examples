namespace OCP.Quiz;

public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");
        var questions = new[]
        {
            new Question(
                QuestionType.Text,
                "What is the capital of France?",
                "Paris",
                Array.Empty<string>()),
            new Question(
                QuestionType.MultipleChoice,
                "Which number is prime?",
                "2",
                new[] { "4", "7", "9" }),
            new Question(
                QuestionType.Text,
                "Which C# keyword creates a new object?",
                "new",
                Array.Empty<string>())
        };

        new QuizRunner().Run(questions);
    }
}
