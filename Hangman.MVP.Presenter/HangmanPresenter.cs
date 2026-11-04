namespace Hangman.MVP.Presenter;

using Examples.Hangman;
using Hangman.Presenter.View;

public class HangmanPresenter(Hangman model, IHangmanMvpView view)
{
    private readonly Hangman game = model;

    private readonly IHangmanMvpView view = view;

    public void Run()
    {
        string command = null;
            Console.WriteLine("Type 'START' to begin playing Hangman, or 'EXIT' to quit.");
            
            while (true)
            {
                command = view.GetInput()!;
                var trimmedCommand = command?.Trim().ToUpper();
                
                switch (trimmedCommand)
                {
                    case "START":
                        if (!game.IsGameEnded)
                        {
                            game.StartGame();
                            view.Show(new HangmanViewModel()
                            {
                                State = HangmanState.Welcome
                            });
                        }
                        else
                        {
                            Console.WriteLine("Game is already in progress or finished. Type 'RESTART' to start a new game.");
                        }
                        break;
                    case "RESTART":
                        game.StartGame();
                        view.Show(new HangmanViewModel()
                        {
                            State = HangmanState.Welcome
                        });
                        break;
                    case "EXIT":
                        view.ShowExitMessage();
                        return;
                    case "GUESS":
                        Console.WriteLine("Please enter a single letter to guess:");
                        var guess = view.GetInput();
                        if (!string.IsNullOrEmpty(guess) && guess.Length == 1 && char.IsLetter(guess[0]))
                        {
                            try
                            {
                                game.MakeGuess(guess[0]);
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please enter a single letter.");
                        }
                        break;
                    default:
                        if (!string.IsNullOrEmpty(trimmedCommand) && trimmedCommand.Length == 1 && char.IsLetter(trimmedCommand[0]))
                        {
                            // Allow direct letter input as a shortcut
                            try
                            {
                                game.MakeGuess(trimmedCommand[0]);
                            }
                            catch (InvalidOperationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid command. Use 'START', 'RESTART', 'EXIT', 'GUESS', or just type a letter to guess.");
                        }
                        break;
                }
                
                if (game.IsGameEnded)
                {
                    Console.WriteLine("Game finished! Type 'RESTART' to play again or 'EXIT' to quit.");
                }
            }
    }
}   
