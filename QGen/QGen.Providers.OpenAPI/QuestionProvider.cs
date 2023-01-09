using QGen.Base;
using QGen.Domain.Queries;

namespace QGen.Providers.OpenAPI;

public class QuestionProvider : IQuestionProvider
{
    private readonly ApiSettings _apiSettings;

    public QuestionProvider(ApiSettings apiSettings)
    {
        _apiSettings = apiSettings ?? throw new ArgumentNullException(nameof(apiSettings));
    }


    public async Task<Result<string>> FetchQuestion(QuestionQuery questionQuery)
    {
        try
        {
            return Results.OnFailure<string>();
        }
        catch(Exception ex)
        {
            return Results.OnException<string>(ex);
        }
    }
}
