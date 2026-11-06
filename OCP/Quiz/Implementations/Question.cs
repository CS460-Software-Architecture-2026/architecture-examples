namespace OCP.Quiz;

using System;

public record Question : IQuestion
{
    public QuestionType Type { get; }
    public string Prompt { get; }
    public string CorrectAnswer { get; }
    public string[] Options { get; }

    public Question(QuestionType type, string prompt, string correctAnswer, string[] options)
    {
        Type = type;
        Prompt = prompt ?? string.Empty;
        CorrectAnswer = correctAnswer ?? string.Empty;
        Options = options ?? Array.Empty<string>();
    }

    public void Display()
    {
        Console.WriteLine(Prompt);

        switch (Type)
        {
            case QuestionType.Text:
                Console.WriteLine("Type your answer:");
                break;

            case QuestionType.MultipleChoice:
                for (int i = 0; i < Options.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Options[i]}");
                }
                Console.WriteLine("Enter the option number:");
                break;
        }
    }

    public bool ValidateAnswer(string answer)
    {
        switch (Type)
        {
            case QuestionType.Text:
                return string.Equals((answer ?? string.Empty).Trim(), CorrectAnswer, StringComparison.OrdinalIgnoreCase);

            case QuestionType.MultipleChoice:
                return (answer ?? string.Empty).Trim() == CorrectAnswer;

            default:
                return false;
        }
    }
}
