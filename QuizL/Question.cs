namespace QuizL;

// The starting model stores both kinds of question in the same shape.
// For multiple choice, CorrectAnswer is the one-based option number as a string.

public record Question(
    QuestionType Type,
    string Prompt,
    string CorrectAnswer,
    string[] Options,
    int tolerance = 0);

public class QuestionCom
{
    QuestionType Type;
    Question Question;
    private string Answer;
    private bool Correct = false;

    public void WhatQuestion(Question question)
    {
        Question = question;
        Type = question.Type;
        Console.WriteLine(question.Prompt);
    }

    public void QuestionWrite()
    {
        switch (Type)
        {
            case QuestionType.Text:
                Console.WriteLine("Type your answer:");
                break;

            case QuestionType.MultipleChoice:
                for (int i = 0; i < Question.Options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Question.Options[i]}");
                }

                Console.WriteLine("Enter the option number:");
                break;
            case QuestionType.Numeric:
                Console.WriteLine("Type your answer:");
                break;
        }
    }

    public void QuestionAskAnswer()
    {
        Answer = (Console.ReadLine() ?? "").Trim();
    }

    public bool CheckAnswer()
    {
        Correct = false;
        switch (Type)
        {
            case QuestionType.Text:
                Correct = Answer.Equals(
                    Question.CorrectAnswer,
                    StringComparison.OrdinalIgnoreCase);
                break;

            case QuestionType.MultipleChoice:
                Correct = Answer == Question.CorrectAnswer;
                break;
            case QuestionType.Numeric:
                int nubmer = Convert.ToInt32(Answer);
                int cornumber = Convert.ToInt32(Question.CorrectAnswer);
                Correct = ((nubmer - Question.tolerance) <= cornumber || cornumber >= (nubmer + Question.tolerance));
                break;
        }
        return Correct;
    }
    
    public bool GetCorrectAnswer()
    {
        return Correct;
    }

}