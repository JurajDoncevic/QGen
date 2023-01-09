namespace QGen.Domain.Queries;

public class FillBlanksQuestionQuery : QuestionQuery
{
    public FillBlanksQuestionQuery(string templateString) : base(templateString)
    {
    }

    public FillBlanksQuestionQuery(string educationLevel, string subject, string topic, string templateString) : base(educationLevel, subject, topic, templateString)
    {
    }

    public override QuestionTypes QuestionType => QuestionTypes.FILL_BLANKS;
}
