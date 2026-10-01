namespace OCP.Quiz;

public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");
        IQuestion[] questions =
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
                "new"),
            new NumericQuestion(
                "What is pi rounded to two decimal places?",
                3.14m,
                0.01m),
            new TrueFalseQuestion(
                "C# is a statically typed language.",
                true)
        };

        new QuizRunner().Run(questions);
    }
}
