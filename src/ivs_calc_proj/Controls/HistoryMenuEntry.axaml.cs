using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ivs_calc_proj.Controls;

public partial class HistoryMenuEntry : UserControl
{
    public HistoryMenuEntry(string input, string output)
    {
        InitializeComponent();
        this.InputLabel.Content = input;
        this.OutputLabel.Content = output;
    }
}