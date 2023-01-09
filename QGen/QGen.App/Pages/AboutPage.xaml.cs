using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
