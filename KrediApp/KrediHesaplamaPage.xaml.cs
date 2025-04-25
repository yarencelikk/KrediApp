using System;
using Microsoft.Maui.Controls;

namespace KrediApp
{
    public partial class KrediHesaplamaPage : ContentPage
    {
        public KrediHesaplamaPage()
        {
            InitializeComponent();
        }

        private void OnVadeChanged(object sender, ValueChangedEventArgs e)
        {
            int vade = (int)e.NewValue;
            vadeLabel.Text = $"Vade: {vade} Ay";
        }

        private void OnHesaplaClicked(object sender, EventArgs e)
        {
            try
            {
                // Kredi türüne göre KKDF ve BSMV oranları
                double kkdf = 0, bsmv = 0;
                switch (krediPicker.SelectedItem?.ToString())
                {
                    case "İhtiyaç":
                        kkdf = 0.15;
                        bsmv = 0.10;
                        break;
                    case "Konut":
                        kkdf = 0;
                        bsmv = 0;
                        break;
                    case "Taşıt":
                        kkdf = 0.15;
                        bsmv = 0.05;
                        break;
                    case "Ticari":
                        kkdf = 0;
                        bsmv = 0.05;
                        break;
                    default:
                        sonucLabel.Text = "Lütfen kredi türünü seçin.";
                        return;
                }

                // Kullanıcıdan alınan veriler
                double tutar = double.Parse(tutarEntry.Text);
                double oran = double.Parse(faizEntry.Text);
                int vade = (int)vadeSlider.Value;

                // brüt faiz formülü
                double brutFaiz = (oran+ (oran * bsmv) + (oran * kkdf)) / 100;

                // Aylık taksit formülü
                double taksit = ((Math.Pow(1 + brutFaiz, vade) * brutFaiz) / (Math.Pow(1 + brutFaiz, vade) - 1)) * tutar;
                double toplam = taksit * vade;
                double toplamFaiz = toplam - tutar;

                // Sonuç etiketi
                sonucLabel.Text = $"Aylık Taksit: {taksit:F2} ₺\n" +
                                  $"Toplam Ödeme: {toplam:F2} ₺\n" +
                                  $"Toplam Faiz: {toplamFaiz:F2} ₺";
            }
            catch (Exception ex)
            {
                sonucLabel.Text = $"Hata: {ex.Message}";
            }
        }
    }
}
