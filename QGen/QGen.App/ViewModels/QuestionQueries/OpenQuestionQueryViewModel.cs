using QGen.Domain.Queries;
using QGen.App.Settings;
using QGen.Providers;

namespace QGen.App.ViewModels.QuestionQueries;
public class OpenQuestionQueryViewModel : QuestionQueryViewModel
{
    private readonly QuestionTemplate _questionTemplate;

    public OpenQuestionQueryViewModel(QuestionTemplates questionTemplates, IQuestionProvider questionProvider) : base(questionProvider)
    {
        _questionTemplate = questionTemplates.OpenQuestionTemplate;
    }

    public override bool CanRunQuery()
        => !string.IsNullOrWhiteSpace(EducationLevel) &&
           !string.IsNullOrWhiteSpace(Subject) &&
           !string.IsNullOrWhiteSpace(Topic);

    public override bool CanPreviewQuery()
        => !string.IsNullOrWhiteSpace(EducationLevel) &&
           !string.IsNullOrWhiteSpace(Subject) &&
           !string.IsNullOrWhiteSpace(Topic);

    public override QuestionQuery CreateQuestionQuery()
    {
        var query = new OpenQuestionQuery(EducationLevel, Subject, Topic, _questionTemplate.TemplateText);

        return query;
    }
}
