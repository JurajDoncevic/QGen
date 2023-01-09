﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QGen.App.Pages;
using QGen.App.Settings;
using QGen.App.ViewModels;
using QGen.Providers;
using QGen.Providers.OpenAPI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace QGen.App;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private ServiceProvider _serviceProvider;

    public App()
    {
        IConfiguration configuration = LoadConfiguration();
        AppSettings appSettings = LoadSettings(configuration);
        IServiceCollection services = ConfigureServices(new ServiceCollection(), appSettings);
        _serviceProvider = services.BuildServiceProvider();
    }

    private IConfiguration LoadConfiguration()
    {
        var builder =
            new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json", false);

        return builder.Build();
    }

    private AppSettings LoadSettings(IConfiguration configuration)
    {
        var appSettings = 
            configuration.GetSection("AppSettings")
                         .Get<AppSettings>() ?? throw new Exception("Application settings are not valid");

        return appSettings;
    }

    private IServiceCollection ConfigureServices(IServiceCollection services, AppSettings appSettings)
    {
        // add settings as singletons - api settings should be editable
        services.AddSingleton<AppSettings>(provider => appSettings);
        services.AddSingleton<ApiSettings>(provider => provider.GetService<AppSettings>()!.ApiSettings);
        
        // add providers
        services.AddTransient<IQuestionProvider, QuestionProvider>(provider => new QuestionProvider(provider.GetService<ApiSettings>()!));

        // add viewModels
        services.AddTransient<ApiSettingsViewModel>();
        services.AddTransient<GeneratedQuestionsViewModel>();
        services.AddTransient<QuestionGenerationViewModel>();

        // add pages
        services.AddTransient<AboutPage>();
        services.AddTransient<ApiSettingsPage>();
        services.AddTransient<GeneratedQuestionsPage>();
        services.AddTransient<QuestionGenerationPage>();

        // add main application window
        services.AddSingleton<MainWindow>();

        return services;
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        var mainWindow = _serviceProvider.GetService<MainWindow>();
        mainWindow.Show();
    }
}
