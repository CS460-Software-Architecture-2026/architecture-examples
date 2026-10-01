namespace OCP.Quiz;

public class QuizExercise
{
    public void Run()
    {
        Console.WriteLine("QUIZ EXERCISE");
        var questions = new Question[]
        {
            new Text 
            { 
                Prompt = "What is the capital of France?", 
                CorrectAnswer = "Paris" 
            },
            new MultipleChoice 
            { 
                Prompt = "Which number is prime?", 
                CorrectAnswer = "2", 
                Options = new[] { "4", "7", "9" } 
            },
            new Text 
            { 
                Prompt = "Which C# keyword creates a new object?", 
                CorrectAnswer = "new" 
            }
        };

        new QuizRunner().Run(questions);
    }
}
