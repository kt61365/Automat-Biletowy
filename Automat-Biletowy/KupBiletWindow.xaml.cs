using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AutomatBiletowy
{
    public partial class KupBiletWindow : Window
    {
        private string typBiletu = "";
        private readonly string sciezkaPliku;
        private readonly TextBox wynikTextBox;
        private Brush defaultBackground; //domyslny kolor przycisku (niezaznaczony)

        public KupBiletWindow(string sciezkaPliku, TextBox wynikTextBox)
        {
            InitializeComponent();
            this.sciezkaPliku = sciezkaPliku;
            this.wynikTextBox = wynikTextBox;
            defaultBackground = NormalnyButton.Background;
        }

        private void NormalnyButton_Click(object sender, RoutedEventArgs e)
        {
            typBiletu = "Normalny";
            NormalnyButton.Background = Brushes.LightGreen;
            UlgowyButton.Background = defaultBackground;
        }

        private void UlgowyButton_Click(object sender, RoutedEventArgs e)
        {
            typBiletu = "Ulgowy";
            UlgowyButton.Background = Brushes.LightGreen;
            NormalnyButton.Background = defaultBackground;
        }

        private void ZatwierdzButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(typBiletu) || !int.TryParse(LiczbaBiletowBox.Text, out int liczbaBiletow) || liczbaBiletow <= 0)
            {
                MessageBox.Show("Wybierz typ biletu i podaj poprawną liczbę biletów!");
                return;
            }

            var transakcja = Transakcja.SprzedajBilet(typBiletu, liczbaBiletow);
            StringBuilder wynik = new StringBuilder(); //klasa SringBuilder zamiast stringa - dla łatwiejszej modyfikacji wyniku
            wynik.AppendLine($"Łączna kwota do zapłaty: {transakcja.PobierzKwote()} zł");
            wynik.AppendLine("Płatność przyjęta. Drukowanie biletów...");
            foreach (var bilet in transakcja.Bilety)
            {
                wynik.AppendLine(bilet.ToString());
            }

            wynikTextBox.Text = wynik.ToString();
            OdczytZapis.ZapiszTransakcjeDoPliku(transakcja, sciezkaPliku);
            Close();
        }
    }
}