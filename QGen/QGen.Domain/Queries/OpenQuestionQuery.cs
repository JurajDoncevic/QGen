using System;
using System.Collections.Generic;
namespace QGen.Domain.Queries;

public class OpenQuestionQuery : QuestionQuery
{
    public OpenQuestionQuery(string templateString) : base(templateString)
    {
    }

    public OpenQuestionQuery(string educationLevel, string subject, string topic, string templateString) : base(educationLevel, subject, topic, templateString)
    {
    }

    public override QuestionTypes QuestionType => QuestionTypes.OPEN;
}
