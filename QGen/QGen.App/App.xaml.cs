using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QGen.App.Settings;
using QGen.Providers;
using QGen.Providers.OpenAI;
using System;
using System.Data;
using System.IO;
using System.Linq;
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
            .AddJsonFile("appsettings.json", false);

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
        services.AddSingleton<QuestionTemplates>(provider => provider.GetService<AppSettings>()!.QuestionTemplates);
        
        // add providers
        services.AddTransient<IQuestionProvider, QuestionProvider>(provider => new QuestionProvider(provider.GetService<ApiSettings>()!));

        // add viewModels
        services.LoadViewModelsFromAssembly();

        // add pages
        services.LoadPagesFromAssembly();

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

public static class AppCreationHelpers
{
    public static IServiceCollection LoadPagesFromAssembly(this IServiceCollection services)
        => AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.Name.EndsWith("Page") && !type.IsAbstract)
            .Aggregate(services, (ser, type) => ser.AddTransient(type));

    public static IServiceCollection LoadViewModelsFromAssembly(this IServiceCollection services)
        => AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.Name.EndsWith("ViewModel") && !type.IsAbstract)
            .Aggregate(services, (ser, type) => ser.AddTransient(type));
}
