namespace OCP.Quiz;

public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");

        var questions = new Question[]
        {
            new TextQuestion(
                "What is the capital of France?",
                "Paris"),

            new MultipleChoiceQuestion(
                "Which number is prime?",
                "2",
                new[] { "4", "7", "9" }),

            new TextQuestion(
                "Which C# keyword creates a new object?",
                "new"),
            new NumericQuestion(
                "What is 10 divided by 4?",
                2.5,
                0.1)
        };

        new QuizRunner().Run(questions);
    }
}