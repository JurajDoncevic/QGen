using Microsoft.Extensions.DependencyInjection;
using QGen.App.Commands;
using QGen.App.Pages;
using System;
using System.ComponentModel;
using System.Windows;

namespace QGen.App;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private readonly IServiceProvider _serviceProvider;

    public RelayCommand ShowApiSettingsCommand => new RelayCommand(o => ShowApiSettings());
    public RelayCommand ShowAboutCommand => new RelayCommand(o => ShowAbout());
    public RelayCommand ShowQuestionGenerationCommand => new RelayCommand(o => ShowQuestionGeneration());

    public MainWindow(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        InitializeComponent();
    }

    private void ShowApiSettings()
    {
        var page = _serviceProvider.GetService<ApiSettingsPage>();
        MainFrame.Content = page;
    }

    private void ShowAbout()
    {
       var page = _serviceProvider.GetService<AboutPage>();
        MainFrame.Content = page;
    }

    private void ShowQuestionGeneration()
    {
        var page = _serviceProvider.GetService<QuestionGenerationPage>();
        MainFrame.Content = page;
    }
}
