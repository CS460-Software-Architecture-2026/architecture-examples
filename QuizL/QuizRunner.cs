namespace QuizL;

public class QuizRunner
{
    public void Run(IEnumerable<Question> questions)
    {
        int score = 0;
        int total = 0;
        QuestionCom QuestionCom = new QuestionCom();

        foreach (var question in questions)
        {
            total++;
            
            QuestionCom.WhatQuestion(question);
            
            QuestionCom.QuestionWrite();

            QuestionCom.QuestionAskAnswer();

            if (QuestionCom.CheckAnswer())
            {
                score++;
            }

            Console.WriteLine(QuestionCom.GetCorrectAnswer() ? "Correct!" : "Incorrect.");
        }

        Console.WriteLine($"Score: {score}/{total}");
    }
}
