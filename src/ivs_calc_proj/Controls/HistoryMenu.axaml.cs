using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ivs_calc_proj.Controls;

public partial class HistoryMenu : UserControl
{
    public HistoryMenu()
    {
        InitializeComponent();
    }

    public void AddEntry(string input, string output)
    {
        var entriesStackPanel = (StackPanel)Entries;
        var entry = new HistoryMenuEntry(input, output);
        entriesStackPanel.Children.Add(entry);
    }
}