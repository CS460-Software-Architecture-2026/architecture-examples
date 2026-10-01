namespace OCP.Quiz;

public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");
        var questions = new IQuestion[]
        {
            new TextQuestion(
                "What is the capital of France?",
                "Paris"),
            new MultipleChoiceQuestion(
                "Which number is prime?",
                new[] { "4", "7", "9" },
                2),
            new TextQuestion(
                "Which C# keyword creates a new object?",
                "new")
        };

        new QuizRunner().Run(questions);
    }
}
