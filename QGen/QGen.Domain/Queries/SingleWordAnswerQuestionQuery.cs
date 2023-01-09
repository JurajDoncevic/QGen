namespace QGen.Domain.Queries;

public class SingleWordAnswerQuestionQuery : QuestionQuery
{
    public SingleWordAnswerQuestionQuery(string templateString) : base(templateString)
    {
    }

    public SingleWordAnswerQuestionQuery(string educationLevel, string subject, string topic, string templateString) : base(educationLevel, subject, topic, templateString)
    {
    }

    public override QuestionTypes QuestionType => QuestionTypes.SINGLE_WORD;
}
