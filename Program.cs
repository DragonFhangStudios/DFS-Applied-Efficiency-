using System;
using System.Windows.Forms;

namespace AerospaceCalc;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Instantiate the calculator and inject it
        var calculator = new TruePositionCalculator();
        var mainForm = new MainForm(calculator);

        Application.Run(mainForm);
    }
}
