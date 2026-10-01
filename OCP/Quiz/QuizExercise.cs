namespace OCP.Quiz;

public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");
        Question[] questions = new Question[]
        {
            new QuestionText(
                "What is the capital of France?",
                "Paris"),
            new QuestionMultipleChoice(
                "Which number is prime?",
                new[] { "4", "7", "9" },
                "2"
                ),
            new QuestionText(
                "Which C# keyword creates a new object?",
                "new")
        };

        new QuizRunner().Run(questions);
    }
}
