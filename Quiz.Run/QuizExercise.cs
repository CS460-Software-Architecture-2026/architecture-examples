namespace OCP.Quiz;

public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");
        var questions = new Question[]
        {
            new OpenTextQuestion(
                "What is the capital of France?",
                "Paris"),
            new MultipleChoiceQuestion(
                "Which number is prime?",
                new[] { "4", "7", "9" },
                "2"),
            new NumericToleranceQuestion(
                "Year of Linux OS first release?",
                1991, 
                1)
        };

        new QuizRunner().Run(questions);
    }
}
