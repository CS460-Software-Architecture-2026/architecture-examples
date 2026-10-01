using Quiz.Core;
using Quiz.Extensions;

namespace Quiz.App;

public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");
        var questions = new Question[]
        {
            new TextQuestion(
                "What is the capital of France?",
                "Paris"
                ),
            new MultipleChoice(
                "Which number is prime?",
                new[] { "4", "7", "9" },
                "2"),
            new TextQuestion(
                "Which C# keyword creates a new object?",
                "new"),
            new NumericQuestion(
                "What temperature does water boil at in Celsius? (within 2 degrees)",
                100,
                2)
        };

        new QuizRunner().Run(questions);
    }
}
