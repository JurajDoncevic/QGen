using QGen.App.Commands;
using QGen.App.ViewModels;
using System.Windows.Controls;

namespace QGen.App.Pages;
/// <summary>
/// Interaction logic for GeneratedQuestionsPage.xaml
/// </summary>
public partial class GeneratedQuestionsPage : Page
{
    public GeneratedQuestionsViewModel ViewModel { get; private set; }

    public RelayCommand ClearHistoryCommand
        => new RelayCommand(o => ClearGeneratedQuestions());

    public GeneratedQuestionsPage(GeneratedQuestionsViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();
    }

    public void AddGeneratedQuestion(string question)
    {
        ViewModel.AddQuestion(question);
    }

    public void ClearGeneratedQuestions()
    {
        ViewModel.ClearQuestions();
    }
}
