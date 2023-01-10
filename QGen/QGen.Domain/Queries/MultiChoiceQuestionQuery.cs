namespace QGen.Domain.Queries;

public class MultiChoiceQuestionQuery : QuestionQuery
{
    private int _answerAmount;
    private int _correctAnswersAmount;

    public MultiChoiceQuestionQuery(string templateString, int? answerAmount = 4, int? correctAnswersAmount = 1) : base(templateString)
    {
        _answerAmount = answerAmount ?? 4;
        _correctAnswersAmount = correctAnswersAmount ?? 1;
    }

    public MultiChoiceQuestionQuery(string educationLevel, string subject, string topic, string templateString, int? answerAmount = 4, int? correctAnswersAmount = 1) : base(educationLevel, subject, topic, templateString)
    {
        _answerAmount = answerAmount ?? 4;
        _correctAnswersAmount = correctAnswersAmount ?? 1;
    }

    public override QuestionTypes QuestionType => QuestionTypes.MULTI_CHOICE;

    public int AnswerAmount { get => _answerAmount; set => _answerAmount = value; }
    public int CorrectAnswersAmount { get => _correctAnswersAmount; set => _correctAnswersAmount = value; }

    public override string GetText()
        => base.GetText().Replace("{answerAmount}", AnswerAmount.ToString())
                         .Replace("{correctAnswersAmount}", CorrectAnswersAmount.ToString());
}
