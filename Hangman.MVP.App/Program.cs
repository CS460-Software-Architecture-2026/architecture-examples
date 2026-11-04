using Examples.Hangman;
using Hangman.MVP.Presenter;
using Hangman.Presenter.View;

// Create the MVC components
var model = new Examples.Hangman.Hangman();
var view = new HangmanMvpView();

var presenter = new HangmanPresenter(model, view);

