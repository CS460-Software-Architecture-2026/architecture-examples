namespace Hangman.Presenter.View;

public interface IHangmanMvpView
{
    void ShowExitMessage();
    
    void Show(HangmanViewModel hangmanViewModel);

    string? GetInput();
}

public class HangmanViewModel
{
    public char[]? GuessedLetters { get; init; }

    public int AttemptsLeft { get; init; }

    public required HangmanState State { get; init; }
}

public enum HangmanState
{
    Welcome,
}

public class HangmanMvpView : IHangmanMvpView
{

    public void ShowExitMessage()
    {
        Console.WriteLine("Thanks for playing! Goodbye!");
    }

    public void Show(HangmanViewModel hangmanViewModel)
    {
        switch (hangmanViewModel.State)
        {
            case HangmanState.Welcome:
                Console.Clear();
                Console.WriteLine("Welcome to Hangman!");
                Console.WriteLine("Guess the word by entering one letter at a time.");
                Console.WriteLine($"You have {hangmanViewModel.AttemptsLeft} attempts left.");
                Console.WriteLine();
                break;
        }
    }

    public string? GetInput() => Console.ReadLine();

    private void DrawHangman(HangmanViewModel viewModel)
    {
        int attempts = 6 - viewModel.AttemptsLeft;

        Console.WriteLine("  +---+");
        Console.WriteLine($"  |   |");

        if (attempts >= 1)
            Console.WriteLine("  O   |");
        else
            Console.WriteLine("      |");

        if (attempts >= 2)
            Console.WriteLine(" /|\\  |");
        else if (attempts >= 3)
            Console.WriteLine(" /|   |");
        else if (attempts >= 4)
            Console.WriteLine("  |   |");
        else
            Console.WriteLine("      |");

        if (attempts >= 5)
            Console.WriteLine(" / \\  |");
        else if (attempts >= 6)
            Console.WriteLine(" /    |");
        else
            Console.WriteLine("      |");

        Console.WriteLine("      |");
        Console.WriteLine("=========");
    }
}