using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace ivs_calc_proj.Controls;

/// <summary>
/// Represents a user control for displaying and managing the calculator's history menu.
/// </summary>
/// <remarks>
/// This control provides a visual representation of past calculations, allowing users
/// to view the input expressions and their corresponding results. It interacts with other
/// controls, such as the Calculator control, to enable seamless navigation and data sharing.
/// </remarks>
public partial class HistoryMenu : UserControl
{
    public HistoryMenu()
    {
        InitializeComponent();
    }

    /// <summary>
    /// Adds a new entry to the history menu with the provided input and output values.
    /// </summary>
    /// <param name="input">The input string representing the expression or equation that was calculated.</param>
    /// <param name="output">The output string representing the result of the calculation.</param>
    public void AddEntry(string input, string output)
    {
        var entriesStackPanel = (StackPanel)Entries;
        var entry = new HistoryMenuEntry(input, output);
        entriesStackPanel.Children.Add(entry);
    }
}