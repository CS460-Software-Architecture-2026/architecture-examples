namespace OCP.Quiz;

public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");
        var questions = new[]
        {
            new TextQuestion(
                "What is the capital of France?",
                "Paris"),
            new MultipleChoiceQuestion(
                "Which number is prime?",
                "2",
                new[] { "4", "7", "9" }),
            new ErrorQuestion(
                "How old is Max Verstappen",
                29,
                4
        };

        new QuizRunner().Run(questions);
    }
}
