using QGen.App.ViewModels;
using System.Windows.Controls;

namespace QGen.App.Pages;
/// <summary>
/// Interaction logic for ApiSettingsPage.xaml
/// </summary>
public partial class ApiSettingsPage : Page
{
    public ApiSettingsViewModel ViewModel { get; private set; }

    public ApiSettingsPage(ApiSettingsViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();
    }
}
