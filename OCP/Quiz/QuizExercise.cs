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
                new[] { "4", "7", "9" },
                2),
            new TextQuestion(
                "Which C# keyword creates a new object?",
                "new"),
            new NumericQuestion(
                "What is the value of pi to two decimal places?",
                3.14,
                0.005)
        };

        new QuizRunner().Run(questions);
    }
}
