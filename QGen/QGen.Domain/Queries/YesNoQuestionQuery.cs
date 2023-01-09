namespace QGen.Domain.Queries;

public class YesNoQuestionQuery : QuestionQuery
{
    public YesNoQuestionQuery(string templateString) : base(templateString)
    {
    }

    public YesNoQuestionQuery(string educationLevel, string subject, string topic, string templateString) : base(educationLevel, subject, topic, templateString)
    {
    }

    public override QuestionTypes QuestionType => QuestionTypes.YES_NO;
}
