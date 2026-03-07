using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;

namespace AerospaceCalc;

// C# 13 Primary Constructor
public partial class MainForm(TruePositionCalculator calculator) : Form
{
    private readonly TruePositionCalculator _calculator = calculator;
    private readonly WebView2 _webView = new WebView2 { Dock = DockStyle.Fill };

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Text = "Aerospace True Position Calculator";
        Width = 800;
        Height = 600;
        StartPosition = FormStartPosition.CenterScreen;

        Controls.Add(_webView);

        InitializeAsync();
    }

    private async void InitializeAsync()
    {
        // Wait for WebView2 initialization
        await _webView.EnsureCoreWebView2Async(null);

        // Load the local HTML file
        string htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "index.html");
        _webView.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);

        // Register the message handler
        _webView.CoreWebView2.WebMessageReceived += OnWebMessageReceived;
    }

    private void OnWebMessageReceived(object? sender, CoreWebView2WebMessageReceivedEventArgs e)
    {
        try
        {
            string jsonMessage = e.TryGetWebMessageAsString();

            var request = JsonSerializer.Deserialize<CalculationRequest>(jsonMessage);

            if (request != null && request.Action == "calculate")
            {
                decimal result = _calculator.CalculateTruePosition(
                    request.XActual, request.XTarget, request.YActual, request.YTarget);

                // Format with aerospace tolerance (4 decimal places usually)
                var response = new CalculationResponse(true, result.ToString("F4"));

                string jsonResponse = JsonSerializer.Serialize(response);
                _webView.CoreWebView2.PostWebMessageAsString(jsonResponse);
            }
        }
        catch (Exception ex)
        {
            var errorResponse = new CalculationResponse(false, null, ex.Message);
            string jsonResponse = JsonSerializer.Serialize(errorResponse);
            _webView.CoreWebView2.PostWebMessageAsString(jsonResponse);
        }
    }
}
