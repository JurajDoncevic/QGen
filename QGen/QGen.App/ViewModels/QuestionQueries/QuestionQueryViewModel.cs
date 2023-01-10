using QGen.App.Commands;
using QGen.Base;
using QGen.Domain.Queries;
using QGen.Providers;
using System;
using System.Threading.Tasks;

namespace QGen.App.ViewModels.QuestionQueries;
public abstract class QuestionQueryViewModel : BaseViewModel
{
    public string EducationLevel { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
    public string QueryPreview { get; private set; } = string.Empty;
    public string OperationOutcomeMessage { get; set; } = string.Empty;
    public bool? IsOperationSuccessful { get; set; }

    public event EventHandler<QuestionGeneratedEventArgs>? OnQuestionGenerated;
    
    private readonly IQuestionProvider _questionProvider;

    public RelayCommand RunQueryCommand
        => new RelayCommand(async o => SetOutcomeDisplay(await RunQuery(CreateQuestionQuery())), o => CanRunQuery());
    public abstract bool CanRunQuery();

    public RelayCommand PreviewQueryCommand
        => new RelayCommand(o => CreateQueryPreview(), o => CanPreviewQuery());
    public abstract bool CanPreviewQuery();


    private void CreateQueryPreview()
    {
        if (CanPreviewQuery())
        {
            QueryPreview = CreateQuestionQuery().GetText();
        }
    }

    protected QuestionQueryViewModel(IQuestionProvider questionProvider)
    {
        _questionProvider = questionProvider;
    }

    public abstract QuestionQuery CreateQuestionQuery();

    private void SetOutcomeDisplay(Result<string> queryResult)
    {
        OperationOutcomeMessage = queryResult.Message;
        IsOperationSuccessful = queryResult;
    }

    private async Task<Result<string>> RunQuery(QuestionQuery questionQuery)
    {
        var result = await _questionProvider.FetchQuestion(questionQuery);

        if (result)
        {
            OnQuestionGenerated?.Invoke(this, new QuestionGeneratedEventArgs(result.Data, DateTime.Now));
        }
        return result;
    }
}

public class QuestionGeneratedEventArgs : EventArgs
{
    public QuestionGeneratedEventArgs(string generatedQuestion, DateTime generatedOn)
    {
        GeneratedQuestion = generatedQuestion;
        GeneratedOn = generatedOn;
    }

    public string GeneratedQuestion { get; private set; }
    public DateTime GeneratedOn { get; private set; }
}