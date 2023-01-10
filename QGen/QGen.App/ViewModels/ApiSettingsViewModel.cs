using QGen.App.Commands;
using QGen.Providers.OpenAPI;
using System.ComponentModel;

namespace QGen.App.ViewModels;
public class ApiSettingsViewModel : BaseViewModel, INotifyPropertyChanged
{
    public ApiSettings ApiSettings { get; set; }

    public string ApiKey { get; set; }
    public float TopP { get; set; }
    public float Temperature { get; set; }
    public int MaxTokens { get; set; }

    public RelayCommand SaveChangesCommand => new RelayCommand(o => SaveChanges());

    public ApiSettingsViewModel(ApiSettings apiSettings)
    {
        ApiSettings = apiSettings;
        ApiKey = apiSettings.ApiKey;
        TopP = apiSettings.TopP;
        Temperature = apiSettings.Temperature;
        MaxTokens = apiSettings.MaxTokens;
    }

    public void SaveChanges()
    {
        ApiSettings.ApiKey = ApiKey;
        ApiSettings.TopP = TopP;
        ApiSettings.Temperature = Temperature;
        ApiSettings.MaxTokens = MaxTokens;
    }
}
