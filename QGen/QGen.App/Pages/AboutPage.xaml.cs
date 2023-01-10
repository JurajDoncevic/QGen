using QGen.App.Commands;
using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace QGen.App.Pages;
/// <summary>
/// Interaction logic for AboutPage.xaml
/// </summary>
public partial class AboutPage : Page
{
    public RelayCommand<Uri> OpenUriCommand => new RelayCommand<Uri>(OpenUriInBrowser);

    public AboutPage()
    {
        InitializeComponent();
    }

    public void OpenUriInBrowser(Uri? uri)
    {
        if (uri is not null)
        {
            var strUri = uri.OriginalString;
            var sInfo = new System.Diagnostics.ProcessStartInfo(strUri)
            {
                UseShellExecute = true,
            };
            System.Diagnostics.Process.Start(sInfo);
        }
    }

    private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        e.Handled = true;
    }
}
