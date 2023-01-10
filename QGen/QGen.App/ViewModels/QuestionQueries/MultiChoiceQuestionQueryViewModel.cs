using QGen.App.Settings;
using QGen.Domain.Queries;
using QGen.Providers;
using System;

namespace QGen.App.ViewModels.QuestionQueries;
public class MultiChoiceQuestionQueryViewModel : QuestionQueryViewModel
{
    private readonly QuestionTemplate _questionTemplate;

    public int AnswerAmount { get; set; } = 4;
    public int CorrectAnswerAmount { get; set; } = 1;

    public MultiChoiceQuestionQueryViewModel(QuestionTemplates questionTemplates, IQuestionProvider questionProvider) : base(questionProvider)
    {
        _questionTemplate = questionTemplates.MultiChoiceQuestionTemplate;
    }

    public override bool CanRunQuery()
        => !string.IsNullOrWhiteSpace(EducationLevel) &&
           !string.IsNullOrWhiteSpace(Subject) &&
           !string.IsNullOrWhiteSpace(Topic) &&
           AnswerAmount >= CorrectAnswerAmount;

    public override bool CanPreviewQuery()
        => !string.IsNullOrWhiteSpace(EducationLevel) &&
           !string.IsNullOrWhiteSpace(Subject) &&
           !string.IsNullOrWhiteSpace(Topic) &&
           AnswerAmount >= CorrectAnswerAmount;

    public override QuestionQuery CreateQuestionQuery()
    {
        var query = new MultiChoiceQuestionQuery(EducationLevel, Subject, Topic, _questionTemplate.TemplateText, AnswerAmount, CorrectAnswerAmount);

        return query;
    }
}
