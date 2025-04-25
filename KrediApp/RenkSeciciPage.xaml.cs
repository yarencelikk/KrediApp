using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System;

namespace KrediApp;

public partial class RenkSeciciPage : ContentPage
{
    public RenkSeciciPage()
    {
        InitializeComponent();
    }

    private void OnColorChanged(object sender, ValueChangedEventArgs e)
    {
        UpdateColor();
    }

    private void UpdateColor()
    {
        int r = (int)redSlider.Value;
        int g = (int)greenSlider.Value;
        int b = (int)blueSlider.Value;

        redLabel.Text = $"R: {r}";
        greenLabel.Text = $"G: {g}";
        blueLabel.Text = $"B: {b}";

        string hex = $"#{r:X2}{g:X2}{b:X2}";
        hexLabel.Text = $"Renk: {hex}";

        this.BackgroundColor = Color.FromRgb(r, g, b);
    }

    private async void OnCopyClicked(object sender, EventArgs e)
    {
        string renkKodu = hexLabel.Text.Replace("Renk: ", "");
        await Clipboard.SetTextAsync(renkKodu);
        await DisplayAlert("Kopyalandý", $"{renkKodu}", "OK");
    }

    private void OnRandomClicked(object sender, EventArgs e)
    {
        Random rnd = new Random();
        redSlider.Value = rnd.Next(0, 256);
        greenSlider.Value = rnd.Next(0, 256);
        blueSlider.Value = rnd.Next(0, 256);
        // UpdateColor otomatik tetikleniyor çünkü ValueChanged eventi var
    }
}
