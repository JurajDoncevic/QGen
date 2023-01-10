using QGen.App.Settings;
using QGen.Domain.Queries;
using QGen.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QGen.App.ViewModels.QuestionQueries;
public class YesNoQuestionQueryViewModel : QuestionQueryViewModel
{
    private readonly QuestionTemplate _questionTemplate;

    public YesNoQuestionQueryViewModel(QuestionTemplates questionTemplates, IQuestionProvider questionProvider) : base(questionProvider)
    {
        _questionTemplate = questionTemplates.YesNoQuestionTemplate;
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
        var query = new YesNoQuestionQuery(EducationLevel, Subject, Topic, _questionTemplate.TemplateText);

        return query;
    }
}
