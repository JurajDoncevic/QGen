using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;
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
            var completionResult = await _api.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = new List<ChatMessage>
                {
                    new ChatMessage("user", questionQuery.GetText())
                },
                TopP = _apiSettings.TopP,
                Temperature = _apiSettings.Temperature,
                MaxTokens = _apiSettings.MaxTokens
            }, Models.Gpt_4);

            if (completionResult.Successful)
            {
                return Results.OnSuccess<string>(completionResult.Choices.FirstOrDefault()!.Message.Content);
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
