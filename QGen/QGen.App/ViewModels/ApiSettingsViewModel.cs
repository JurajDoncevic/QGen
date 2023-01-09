using CommunityToolkit.Mvvm.Input;
using QGen.Providers.OpenAPI;
using System.ComponentModel;

namespace QGen.App.ViewModels;
public class ApiSettingsViewModel : BaseViewModel, INotifyPropertyChanged
{
    public ApiSettings ApiSettings { get; set; }

    public string ApiKey { get; set; }

    public RelayCommand SaveChangesCommand => new RelayCommand(SaveChanges);

    public ApiSettingsViewModel(ApiSettings apiSettings)
    {
        ApiSettings = apiSettings;
        ApiKey = apiSettings.ApiKey;
    }

    public void SaveChanges()
    {
        ApiSettings.ApiKey = ApiKey;
    }
}
