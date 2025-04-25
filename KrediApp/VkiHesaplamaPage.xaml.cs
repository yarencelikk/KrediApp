using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace KrediApp;

public partial class VkiHesaplamaPage : ContentPage
{
    public VkiHesaplamaPage()
    {
        InitializeComponent();
    }

    private void OnVkiChanged(object sender, ValueChangedEventArgs e)
    {
        double kilo = kiloSlider.Value;
        double boy = boySlider.Value / 100.0;

        kiloLabel.Text = $"Kilo: {kilo:F1}";
        boyLabel.Text = $"Boy: {boySlider.Value:F0} cm";

        double vki = kilo / (boy * boy);
        string vkiDurum;

        if (vki < 16)
            vkiDurum = "İleri Düzeyde Zayıf";
        else if (vki < 17)
            vkiDurum = "Orta Düzeyde Zayıf";
        else if (vki < 18.5)
            vkiDurum = "Hafif Düzeyde Zayıf";
        else if (vki < 25)
            vkiDurum = "Normal Kilolu";
        else if (vki < 30)
            vkiDurum = "Hafif Şişman / Fazla Kilolu";
        else if (vki < 35)
            vkiDurum = "1. Derecede Obez";
        else if (vki < 40)
            vkiDurum = "2. Derecede Obez";
        else
            vkiDurum = "3. Derecede Obez / Morbid Obez";

        vkiLabel.Text = $"VKİ: {vki:F2} → {vkiDurum}";
    }
}
