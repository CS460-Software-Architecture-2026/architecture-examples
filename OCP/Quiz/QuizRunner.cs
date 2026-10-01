namespace OCP.Quiz;

public class QuizRunner
{
    public void Run(IEnumerable<Question> questions)
    {
        int score = 0;
        int total = 0;

        foreach (var question in questions)
        {
            total++;
            question.Ask();
            // Console.WriteLine(question.Prompt);

            // Adding a question type currently means editing both switches.
            // switch (question.Type)
            // {
            //     case QuestionType.Text:
            //         Console.WriteLine("Type your answer:");
            //         break;
            //
            //     case QuestionType.MultipleChoice:
            //         for (int i = 0; i < question.Options.Length; i++)
            //         {
            //             Console.WriteLine($"{i + 1}. {question.Options[i]}");
            //         }
            //         Console.WriteLine("Enter the option number:");
            //         break;
            // }

            string answer = (Console.ReadLine() ?? "").Trim();
            bool correct = question.CheckAnswer(answer);
            // bool correct = false;

            // switch (question.Type)
            // {
            //     case QuestionType.Text:
            //         correct = answer.Equals(
            //             question.CorrectAnswer,
            //             StringComparison.OrdinalIgnoreCase);
            //         break;
            //
            //     case QuestionType.MultipleChoice:
            //         correct = answer == question.CorrectAnswer;
            //         break;
            // }

            if (correct)
            {
                score++;
            }

            Console.WriteLine(correct ? "Correct!" : "Incorrect.");
        }

        Console.WriteLine($"Score: {score}/{total}");
    }
}
