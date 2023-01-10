using OpenAI_API;
using QGen.Base;
using QGen.Domain.Queries;

namespace QGen.Providers.OpenAPI;

public class QuestionProvider : IQuestionProvider
{
    private readonly ApiSettings _apiSettings;
    private readonly OpenAIAPI _api;
    public QuestionProvider(ApiSettings apiSettings)
    {
        _apiSettings = apiSettings ?? throw new ArgumentNullException(nameof(apiSettings));
        _api = new OpenAI_API.OpenAIAPI(apiSettings.ApiKey, engine: Engine.Davinci);
    }


    public async Task<Result<string>> FetchQuestion(QuestionQuery questionQuery)
    {
        try
        {
            var result = await _api.Completions.CreateCompletionAsync(questionQuery.GetText(), temperature: _apiSettings.Temperature, max_tokens: _apiSettings.MaxTokens, top_p: _apiSettings.TopP);
            var resultQuestion = result.Completions.FirstOrDefault()?.Text;

            if (resultQuestion != null)
            {
                return Results.OnSuccess<string>(resultQuestion);
            }
            else
            {
                return Results.OnFailure<string>("Couldn't retrieve first choice");
            }
            
        }
        catch(Exception ex)
        {
            return Results.OnException<string>(ex);
        }
    }
}
