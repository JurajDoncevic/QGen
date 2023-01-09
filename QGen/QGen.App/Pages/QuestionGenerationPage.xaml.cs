using QGen.App.ViewModels;
using System.Windows.Controls;

namespace QGen.App.Pages;
/// <summary>
/// Interaction logic for QuestionGenerationPage.xaml
/// </summary>
public partial class QuestionGenerationPage : Page
{
    public QuestionGenerationViewModel ViewModel { get; private set; }

    public QuestionGenerationPage(QuestionGenerationViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();
    }

}
