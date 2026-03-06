using app.ViewModels;

namespace app;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : System.Windows.Window
{
    public MainWindow()
    {
        InitializeComponent();

        IAerospaceMathService mathService = new AerospaceMathService();
        DataContext = new MainViewModel(mathService);
    }
}