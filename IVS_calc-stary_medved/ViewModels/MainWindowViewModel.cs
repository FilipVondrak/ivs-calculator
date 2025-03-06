using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace IVS_calc_stary_medved.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    
    [ObservableProperty]
    private string _message = "Hello, Avalonia!";
    
    [RelayCommand]
    private void OnButtonClick()
    {
        Message = "Button clicked!";
    }
}