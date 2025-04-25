using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Threading;

namespace ivs_calc_proj.Controls;

public class CalcButton : Button
{
    /// <summary>
    /// Simulates a press action on the button, temporarily applying the pressed visual state
    /// and executing the associated command if it exists. The button remains in the pressed
    /// state for a short duration defined by an internal timer.
    /// </summary>
    public void SimulatePress()
    {
        // adds the pressed state
        PseudoClasses.Add(":pressed");

        // Sets how long the button will be in the pressed state
        var timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(100)
        };

        // Removes the pressed state after the set interval
        timer.Tick += (sender, args) =>
        {
            PseudoClasses.Remove(":pressed");
            timer.Stop();
        };

        timer.Start();

        if (Command != null)
            Command.Execute(CommandParameter);
    }
}