namespace OCP.Quiz;

using System;

public record Question
{
    public QuestionType Type { get; }
    public string Prompt { get; }
    public string CorrectAnswer { get; }
    public string[] Options { get; }

    // Lightweight behavior holders (no new types introduced)
    public Action Display { get; init; }        
    public Func<string, bool> Validate { get; init; }

    public Question(QuestionType type, string prompt, string correctAnswer, string[] options)
    {
        Type = type;
        Prompt = prompt ?? string.Empty;
        CorrectAnswer = correctAnswer ?? string.Empty;
        Options = options ?? Array.Empty<string>();

        switch (Type)
        {
            case QuestionType.Text:
                Display = () =>
                {
                    Console.WriteLine(Prompt);
                    Console.WriteLine("Type your answer:");
                };
                Validate = answer =>
                    string.Equals((answer ?? string.Empty).Trim(), CorrectAnswer, StringComparison.OrdinalIgnoreCase);
                break;

            case QuestionType.MultipleChoice:
                Display = () =>
                {
                    Console.WriteLine(Prompt);
                    for (int i = 0; i < Options.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {Options[i]}");
                    }
                    Console.WriteLine("Enter the option number:");
                };
                Validate = answer => (answer ?? string.Empty).Trim() == CorrectAnswer;
                break;

            default:
                Display = () => Console.WriteLine(Prompt);
                Validate = _ => false;
                break;
        }
    }
}
