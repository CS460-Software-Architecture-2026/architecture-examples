namespace OCP.Quiz;

using System;
using System.Collections.Generic;

public class QuizRunner
{
    public void Run(IEnumerable<IQuestion> questions)
    {
        int score = 0;
        int total = 0;

        foreach (var question in questions)
        {
            total++;
            question.Display();

            string answer = (Console.ReadLine() ?? string.Empty).Trim();
            bool correct = question.ValidateAnswer(answer);

            if (correct)
            {
                score++;
            }

            Console.WriteLine(correct ? "Correct!" : "Incorrect.");
        }

        Console.WriteLine($"Score: {score}/{total}");
    }
}
