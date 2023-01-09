namespace QGen.Domain.Queries;

public abstract class QuestionQuery
{
    private string _educationLevel;
    private string _subject;
    private string _topic;
    protected readonly string _templateString;

    public abstract QuestionTypes QuestionType { get; }

    protected QuestionQuery(string educationLevel, string subject, string topic, string templateString)
    {
        _educationLevel = educationLevel;
        _subject = subject;
        _topic = topic;
        _templateString = templateString;
    }

    protected QuestionQuery(string templateString)
    {
        _educationLevel = string.Empty; 
        _subject = string.Empty; 
        _topic = string.Empty;
        _templateString = templateString;
    }

    public string TemplateString => _templateString;
    public string EducationLevel { get => _educationLevel; set => _educationLevel = value; }
    public string Subject { get => _subject; set => _subject = value; }
    public string Topic { get => _topic; set => _topic = value; }
}
