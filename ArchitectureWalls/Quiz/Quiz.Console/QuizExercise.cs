namespace Quiz.Application;
using Quiz.Core;
using Quiz.Questions;
public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");
        var questions = new List<Question>
        {
            new TextQuestion("What is the capital of France?", "Paris"),
            new MultipleChoiceQuestion(
                "Which number is prime?",
                "2",
                new[] { "4", "7", "9" }),
            new TextQuestion("Which C# keyword creates a new object?", "new"),
            new NumericQuestion(
                "What is 100 rounded to the nearest ten?",
                100,
                5)
        };

        new QuizRunner().Run(questions);
    }
}
