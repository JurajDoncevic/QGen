namespace QGen.App.Settings;

public class QuestionTemplates
{
    public QuestionTemplate OpenQuestionTemplate { get; set; }
    public QuestionTemplate YesNoQuestionTemplate { get; set; }
    public QuestionTemplate MultiChoiceQuestionTemplate { get; set; }
    public QuestionTemplate SingleWordAnswerQuestionTemplate { get; set; }
    public QuestionTemplate FillBlanksQuestionTemplate { get; set; }
}

public class QuestionTemplate
{
    public string TemplateText { get; set; }
}