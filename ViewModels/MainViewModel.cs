using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace app.ViewModels;

public interface IAerospaceMathService
{
    decimal CalculateDeviation(decimal target, decimal actual);
    decimal CalculateTruePosition(decimal xDeviation, decimal yDeviation);
}

public class AerospaceMathService : IAerospaceMathService
{
    public decimal CalculateDeviation(decimal target, decimal actual)
    {
        return actual - target;
    }

    public decimal CalculateTruePosition(decimal xDeviation, decimal yDeviation)
    {
        // Formula: 2 * sqrt(dx^2 + dy^2).
        // For highest precision, we do the multiplication/addition as decimal,
        // but Math.Sqrt requires double. We cast to double only for the Sqrt, then back to decimal.
        decimal sumOfSquares = (xDeviation * xDeviation) + (yDeviation * yDeviation);
        double result = 2.0 * Math.Sqrt((double)sumOfSquares);
        return (decimal)result;
    }
}

public partial class MainViewModel(IAerospaceMathService mathService) : ObservableObject
{
    [ObservableProperty]
    private string _currentUser = "Andrew";

    [ObservableProperty]
    private int _toolCount = 42;

    [ObservableProperty]
    private int _gaugeCount = 18;

    [ObservableProperty]
    private int _productionToday = 150;

    [ObservableProperty]
    private int _logCount = 5;

    [ObservableProperty]
    private string _npiNotes = string.Empty;

    [ObservableProperty]
    private ObservableCollection<string> _npiTasks = new();

    [ObservableProperty]
    private int _selectedTabIndex = 0;

    // High Precision Decimal Properties for Math UI
    [ObservableProperty]
    private decimal _targetX = 0.0000m;

    [ObservableProperty]
    private decimal _actualX = 0.0000m;

    [ObservableProperty]
    private decimal _targetY = 0.0000m;

    [ObservableProperty]
    private decimal _actualY = 0.0000m;

    [ObservableProperty]
    private decimal _truePositionResult = 0.0000m;

    [RelayCommand]
    private void ChangeUser()
    {
        CurrentUser = CurrentUser == "Andrew" ? "Sarah (Supervisor)" : "Andrew";
    }

    [RelayCommand]
    private void AddNpiTask()
    {
        if (!string.IsNullOrWhiteSpace(NpiNotes))
        {
            NpiTasks.Add(NpiNotes);
            NpiNotes = string.Empty;
        }
    }

    [RelayCommand]
    private void CalculateTruePosition()
    {
        decimal devX = mathService.CalculateDeviation(TargetX, ActualX);
        decimal devY = mathService.CalculateDeviation(TargetY, ActualY);

        TruePositionResult = mathService.CalculateTruePosition(devX, devY);
    }

    [RelayCommand]
    private void NavigateToTab(int tabIndex)
    {
        SelectedTabIndex = tabIndex;
    }
}