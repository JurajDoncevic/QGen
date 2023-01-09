using QGen.App.ViewModels;
using System.Windows.Controls;

namespace QGen.App.Pages;
/// <summary>
/// Interaction logic for GeneratedQuestionsPage.xaml
/// </summary>
public partial class GeneratedQuestionsPage : Page
{
    internal GeneratedQuestionsViewModel ViewModel { get; private set; }

    internal GeneratedQuestionsPage(GeneratedQuestionsViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();
    }

    internal void AddGeneratedQuestion(string question)
    {
        ViewModel.AddQuestion(question);
    }
}
