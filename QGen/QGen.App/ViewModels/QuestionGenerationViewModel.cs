using Microsoft.Extensions.DependencyInjection;
using QGen.App.Commands;
using QGen.App.Pages;
using QGen.App.Pages.QuestionQueries;
using QGen.Domain.Queries;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace QGen.App.ViewModels;

public class QuestionGenerationViewModel : BaseViewModel
{
    private readonly IServiceProvider _serviceProvider;

    public GeneratedQuestionsPage GeneratedQuestionsPage { get; private set; }

    public QuestionGenerationViewModel(IServiceProvider serviceProvider) : base()
    {
        _serviceProvider = serviceProvider;
        GeneratedQuestionsPage = _serviceProvider.GetService<GeneratedQuestionsPage>() ?? throw new Exception("Couldn't resovle generated questions page service.");
    }


    public ObservableCollection<QuestionTypes> AvailableQuestionTypes { get; private set; } = new ObservableCollection<QuestionTypes>
    {
        QuestionTypes.OPEN,
        QuestionTypes.YES_NO,
        QuestionTypes.MULTI_CHOICE,
        QuestionTypes.SINGLE_WORD,
        QuestionTypes.FILL_BLANKS
    };

    public QuestionTypes? SelectedQuestionType { get; set; }

    public RelayCommand<QuestionTypes> QuestionTypeSelectionCommand => new RelayCommand<QuestionTypes>(ShowQuestionQueryEditor);

    public QuestionQueryPage? CurrentQueryEditorPage { get; set; }

    private void ShowQuestionQueryEditor(QuestionTypes questionType)
    {
        CurrentQueryEditorPage =
            questionType switch
            {
                QuestionTypes.OPEN => _serviceProvider.GetService<OpenQuestionQueryPage>(),
                QuestionTypes.YES_NO => _serviceProvider.GetService<YesNoQuestionQueryPage>(),
                QuestionTypes.MULTI_CHOICE => _serviceProvider.GetService<MultiChoiceQuestionQueryPage>(),
                QuestionTypes.SINGLE_WORD => _serviceProvider.GetService<SingleWordAnswerQuestionQueryPage>(),
                QuestionTypes.FILL_BLANKS => _serviceProvider.GetService<FillBlanksQuestionQueryPage>(),
                _ => QuestionQueryPage.CreateEmpty()
            };

        CurrentQueryEditorPage.BaseViewModel.OnQuestionGenerated += BaseViewModel_OnQuestionGenerated;
    }

    private void BaseViewModel_OnQuestionGenerated(object? sender, QuestionQueries.QuestionGeneratedEventArgs e)
    {
        GeneratedQuestionsPage.AddGeneratedQuestion(e.GeneratedQuestion);
    }
}