namespace OCP.Quiz;

public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");
        var questions = new Question[]
        {
            new TextQuestion
            {
                Prompt = "What is the capital of France?",
                CorrectAnswer = "Paris"
            },
            new MultipleChoiceQuestion
            {
                Prompt = "Which number is prime?",
                Options = new[] { "4", "7", "9" },
                CorrectAnswer = "2"
            },
            new TextQuestion
            {
                Prompt = "Which C# keyword creates a new object?",
                CorrectAnswer = "new"
            },
            //numeric
        };

        new QuizRunner().Run(questions);
    }
}