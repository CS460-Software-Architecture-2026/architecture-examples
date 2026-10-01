namespace OCP.Quiz;

public interface IQuestion
{
    void Display();
    bool ValidateAnswer(string answer);
}

public enum QuestionType
{
    Text,
    MultipleChoice
}
