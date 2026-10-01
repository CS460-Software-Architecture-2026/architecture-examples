namespace OCP.Quiz;

public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");
        Question[] questions =
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
                "new")
        };

        new QuizRunner().Run(questions);
    }
}
