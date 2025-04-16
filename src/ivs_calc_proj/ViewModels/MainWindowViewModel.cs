namespace ivs_calc_proj.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Expression { get; set; } = "";
    public string Output { get; set; } = "";
    public bool OutputVisible { get; set; } = false;


}