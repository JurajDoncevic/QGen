using QGen.Providers.OpenAPI;

namespace QGen.App.Settings;
public class AppSettings
{
    public ApiSettings ApiSettings { get; set; }
    public QuestionTemplates QuestionTemplates { get; set; }
}
