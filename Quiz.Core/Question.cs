namespace Quiz.Core;

public abstract class Question
{
    public abstract string AskQuestion();
    public abstract bool IsCorrectAnswer(string input);
}

public abstract class Question<TAnswer> : Question
{
    protected string QuestionString { get; }
    protected TAnswer CorrectAnswer { get; }

    protected Question(string questionString, TAnswer correctAnswer)
    {
        QuestionString = questionString;
        CorrectAnswer = correctAnswer;
    }
}