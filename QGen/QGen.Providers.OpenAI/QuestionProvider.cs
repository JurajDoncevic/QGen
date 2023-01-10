using OpenAI.GPT3;
using OpenAI.GPT3.Managers;
using OpenAI.GPT3.ObjectModels.RequestModels;
using OpenAI.GPT3.ObjectModels;
using QGen.Base;
using QGen.Domain.Queries;

namespace QGen.Providers.OpenAI;

public class QuestionProvider : IQuestionProvider
{
    private readonly ApiSettings _apiSettings;
    private readonly OpenAIService _api;

    public QuestionProvider(ApiSettings apiSettings)
    {
        _apiSettings = apiSettings ?? throw new ArgumentNullException(nameof(apiSettings));
        _api = new OpenAIService(new OpenAiOptions() { ApiKey = _apiSettings.ApiKey });
    }

    public async Task<Result<string>> FetchQuestion(QuestionQuery questionQuery)
    {
        try
        {
            var completionResult = await _api.Completions.CreateCompletion(
                new CompletionCreateRequest()
                {
                    Prompt = questionQuery.GetText(),
                    TopP = _apiSettings.TopP,
                    Temperature = _apiSettings.Temperature,
                    MaxTokens = _apiSettings.MaxTokens
                },
                Models.TextDavinciV3);

            if (completionResult.Successful)
            {
                return Results.OnSuccess<string>(completionResult.Choices.FirstOrDefault()!.Text);
            }
            else
            {
                return Results.OnFailure<string>(completionResult.Error!.Message);
            }
        }
        catch (Exception ex)
        {
            return Results.OnException<string>(ex);
        }
    }
}
